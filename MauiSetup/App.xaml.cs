using Domain.Logic.Io;

namespace MauiSetup;

public partial class App : Application {
    
    private readonly IThemeHandler _themeHandler;
    public App(IThemeHandler themeHandler) {
        _themeHandler = themeHandler;
        InitializeComponent();

        MainPage = new MainPage();
    }


    protected override void OnStart() {
        try {
            var theme = ThemeIo.Read();
            if (theme is not null) 
                _themeHandler.UpdateAll(theme);
        }
        catch (Exception e) {
            Console.WriteLine(e);
        }
    }
}