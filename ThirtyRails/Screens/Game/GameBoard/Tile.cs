using Caliburn.Micro;

namespace ThirtyRails.Screens.Game.GameBoard
{
    public class Tile : PropertyChangedBase
    {
        public Tile(int id)
        {
            X = id % 6;
            Y = id / 6;
        }

        public int Y { get; set; }

        public int X { get; set; }

        public bool IsMountain { get; set; }

        public bool IsValidTarget { get; set; }
        public bool IsMine { get; set; }
        public bool IsMouseOver { get; set; }
    }
}