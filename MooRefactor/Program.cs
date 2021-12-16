﻿using MooRefactor.DAL;
using MooRefactor.Games;
using MooRefactor.Interface;
using MooRefactor.View;

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
            //Modify GameManager.ChooseGameUI() and ConsoleIO.IntroMsg to present correct game names in UI.

            GameManager controller = new(ui, game, game2, data);
            controller.Run();
        }
    }
}
