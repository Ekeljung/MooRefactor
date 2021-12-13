using MooRefactor.Models;
using MooRefactor.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    public class MooGame : IGameLogic
    {
        private readonly IUserInterface _ui;

        public MooGame(IUserInterface ui)
        {
            this._ui = ui;
        }

        public string InputGuess(int numOfGuesses, string secretNumber)
        {
            _ui.OutputWrite("Guess #" + numOfGuesses + ": ");
            string guess = _ui.Input();

            while (!int.TryParse(guess, out _) || (guess.Length != 4))
            {
                if (guess.ToUpper() == "H")
                {
                    _ui.OutputWrite("The secret number is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    _ui.OutputWriteLine(secretNumber);
                    Console.ResetColor();

                    _ui.OutputWrite("Guess #" + numOfGuesses + ": ");
                    guess = _ui.Input();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    _ui.OutputWriteLine("Unvalid input: \"" + guess + "\". We are looking for four (4) unique numbers.");
                    Console.ResetColor();

                    _ui.OutputWrite("Guess #" + numOfGuesses + ": ");
                    guess = _ui.Input();
                }
            }

            return guess;
        }

        public string GetRandomNumber()
        {
            Random randomGenerator = new();
            string goal = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomNumber = "" + random;

                while (goal.Contains(randomNumber))
                {
                    random = randomGenerator.Next(10);
                    randomNumber = "" + random;
                }

                goal += randomNumber;
            }
            return goal;
        }

        public int CheckSecretNumber(int numOfGuesses, string secretNumber, string guess)
        {
            string bbcc = CalcSecretNumber(secretNumber, guess);

            while (bbcc != "BBBB,")
            {
                numOfGuesses++;
                guess = InputGuess(numOfGuesses, secretNumber);
                bbcc = CalcSecretNumber(secretNumber, guess);
            }

            return numOfGuesses;
        }

        public string CalcSecretNumber(string secretNumber, string guess)
        {
            int cows = 0, bulls = 0;
            //guess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (secretNumber[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }

            string bbcc = "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
            _ui.OutputWriteLine(bbcc);

            return bbcc;
        }
    }
}
