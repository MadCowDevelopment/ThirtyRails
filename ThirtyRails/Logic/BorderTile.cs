namespace ThirtyRails.Logic
{
    public class BorderTile : Tile
    {
        public BorderTile(int id) : base(id)
        {
        }

    }

    public class StationTile : Tile
    {
        public StationTile(int id) : base(id)
        {
        }

        public bool IsStation { get; set; }
    }
}