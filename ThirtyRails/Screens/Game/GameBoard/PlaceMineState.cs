using ThirtyRails.Utils;

namespace ThirtyRails.Screens.Game.GameBoard
{
    public class PlaceMineState : GameState
    {
        public PlaceMineState(IHasState gameLogic, Map map) : base(gameLogic, map)
        {
        }

        protected override void OnClick(Tile tile)
        {
            if (!tile.IsValidTarget) return;

            tile.IsValidTarget = false;
            Map.Tiles.ForEach(p => p.IsValidTarget = false);

            State.ChangeState(new PlaceStationsState(State, Map));
        }

        protected override void OnEnter(Tile tile)
        {
            if (tile.IsValidTarget) tile.IsMine = true;
        }

        protected override void OnLeave(Tile tile)
        {
            tile.IsMine = false;
        }
    }
}