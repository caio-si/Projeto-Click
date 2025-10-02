using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace ClickAutomation.Services
{
    public class ClickService
    {
        #region Windows API

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        // Constantes para mouse_event
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;

        #endregion

        #region Events

        public event EventHandler ClickPerformed;
        public event EventHandler<bool> StatusChanged;

        #endregion

        #region Properties

        public bool IsRunning { get; private set; }
        public TimeSpan Interval { get; private set; }
        public DateTime? NextClickTime { get; private set; }

        #endregion

        #region Private Fields

        private CancellationTokenSource _cancellationTokenSource;
        private Task _clickTask;

        #endregion

        #region Public Methods

        public void Start(TimeSpan interval)
        {
            if (IsRunning)
            {
                throw new InvalidOperationException("O serviço já está em execução.");
            }

            Interval = interval;
            IsRunning = true;
            _cancellationTokenSource = new CancellationTokenSource();

            // Iniciar task de click automático
            _clickTask = Task.Run(ClickLoop, _cancellationTokenSource.Token);

            OnStatusChanged(true);
        }

        public void Stop()
        {
            if (!IsRunning)
            {
                return;
            }

            IsRunning = false;
            _cancellationTokenSource?.Cancel();

            try
            {
                _clickTask?.Wait(TimeSpan.FromSeconds(5));
            }
            catch (AggregateException)
            {
                // Ignorar exceções de cancelamento
            }

            NextClickTime = null;
            OnStatusChanged(false);
        }

        public void SetInterval(TimeSpan interval)
        {
            Interval = interval;
        }

        public DateTime? GetNextClickTime()
        {
            return NextClickTime;
        }

        #endregion

        #region Private Methods

        private async Task ClickLoop()
        {
            try
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    // Calcular próximo click
                    NextClickTime = DateTime.Now.Add(Interval);

                    // Aguardar o intervalo
                    await Task.Delay(Interval, _cancellationTokenSource.Token);

                    if (!_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        // Executar click
                        PerformClick();
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Cancelamento normal, não fazer nada
            }
        }

        private void PerformClick()
        {
            try
            {
                // Obter posição atual do cursor
                if (GetCursorPos(out POINT currentPos))
                {
                    // Simular click direito
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, (uint)currentPos.X, (uint)currentPos.Y, 0, 0);
                    Thread.Sleep(50); // Pequena pausa entre down e up
                    mouse_event(MOUSEEVENTF_RIGHTUP, (uint)currentPos.X, (uint)currentPos.Y, 0, 0);

                    // Notificar que o click foi realizado
                    OnClickPerformed();
                }
            }
            catch (Exception ex)
            {
                // Log do erro (em uma implementação real, usar um logger)
                System.Diagnostics.Debug.WriteLine($"Erro ao executar click: {ex.Message}");
            }
        }

        private void OnClickPerformed()
        {
            ClickPerformed?.Invoke(this, EventArgs.Empty);
        }

        private void OnStatusChanged(bool isRunning)
        {
            StatusChanged?.Invoke(this, isRunning);
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Stop();
            _cancellationTokenSource?.Dispose();
        }

        #endregion
    }
}
