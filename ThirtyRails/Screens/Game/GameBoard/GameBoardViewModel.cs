using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Hextasy.Framework;
using ThirtyRails.Shell;
using ThirtyRails.Utils;

namespace ThirtyRails.Screens.Game.GameBoard
{
    [Export(typeof(GameBoardViewModel))]
    public class GameBoardViewModel : ViewModel
    {
        private readonly Map _map;

        public GameBoardViewModel()
        {
            _map = new Map();

        }

        public IEnumerable<PlaceableTile> Tiles => _map.Tiles;

        public override void Initialize()
        {
            var adjacentTiles = new List<PlaceableTile>();

            for (var y = 0; y < 6; y++)
            {
                var tile = _map.GetTile(RNG.Next(0, 5), y);
                tile.IsMountain = true;
                adjacentTiles.AddRangeDistinct(_map.GetAdjacentTiles(tile));
            }

            adjacentTiles.ForEach(p => p.IsValidTarget = true);
        }
    }

    public class Map : PropertyChangedBase
    {
        private readonly List<PlaceableTile> _tiles;

        public Map()
        {
            _tiles = new List<PlaceableTile>();
            for (int i = 0; i < 36; i++)
            {
                _tiles.Add(new PlaceableTile(i));
            }
        }

        public IEnumerable<PlaceableTile> Tiles => _tiles;

        public List<PlaceableTile> GetAdjacentTiles(PlaceableTile tile)
        {
            var adjacentTiles = new List<PlaceableTile>();
            adjacentTiles.AddNotNull(GetTile(tile.X, tile.Y - 1));
            adjacentTiles.AddNotNull(GetTile(tile.X, tile.Y + 1));
            adjacentTiles.AddNotNull(GetTile(tile.X - 1, tile.Y));
            adjacentTiles.AddNotNull(GetTile(tile.X + 1, tile.Y));

            return adjacentTiles;
        }

        public PlaceableTile GetTile(int x, int y)
        {
            return _tiles.FirstOrDefault(p => p.X == x && p.Y == y);
        }

        public int IndexOf(PlaceableTile tile)
        {
            return _tiles.IndexOf(tile);
        }
    }

    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class PlaceableTile : PropertyChangedBase
    {
        public PlaceableTile(int id)
        {
            X = id % 6;
            Y = id / 6;
        }

        public int Y { get; set; }

        public int X { get; set; }

        public bool IsMountain { get; set; }

        public bool IsValidTarget { get; set; }

    }
}
