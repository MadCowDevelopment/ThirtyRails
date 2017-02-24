using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using ThirtyRails.Logic;
using ThirtyRails.Shell;

namespace ThirtyRails.Screens.Game.GameBoard
{
    [Export(typeof(GameBoardViewModel))]
    public class GameBoardViewModel : ViewModel
    {
        private readonly Map _map;
        private readonly GameLogic _gameLogic;

        public GameBoardViewModel()
        {
            _map = new Map();
            _gameLogic = new GameLogic(_map);
        }

        public IEnumerable<Tile> Tiles => _map.Tiles;

        public override void Initialize()
        {
            _gameLogic.Initialize();
        }

        public void OnTileClick(Tile tile)
        {
            _gameLogic.ClickTile(tile);
        }

        public void OnTileEnter(Tile tile)
        {
            _gameLogic.EnterTile(tile);
        }
        public void OnTileLeave(Tile tile)
        {
            _gameLogic.LeaveTile(tile);
        }
    }
}
