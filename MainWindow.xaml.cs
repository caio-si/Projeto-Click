using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using ClickAutomation.Services;

namespace ClickAutomation
{
    public partial class MainWindow : Window
    {
        private ClickService _clickService;
        private DispatcherTimer _uiUpdateTimer;
        private DateTime _startTime;
        private int _clickCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitializeServices();
            SetupUI();
        }

        private void InitializeServices()
        {
            _clickService = new ClickService();
            _clickService.ClickPerformed += OnClickPerformed;
            _clickService.StatusChanged += OnStatusChanged;
        }

        private void SetupUI()
        {
            // Configurar timer para atualização da UI
            _uiUpdateTimer = new DispatcherTimer();
            _uiUpdateTimer.Interval = TimeSpan.FromSeconds(1);
            _uiUpdateTimer.Tick += UpdateUI;
            
            // Configurar valores iniciais
            IntervalSlider_ValueChanged(null, null);
        }

        private void IntervalSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IntervalValue != null)
            {
                int seconds = (int)IntervalSlider.Value;
                IntervalValue.Text = seconds == 1 ? "1 segundo" : $"{seconds} segundos";
                
                // Atualizar intervalo no serviço se estiver rodando
                if (_clickService.IsRunning)
                {
                    _clickService.SetInterval(TimeSpan.FromSeconds(seconds));
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int intervalSeconds = (int)IntervalSlider.Value;
                _clickService.Start(TimeSpan.FromSeconds(intervalSeconds));
                
                _startTime = DateTime.Now;
                _clickCount = 0;
                
                StartButton.IsEnabled = false;
                StopButton.IsEnabled = true;
                IntervalSlider.IsEnabled = false;
                
                _uiUpdateTimer.Start();
                
                UpdateStatusIndicator(true);
                StatusText.Text = "Ativo";
                
                MessageBox.Show("Click automático iniciado!", "Sucesso", 
                              MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar: {ex.Message}", "Erro", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _clickService.Stop();
                
                StartButton.IsEnabled = true;
                StopButton.IsEnabled = false;
                IntervalSlider.IsEnabled = true;
                
                _uiUpdateTimer.Stop();
                
                UpdateStatusIndicator(false);
                StatusText.Text = "Parado";
                
                MessageBox.Show("Click automático parado!", "Informação", 
                              MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao parar: {ex.Message}", "Erro", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnClickPerformed(object sender, EventArgs e)
        {
            _clickCount++;
            
            // Executar animação de click na UI thread
            Dispatcher.Invoke(() =>
            {
                // Animar o indicador de status
                var clickAnimation = (Storyboard)FindResource("ClickEffect");
                clickAnimation.Begin(StatusIndicator);
                
                // Atualizar contador
                ClickCount.Text = _clickCount.ToString();
            });
        }

        private void OnStatusChanged(object sender, bool isRunning)
        {
            Dispatcher.Invoke(() =>
            {
                if (isRunning)
                {
                    UpdateStatusIndicator(true);
                    StatusText.Text = "Ativo";
                }
                else
                {
                    UpdateStatusIndicator(false);
                    StatusText.Text = "Parado";
                }
            });
        }

        private void UpdateStatusIndicator(bool isActive)
        {
            if (isActive)
            {
                StatusIndicator.Background = (SolidColorBrush)FindResource("SuccessBrush");
                
                // Iniciar animação de pulso
                var pulseAnimation = (Storyboard)FindResource("StatusPulse");
                pulseAnimation.Begin(StatusIndicator);
            }
            else
            {
                StatusIndicator.Background = (SolidColorBrush)FindResource("ErrorBrush");
                
                // Parar animação de pulso
                StatusIndicator.BeginAnimation(UIElement.OpacityProperty, null);
                StatusIndicator.Opacity = 1.0;
            }
        }

        private void UpdateUI(object sender, EventArgs e)
        {
            if (_clickService.IsRunning)
            {
                // Atualizar tempo ativo
                var elapsed = DateTime.Now - _startTime;
                ActiveTime.Text = elapsed.ToString(@"hh\:mm\:ss");
                
                // Atualizar próximo click
                var nextClick = _clickService.GetNextClickTime();
                if (nextClick.HasValue)
                {
                    var remaining = nextClick.Value - DateTime.Now;
                    if (remaining.TotalSeconds > 0)
                    {
                        NextClick.Text = remaining.ToString(@"mm\:ss");
                    }
                    else
                    {
                        NextClick.Text = "Agora";
                    }
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            // Parar o serviço ao fechar a aplicação
            _clickService?.Stop();
            _uiUpdateTimer?.Stop();
            base.OnClosed(e);
        }
    }
}
