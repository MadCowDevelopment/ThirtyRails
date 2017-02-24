namespace ThirtyRails.Screens.Game.GameBoard
{
    public abstract class GameState
    {
        protected IHasState State { get; }
        protected Map Map { get; }

        protected GameState(IHasState state, Map map)
        {
            State = state;
            Map = map;
        }

        public void Click(Tile tile)
        {
            OnClick(tile);
        }

        protected abstract void OnClick(Tile tile);

        public void Enter(Tile tile)
        {
            tile.IsMouseOver = true;
            OnEnter(tile);
        }

        protected abstract void OnEnter(Tile tile);

        public void Leave(Tile tile)
        {
            tile.IsMouseOver = false;
            OnLeave(tile);
        }

        protected abstract void OnLeave(Tile tile);
    }
}