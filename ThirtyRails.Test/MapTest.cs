using System.Collections.Generic;
using System.Linq;
using ThirtyRails.Screens.Game.GameBoard;
using Xunit;

namespace ThirtyRails.Test
{
    public class MapTest
    {
        private readonly Map _map;

        public MapTest()
        {
            _map = new Map();
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 7)]
        [InlineData(2, 2, 14)]
        [InlineData(4, 4, 28)]
        [InlineData(5, 5, 35)]
        [InlineData(0, 5, 30)]
        [InlineData(5, 0, 5)]
        public void GetTileReturnsCorrectTile(int x, int y, int expectedIndex)
        {
            var tile = _map.GetTile(x, y);
            var actualIndex = _map.IndexOf(tile);
            Assert.Equal(expectedIndex, actualIndex);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(0, 5)]
        [InlineData(5, 0)]
        public void GetCoordsReturnsCorrectPoint(int x, int y)
        {
            var tile = _map.GetTile(x, y);
            Assert.Equal(x, tile.X);
            Assert.Equal(y, tile.Y);
        }

        [Theory]
        [InlineData(0, 0, 0, 1, 1, 0)]
        [InlineData(5, 0, 4, 0, 5, 1)]
        [InlineData(0, 5, 0, 4, 1, 5)]
        [InlineData(5, 5, 5, 4, 4, 5)]
        [InlineData(1, 1, 0, 1, 1, 0, 2, 1, 1, 2)]
        public void GetAdjacentTilesReturnCorrectTiles(int x, int y, params int[] adjacentCoords)
        {
            var tile = _map.GetTile(x, y);
            var adjacentTiles = _map.GetAdjacentTiles(tile);

            var expectedCoords = new List<Point>();
            for (var i = 0; i < adjacentCoords.Length - 1; i+=2)
            {
                expectedCoords.Add(new Point(adjacentCoords[i], adjacentCoords[i + 1]));
            }

            Assert.Equal(expectedCoords.Count, adjacentTiles.Count);
            foreach (var expectedCoord in expectedCoords)
            {
                Assert.True(
                    adjacentTiles.Any(
                        p => p.X == expectedCoord.X && p.Y == expectedCoord.Y));
            }
        }
    }
}
