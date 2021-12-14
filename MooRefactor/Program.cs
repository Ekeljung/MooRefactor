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
            IGameLogic game = new MooGame(ui);
            IGameLogic game2 = new GuessSecretNumber(ui);
            //Modify ConsoleIO.ChooseGameUI(), gameName-property and if statements in GameController when adding/changing games.

            GameController controller = new(ui, game, game2, data);
            controller.Run();
        }
    }
}
