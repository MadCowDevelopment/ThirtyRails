using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using ThirtyRails.Utils;

namespace ThirtyRails.Screens.Game.GameBoard
{
    public class Map : PropertyChangedBase
    {
        private readonly List<Tile> _tiles;

        public Map()
        {
            _tiles = new List<Tile>();
            for (int i = 0; i < 36; i++)
            {
                _tiles.Add(new Tile(i));
            }
        }

        public IEnumerable<Tile> Tiles => _tiles;

        public List<Tile> GetAdjacentTiles(Tile tile)
        {
            var adjacentTiles = new List<Tile>();
            adjacentTiles.AddNotNull(GetTile(tile.X, tile.Y - 1));
            adjacentTiles.AddNotNull(GetTile(tile.X, tile.Y + 1));
            adjacentTiles.AddNotNull(GetTile(tile.X - 1, tile.Y));
            adjacentTiles.AddNotNull(GetTile(tile.X + 1, tile.Y));

            return adjacentTiles;
        }

        public Tile GetTile(int x, int y)
        {
            return _tiles.FirstOrDefault(p => p.X == x && p.Y == y);
        }

        public int IndexOf(Tile tile)
        {
            return _tiles.IndexOf(tile);
        }
    }
}