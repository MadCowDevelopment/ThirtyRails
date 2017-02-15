using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace ThirtyRails
{
    [Export(typeof(IMainWindowViewModel))]
    public class MainWindowViewModel : Screen, IMainWindowViewModel
    {
        public override string DisplayName { get; set; } = "30 Rails";
    }
}