using System;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace ClickAutomation.Services
{
    public class ConfigurationService
    {
        private const string CONFIG_FILE = "config.json";
        private readonly string _configPath;

        public ConfigurationService()
        {
            _configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CONFIG_FILE);
        }

        public AppConfiguration LoadConfiguration()
        {
            try
            {
                if (File.Exists(_configPath))
                {
                    var json = File.ReadAllText(_configPath);
                    var config = JsonSerializer.Deserialize<AppConfiguration>(json);
                    return config ?? new AppConfiguration();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar configuração: {ex.Message}");
            }

            return new AppConfiguration();
        }

        public void SaveConfiguration(AppConfiguration config)
        {
            try
            {
                var json = JsonSerializer.Serialize(config, new JsonSerializerOptions 
                { 
                    WriteIndented = true 
                });
                File.WriteAllText(_configPath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao salvar configuração: {ex.Message}");
                MessageBox.Show($"Erro ao salvar configurações: {ex.Message}", "Erro", 
                              MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void SaveWindowSettings(Window window)
        {
            var config = LoadConfiguration();
            config.WindowLeft = window.Left;
            config.WindowTop = window.Top;
            config.WindowWidth = window.Width;
            config.WindowHeight = window.Height;
            config.WindowState = window.WindowState.ToString();
            SaveConfiguration(config);
        }

        public void RestoreWindowSettings(Window window)
        {
            var config = LoadConfiguration();
            
            if (config.WindowLeft.HasValue) window.Left = config.WindowLeft.Value;
            if (config.WindowTop.HasValue) window.Top = config.WindowTop.Value;
            if (config.WindowWidth.HasValue) window.Width = config.WindowWidth.Value;
            if (config.WindowHeight.HasValue) window.Height = config.WindowHeight.Value;
            
            if (Enum.TryParse<WindowState>(config.WindowState, out var windowState))
            {
                window.WindowState = windowState;
            }
        }
    }

    public class AppConfiguration
    {
        public int DefaultIntervalSeconds { get; set; } = 30;
        public bool StartMinimized { get; set; } = false;
        public bool AutoStart { get; set; } = false;
        public bool ShowNotifications { get; set; } = true;
        public string Theme { get; set; } = "Light";
        public double? WindowLeft { get; set; }
        public double? WindowTop { get; set; }
        public double? WindowWidth { get; set; }
        public double? WindowHeight { get; set; }
        public string WindowState { get; set; } = "Normal";
        public bool RememberSettings { get; set; } = true;
        public int ClickCount { get; set; } = 0;
        public DateTime? LastUsed { get; set; }
    }
}




