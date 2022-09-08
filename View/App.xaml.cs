using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using Model.Entities.Theme;
using Newtonsoft.Json;

namespace View
{
    public partial class App : Application
    {
        
        [Inject]
        public IThemeHandler ThemeHandler { get; set; }
        
        public App() {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override async void OnStart() {
            base.OnStart();
            try
            {
                var path = Path.Combine(FileSystem.Current.AppDataDirectory, "Settings", "theme.json");
                if (JsonConvert.DeserializeObject(await File.ReadAllTextAsync(path)) is Theme theme)
                    ThemeHandler.UpdateAll(theme);
            }
            catch(DirectoryNotFoundException){}
            catch (FileNotFoundException) {}
        }
    }
}