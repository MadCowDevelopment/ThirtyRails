namespace ThirtyRails.Logic
{
    public abstract class GameState<T> : IGameState where T : Tile
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
            var specificTile = tile as T;
            if (specificTile == null) return;
            OnClick(specificTile);
        }

        protected abstract void OnClick(T tile);

        public void Enter(Tile tile)
        {
            tile.IsMouseOver = true;
            var specificTile = tile as T;
            if (specificTile == null) return;
            OnEnter(specificTile);
        }

        protected abstract void OnEnter(T tile);

        public void Leave(Tile tile)
        {
            tile.IsMouseOver = false;
            var specificTile = tile as T;
            if (specificTile == null) return;
            OnLeave(specificTile);
        }

        protected abstract void OnLeave(T tile);
    }
}