using MooRefactor.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor.Models
{
    public class GuessSecretNumber : IGameLogic
    {
        private readonly IUserInterface _ui;

        public GuessSecretNumber(IUserInterface ui)
        {
            _ui = ui;
        }

        public string InputGuess(int numOfGuesses, string secretNumber)
        {
            _ui.OutputWrite("Guess #" + numOfGuesses + ": ");
            string guess = _ui.Input();
            while (!int.TryParse(guess, out _))
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
                    _ui.OutputWriteLine("Unvalid input: \"" + guess + "\". We are looking for four (4) numbers.");
                    Console.Out.Flush();
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

            return randomGenerator.Next(1, 101).ToString();
        }

        public int CheckSecretNumber(int numOfGuesses, string secretNumber, string guess)
        {
            string result = CalcSecretNumber(secretNumber, guess);

            while (result != "Correct")
            {
                numOfGuesses++;
                guess = InputGuess(numOfGuesses, secretNumber);
                result = CalcSecretNumber(secretNumber, guess);
            }

            return numOfGuesses;
        }

        public string CalcSecretNumber(string secretNumber, string guess)
        {
            int myGuess = int.Parse(guess);
            int mysecretNumber = int.Parse(secretNumber);
            string result = "noMatch";

            if (myGuess == mysecretNumber)
                return "Correct";
            else if (myGuess > mysecretNumber)
                _ui.OutputWriteLine("Too high");
            else
                _ui.OutputWriteLine("Too low");

            return result;
        }
    }
}
