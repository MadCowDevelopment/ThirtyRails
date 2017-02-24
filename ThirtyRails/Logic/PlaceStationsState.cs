using System.Linq;
using ThirtyRails.Utils;

namespace ThirtyRails.Logic
{
    public class PlaceStationsState : GameState<StationTile>
    {
        public PlaceStationsState(IHasState state, Map map) : base(state, map)
        {
            Map.StationTiles.ForEach(p =>
            {
                p.CanHighlight = true;
                p.IsValidTarget = true;
            });
        }

        protected override void OnClick(StationTile tile)
        {
            if (!tile.IsValidTarget) return;

            tile.IsStation = !tile.IsStation;

            if (tile.IsStation)
            {
                var tilesInSameLine =
                    (tile.IsHorizontal ? Map.GetTilesInRow(tile.Y) : Map.GetTilesInColumn(tile.X))
                    .OfType<StationTile>()
                    .Where(p => p != tile);
                tilesInSameLine.ForEach(p => p.IsStation = false);
            }

            if (Map.StationTiles.Count(p => p.IsStation) == 4)
            {
                Map.StationTiles.ForEach(p =>
                {
                    p.PreviewStation = false;
                    p.IsValidTarget = false;
                });
                State.ChangeState(new PlaceMineState(State, Map));
            }
        }

        protected override void OnEnter(StationTile tile)
        {
            if (!tile.IsValidTarget) return;
            tile.PreviewStation = true;
        }

        protected override void OnLeave(StationTile tile)
        {
            tile.PreviewStation = false;
        }
    }
}