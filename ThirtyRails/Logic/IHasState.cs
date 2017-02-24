namespace ThirtyRails.Screens.Game.GameBoard
{
    public interface IHasState
    {
        GameState State { get; }
        void ChangeState(GameState state);
    }
}