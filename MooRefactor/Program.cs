using MooRefactor.Controller;
using MooRefactor.Models;
using MooRefactor.Repository;
using MooRefactor.View;
using System;

namespace MooRefactor
{
    class Program
    {
        static void Main()
        {
            IUserInterface ui = new ConsoleIO();
            IDataFile data = new DataFile();
            IGameLogic game = new MooGame();
            IGameLogic game2 = new GuessSecretNumber();
            //Modify ConsoleIO.ChooseGameUI(), gameName-property and if statements in GameController when adding/changing games.

            GameController controller = new(ui, game, game2, data);
            controller.Run();
        }
    }
}
