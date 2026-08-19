using MudBlazor;

namespace Web;

public static class EtmamTheme
{
    public static readonly MudTheme Theme = new()
    {
        PaletteLight = new PaletteLight
        {
            Primary = "#0F5C4C",
            Secondary = "#C9A24B",
            AppbarBackground = "#0F5C4C",
        },
        Typography = new Typography
        {
            Default = new DefaultTypography { FontFamily = ["Cairo", "Segoe UI", "sans-serif"] },
        },
    };
}
