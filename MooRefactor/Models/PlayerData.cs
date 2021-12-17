using System;

namespace MooRefactor.Model
{
    public class PlayerData
    {
        public string Name { get; private set; }
        public int NGames { get; private set; }
        int totalGuess;


        public PlayerData(string name, int guesses)
        {
            Name = name;
            NGames = 1;
            totalGuess = guesses;
        }

        public void Update(int guesses)
        {
            totalGuess += guesses;
            NGames++;
        }

        public double Average() => (double)totalGuess / NGames;

        public override bool Equals(Object p) => Name.Equals(((PlayerData)p).Name);

        public override int GetHashCode() => Name.GetHashCode();
    }
}
