using Caliburn.Micro;

namespace ThirtyRails.Shell
{
    public abstract class ViewModel<T> : ViewModel, IViewModel<T>
    {
        public virtual void Initialize(T initObject)
        {
        }
    }

    public abstract class ViewModel : Screen, IViewModel
    {
        public virtual void Initialize()
        {
        }
    }
}