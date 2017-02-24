using System.Linq;
using ThirtyRails.Utils;

namespace ThirtyRails.Logic
{
    public class PlaceMineState : GameState<CenterTile>
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

        protected override void OnClick(CenterTile tile)
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

        protected override void OnEnter(CenterTile tile)
        {
            if (tile.IsValidTarget) tile.IsMine = true;
        }

        protected override void OnLeave(CenterTile tile)
        {
            tile.IsMine = false;
        }
    }
}