namespace ThirtyRails.Logic
{
    public interface IHasState
    {
        IGameState State { get; }
        void ChangeState(IGameState state);
    }
}