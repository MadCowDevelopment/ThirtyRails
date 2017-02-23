using System.ComponentModel.Composition;
using Caliburn.Micro;
using ThirtyRails.Screens.Game.GameBoard;
using ThirtyRails.Shell;

namespace ThirtyRails.Screens.Game
{
    [Export]
    public class GameViewModel : Screen, IViewModel
    {
        [ImportingConstructor]
        public GameViewModel(GameBoardViewModel gameBoard)
        {
            GameBoard = gameBoard;
        }

        public IViewModel GameBoard { get; private set; }

        public void Initialize()
        {
            GameBoard.Initialize();
        }
    }
}
