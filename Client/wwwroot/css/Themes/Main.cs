using MudBlazor;

namespace Client.wwwroot.css.Themes;

public class Main {
    public static MudTheme Theme => new MudTheme {
        PaletteLight = new PaletteLight() {
            AppbarBackground = Colors.Amber.Lighten4,
            DrawerBackground = Colors.Amber.Lighten5,
        }
    };
}