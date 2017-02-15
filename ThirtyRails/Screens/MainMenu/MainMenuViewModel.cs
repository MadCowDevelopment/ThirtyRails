using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;
using ThirtyRails.Screens.Game;
using ThirtyRails.Services;
using ThirtyRails.Shell;

namespace ThirtyRails.Screens.MainMenu
{
    [Export(typeof(MainMenuViewModel))]
    public class MainMenuViewModel : Screen, IViewModel
    {
        private readonly INavigationService _navigationService;

        [ImportingConstructor]
        public MainMenuViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void StartGame()
        {
            _navigationService.NavigateTo<GameViewModel>();
        }

        public void Settings()
        {
        }

        public void Quit()
        {
            Application.Current.Shutdown();
        }

        public void Initialize()
        {
        }
    }
}
