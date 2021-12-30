using MooRefactor.Data;
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
            
            /*Modify: 
             * GameManager.ChooseGameUI() 
             *          This is the where you choose what game to play. Add your game and make a new switch statement for it.
             * 
             * ConsoleIO.IntroMsg()
             *          If you want a more nicely looking "welcome message" when you start you game, 
             *          change the if/else statement here. */

            GameManager controller = new(ui, game, game2, data);
            controller.Run();
        }
    }
}
