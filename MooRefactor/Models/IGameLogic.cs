using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor.Models
{
    public interface IGameLogic
    {
        string InputGuess(int numOfGuesses, string secretNumber);
        string GetRandomNumber();
        int CheckSecretNumber(int numOfGuesses, string secretNumber, string guess);
        string CalcSecretNumber(string secretNumber, string guess);
    }
}
