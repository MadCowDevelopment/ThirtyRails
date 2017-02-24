using Caliburn.Micro;

namespace ThirtyRails.Screens.Game.GameBoard
{
    public abstract class Tile : PropertyChangedBase
    {
        protected Tile(int id)
        {
            X = id % 8;
            Y = id / 8;
        }

        public int Y { get; set; }

        public int X { get; set; }
        public bool IsMouseOver { get; set; }
        public bool CanHighlight { get; set; }
        public bool IsValidTarget { get; set; }

        public override string ToString()
        {
            return $"[{X};{Y}] - {GetType()}";
        }
    }
}