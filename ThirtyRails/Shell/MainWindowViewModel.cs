using System.ComponentModel.Composition;
using Caliburn.Micro;
using ThirtyRails.Screens.MainMenu;

namespace ThirtyRails.Shell
{
    [Export(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : ViewModel 
    {
        private readonly IWindowManager _windowManager;

        private readonly MainMenuViewModel _mainMenuViewModel;

        [ImportingConstructor]
        public MainWindowViewModel(IWindowManager windowManager, MainMenuViewModel mainMenuViewModel)
        {
            _windowManager = windowManager;
            _mainMenuViewModel = mainMenuViewModel;

            MainContent = _mainMenuViewModel;
        }
        public override string DisplayName { get; set; } = "30 Rails";

        public IViewModel MainContent { get; set; }
    }
}