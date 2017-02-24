using System.Linq;
using ThirtyRails.Utils;

namespace ThirtyRails.Screens.Game.GameBoard
{
    public class PlaceMineState : GameState
    {
        public PlaceMineState(IHasState gameLogic, Map map) : base(gameLogic, map)
        {
            Map.CenterTiles.ForEach(p => p.CanHighlight = true);
            Map.CenterTiles.Where(p => p.IsMountain)
                .SelectMany(p => Map.GetAdjacentTiles(p))
                .OfType<CenterTile>()
                .Where(p => !p.IsMountain)
                .ForEach(p => p.IsValidTarget = true);
        }

        protected override void OnClick(Tile tile)
        {
            if (!tile.IsValidTarget) return;

            tile.IsValidTarget = false;
            Map.Tiles.ForEach(p =>
            {
                p.IsValidTarget = false;
                p.CanHighlight = false;
            });

            State.ChangeState(new PlaceStationsState(State, Map));
        }

        protected override void OnEnter(Tile tile)
        {
            var centerTile = tile as CenterTile;
            if (centerTile == null) return;

            if (centerTile.IsValidTarget) centerTile.IsMine = true;
        }

        protected override void OnLeave(Tile tile)
        {
            var centerTile = tile as CenterTile;
            if (centerTile == null) return;

            centerTile.IsMine = false;
        }
    }
}