using MudBlazor;
using System;

namespace RubberTradingSystem.Services
{
    public enum AppThemeType { Light, Dark, Gold, Blue }

    public class AppThemeService
    {
        public AppThemeType CurrentThemeType { get; private set; } = AppThemeType.Dark; // Default ကို Dark လုပ်ထားသည်
        public MudTheme CurrentTheme { get; private set; }
        public bool IsDarkMode => CurrentThemeType == AppThemeType.Dark || CurrentThemeType == AppThemeType.Gold;
        public event Action? OnThemeChanged;

        public AppThemeService() { CurrentTheme = GetTheme(CurrentThemeType); }

        public void SetTheme(AppThemeType themeType)
        {
            CurrentThemeType = themeType;
            CurrentTheme = GetTheme(themeType);
            OnThemeChanged?.Invoke();
        }

        private MudTheme GetTheme(AppThemeType themeType)
        {
            return themeType switch
            {
                AppThemeType.Dark => new MudTheme
                {
                    PaletteDark = new PaletteDark
                    {
                        Primary = "#4caf50", // Forest Green for Rubber Business
                        Secondary = "#81c784",
                        Background = "#0f172a", // Deep Slate
                        Surface = "#1e293b",
                        AppbarBackground = "#0f172a",
                        DrawerBackground = "#0f172a",
                        TextPrimary = "#f8fafc",
                        TextSecondary = "#94a3b8"
                    }
                },
                AppThemeType.Gold => new MudTheme
                {
                    PaletteDark = new PaletteDark
                    {
                        Primary = "#d4af37", // Elegant Gold
                        Secondary = "#f3e5f5",
                        Background = "#1a1a1a",
                        Surface = "#242424",
                        AppbarBackground = "#1a1a1a",
                        DrawerBackground = "#1a1a1a",
                        TextPrimary = "#ffffff",
                        TextSecondary = "#b3b3b3"
                    }
                },
                AppThemeType.Blue => new MudTheme
                {
                    PaletteLight = new PaletteLight
                    {
                        Primary = "#1e88e5",
                        Secondary = "#42a5f5",
                        Background = "#f0f4f8",
                        Surface = "#ffffff",
                        AppbarBackground = "#1565c0",
                        DrawerBackground = "#ffffff",
                        TextPrimary = "#102a43",
                        TextSecondary = "#486581"
                    }
                },
                _ => new MudTheme // Light Theme
                {
                    PaletteLight = new PaletteLight
                    {
                        Primary = "#2e7d32",
                        Secondary = "#4caf50",
                        Background = "#f8fafc",
                        Surface = "#ffffff",
                        AppbarBackground = "#ffffff",
                        DrawerBackground = "#f1f5f9",
                        TextPrimary = "#0f172a",
                        TextSecondary = "#475569",
                        AppbarText = "#0f172a"
                    }
                }
            };
        }
    }
}
