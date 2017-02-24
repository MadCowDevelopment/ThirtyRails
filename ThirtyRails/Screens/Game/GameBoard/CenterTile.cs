namespace ThirtyRails.Screens.Game.GameBoard
{
    public class CenterTile : Tile
    {
        public CenterTile(int id) : base(id)
        {
        }

        public bool IsMountain { get; set; }

        public bool IsMine { get; set; }

    }
}