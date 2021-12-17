using MooRefactor.Interface;
using MooRefactor.Model;
using System;
using System.Collections.Generic;

namespace MooRefactor
{
    public class GameManager
    {
        public GameManager(IUserInterface ui, IGameLogic game, IGameLogic game2, IDataFile data)
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
        //string gameName = "";

        public void Run()
        {
            do
            {
                int numOfGuesses = 1;
                string secretNumber;

                List<PlayerData> results = new();

                _ui.ClearScreen();
                string gameName = ChooseGameUI();
                
                if (gameName == _game1.GetType().Name)
                    secretNumber = _game1.GetRandomNumber();
                else
                    secretNumber = _game2.GetRandomNumber();

                _ui.ClearScreen();
                _ui.IntroMsg(gameName);
                userName = _ui.InputUserName();
                _ui.GameStartText();

                if (gameName == _game1.GetType().Name)
                {
                    string guess = _game1.InputGuess(numOfGuesses, secretNumber);
                    numOfGuesses = _game1.CheckSecretNumber(numOfGuesses, secretNumber, guess);
                }
                else
                {
                    string guess = _game2.InputGuess(numOfGuesses, secretNumber);
                    numOfGuesses = _game2.CheckSecretNumber(numOfGuesses, secretNumber, guess);
                }

                try
                {
                    _data.Save(userName, numOfGuesses, gameName);
                }
                catch (Exception e)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    _ui.OutputWriteLine("WARNING: Something went wrong when trying to save to file.\n\"" + e.Message + "\"");
                    Console.ResetColor();
                }

                try
                {
                    results = _data.Read(gameName);
                }
                catch (Exception e)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    _ui.OutputWriteLine("WARNING: Something went wrong trying to read from file.\n\"" + e.Message + "\"");
                    Console.ResetColor();
                }

                _ui.ShowHighScoreByAverage(results, userName);
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

        string ChooseGameUI()
        {
            string gameName = "";
            _ui.OutputWriteLine("We currently have two games to play.");
            _ui.OutputWriteLine("1: Bulls & Cows [Difficult] - A fun, but tricky, game about guessing 4 random numbers position.");
            _ui.OutputWriteLine("2: Secret number [Easy] - Guess the secret number between 1-100.");
            _ui.OutputWriteLine("Q: Exit program.");

            while (gameName.Length < 1)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        gameName = _game1.GetType().Name;
                        break;
                    case ConsoleKey.D2:
                        gameName = _game2.GetType().Name;
                        break;
                    case ConsoleKey.Q:
                        _ui.GoodbyeMsg();
                        _ui.ProgressBar();
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.D0:
                        _ui.GoodbyeMsg();
                        _ui.ProgressBar();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        _ui.OutputWriteLine("Unvalid input. Try pressing one of the numbered choices above.");
                        Console.ResetColor();
                        break;
                }
            }

            return gameName;
        }
    }
}
