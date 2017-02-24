using System.Collections.Generic;
using System.Linq;
using Hextasy.Framework;
using ThirtyRails.Utils;

namespace ThirtyRails.Screens.Game.GameBoard
{
    public class GameLogic : IHasState
    {
        private readonly Map _map;

        private GameState _currentState;

        public GameLogic(Map map)
        {
            _map = map;

            _currentState = new PlaceMineState(this, _map);
        }

        public void Initialize()
        { 
        }

        public void ClickTile(Tile tile)
        {
            _currentState.Click(tile);
        }

         public void EnterTile(Tile tile)
        {
            _currentState.Enter(tile);
        }

        public void LeaveTile(Tile tile)
        {
            _currentState.Leave(tile);
        }

        public GameState State => _currentState;

        public void ChangeState(GameState state)
        {
            _currentState = state;
        }
    }
}