namespace ThirtyRails.Logic
{
    public interface IGameState
    {
        void Click(Tile tile);
        void Enter(Tile tile);
        void Leave(Tile tile);
    }
}