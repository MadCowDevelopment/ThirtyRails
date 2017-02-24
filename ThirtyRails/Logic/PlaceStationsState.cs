using System.Collections.Generic;
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

            var tilesInSameLine = GetTilesInSameLine(tile).Where(p => p != tile);
            if (tile.IsStation)
            {
                tile.Number = 0;
                tilesInSameLine.ForEach(p => p.IsValidTarget = true);
            }
            else
            {
                tilesInSameLine.ForEach(p => p.IsValidTarget = false);
            }

            tile.IsStation = !tile.IsStation;
            
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
            if (tile.IsStation) return;

            tile.PreviewStation = true;

            var firstFreeNumber = 0;
            var stations = Map.StationTiles.Where(p => p.IsStation).ToList();
            for (var i = 1; i <= 4; i++)
            {
                if (stations.All(p => p.Number != i))
                {
                    firstFreeNumber = i;
                    break;
                }
            }

            tile.Number = firstFreeNumber;
        }

        protected override void OnLeave(StationTile tile)
        {
            tile.PreviewStation = false;
            if(!tile.IsStation) tile.Number = 0;
        }

        private IEnumerable<StationTile> GetTilesInSameLine(StationTile tile)
        {
            var tilesInSameLine =
                (tile.IsHorizontal ? Map.GetTilesInRow(tile.Y) : Map.GetTilesInColumn(tile.X))
                .OfType<StationTile>()
                .Where(p => p != tile);
            return tilesInSameLine;
        }
    }
}