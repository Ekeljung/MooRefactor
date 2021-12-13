using MooRefactor.Models;
using MooRefactor.Repository;
using MooRefactor.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor.Controller
{
    public class GameController
    {
        public GameController(IUserInterface ui, IGameLogic game, IGameLogic game2, IDataFile data)
        {
            _ui = ui;
            _game1 = game;
            _game2 = game2;
            _data = data;
        }

        private readonly IUserInterface _ui;
        private readonly IGameLogic _game1;
        private readonly IGameLogic _game2;
        private readonly IDataFile _data;

        bool playGame = true;
        string userName = "";
        string gameName = "";

        public void Run()
        {
            //const int COUNT = 100000;
            //HashSet<int> hashSetOfInts = new HashSet<int>();
            //Stopwatch stopWatch = new Stopwatch();
            //for (int i = 0; i < COUNT; i++)
            //{
            //    hashSetOfInts.Add(i);
            //}

            //stopWatch.Start();
            //for (int i = 0; i < COUNT; i++)
            //{
            //    hashSetOfInts.Contains(i);
            //}
            //stopWatch.Stop();

            //Console.WriteLine(stopWatch.Elapsed);

            //stopWatch.Reset();
            //List<int> listOfInts = new List<int>();
            //for (int i = 0; i < COUNT; i++)
            //{
            //    listOfInts.Add(i);
            //}

            //stopWatch.Start();
            //for (int i = 0; i < COUNT; i++)
            //{
            //    listOfInts.Contains(i);
            //}
            //stopWatch.Stop();

            //Console.WriteLine(stopWatch.Elapsed);
            //Console.Read();
            //Console.ReadLine();

            do
            {
                int numOfGuesses = 1;
                string secretNumber;

                _ui.ClearScreen();
                gameName = _ui.ChooseGameUI();
                if (gameName == "CowsAndBulls")
                {
                    secretNumber = _game1.GetRandomNumber();
                }
                else
                {
                    secretNumber = _game2.GetRandomNumber();
                }

                _ui.ClearScreen();
                _ui.IntroMsg(gameName);

                userName = _ui.InputUserName();
                //PlayerData pd = new(userName, numOfGuesses);
                _ui.GameStartText();

                if (gameName == "CowsAndBulls")
                {
                    string guess = _game1.InputGuess(numOfGuesses, secretNumber);
                    numOfGuesses = _game1.CheckSecretNumber(numOfGuesses, secretNumber, guess);
                }
                else
                {
                    string guess = _game2.InputGuess(numOfGuesses, secretNumber);
                    numOfGuesses = _game2.CheckSecretNumber(numOfGuesses, secretNumber, guess);
                }

                _data.Save(userName, numOfGuesses, gameName);
                _data.HighscoreByAverage(gameName);

                _ui.OutputWriteLine("Correct, it took " + numOfGuesses + (numOfGuesses > 1 ? " guesses." : " guess.") + 
                    "\n\nPress [Y]es to play some more or any other key to exit the program.");

                playGame = _ui.Exit();
                if (!playGame)
                {
                    _ui.GoodbyeMsg();
                    _ui.ProgressBar();
                }

            } while (playGame);
        }
    }
}
