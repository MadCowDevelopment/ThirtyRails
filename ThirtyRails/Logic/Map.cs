using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Hextasy.Framework;
using ThirtyRails.Utils;

namespace ThirtyRails.Screens.Game.GameBoard
{
    public class Map : PropertyChangedBase
    {
        private readonly List<Tile> _tiles;

        public Map()
        {
            _tiles = new List<Tile>();

            int id;
            for (id = 0; id < 8; id++)
            {
                _tiles.Add(new BorderTile(id));
            }
            
            for (id = 8; id < 56; id++)
            {
                if (id % 8 == 0 || id % 8 == 7) _tiles.Add(new BorderTile(id));
                else _tiles.Add(new CenterTile(id));
            }

            for (id = 56; id < 64; id++)
            {
                _tiles.Add(new BorderTile(id));
            }

            for (var y = 0; y < 6; y++)
            {
                var tile = GetCenterTile(RNG.Next(0, 5), y);
                tile.IsMountain = true;
            }
        }

        public IEnumerable<Tile> Tiles => _tiles;

        public IEnumerable<CenterTile> CenterTiles => _tiles.OfType<CenterTile>();

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

        public CenterTile GetCenterTile(int x, int y)
        {
            return GetTile(x + 1, y + 1) as CenterTile;
        }
    }
}