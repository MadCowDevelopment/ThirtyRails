using Caliburn.Micro;

namespace ThirtyRails.Shell
{
    public interface IViewModel<in T> : IViewModel
    {
        void Initialize(T initObject);
    }

    public interface IViewModel : IScreen
    {
        void Initialize();
    }
}
