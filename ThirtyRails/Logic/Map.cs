﻿using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Hextasy.Framework;
using ThirtyRails.Utils;

namespace ThirtyRails.Logic
{
    public class Map : PropertyChangedBase
    {
        private readonly List<Tile> _tiles;

        public Map()
        {
            _tiles = new List<Tile>();

            int id;
            _tiles.Add(new BorderTile(0));
            for (id = 1; id < 7; id++)
            {
                _tiles.Add(new StationTile(id));
            }
            _tiles.Add(new BorderTile(7));

            for (id = 8; id < 56; id++)
            {
                if (id % 8 == 0 || id % 8 == 7) _tiles.Add(new StationTile(id));
                else _tiles.Add(new CenterTile(id));
            }

            _tiles.Add(new BorderTile(56));
            for (id = 57; id < 63; id++)
            {
                _tiles.Add(new StationTile(id));
            }
            _tiles.Add(new BorderTile(63));

            for (var y = 0; y < 6; y++)
            {
                var tile = GetCenterTile(RNG.Next(0, 5), y);
                tile.IsMountain = true;
            }
        }

        public IEnumerable<Tile> Tiles => _tiles;

        public IEnumerable<CenterTile> CenterTiles => _tiles.OfType<CenterTile>();
        public IEnumerable<StationTile> StationTiles => _tiles.OfType<StationTile>();

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

        private CenterTile GetCenterTile(int x, int y)
        {
            return GetTile(x + 1, y + 1) as CenterTile;
        }

        public IEnumerable<Tile> GetTilesInRow(int y)
        {
            return Tiles.Where(p => p.Y == y);
        }

        public IEnumerable<Tile> GetTilesInColumn(int x)
        {
            return Tiles.Where(p => p.X == x);
        }
    }
}