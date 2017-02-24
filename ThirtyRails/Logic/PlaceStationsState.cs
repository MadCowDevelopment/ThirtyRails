using ThirtyRails.Utils;

namespace ThirtyRails.Logic
{
    public class PlaceStationsState : GameState<BorderTile>
    {
        public PlaceStationsState(IHasState state, Map map) : base(state, map)
        {
            Map.BorderTiles.ForEach(p =>
            {
                p.CanHighlight = true;
                p.IsValidTarget = true;
            });
        }

        protected override void OnClick(BorderTile tile)
        {
        }

        protected override void OnEnter(BorderTile tile)
        {
        }

        protected override void OnLeave(BorderTile tile)
        {
        }
    }
}