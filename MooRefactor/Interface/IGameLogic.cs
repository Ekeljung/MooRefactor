namespace MooRefactor.Interface
{
    public interface IGameLogic
    {
        string InputGuess(int numOfGuesses, string secretNumber);
        string GetRandomNumber();
        int CheckSecretNumber(int numOfGuesses, string secretNumber, string guess);
        string CalcSecretNumber(string secretNumber, string guess);
    }
}
