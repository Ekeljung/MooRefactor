using MooRefactor.Interface;
using MooRefactor.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MooRefactor.View
{
    public class ConsoleIO : IUserInterface
    {
        void IUserInterface.IntroMsg(string gameName)
        {
            if (gameName == "MooGame")
            {
                OutputWriteLine("\n" +
    "   /$$$$$$$            /$$ /$$                  /$$$            /$$$$$$                                   \n" +
    "  | $$__  $$          | $$| $$                 /$$ $$          /$$__  $$                                  \n" +
    "  | $$  \\ $$ /$$   /$$| $$| $$  /$$$$$$$      |  $$$          | $$  \\__ /  /$$$$$$  /$$  /$$  /$$  /$$$$$$$ \n" +
    "  | $$$$$$$ | $$  | $$| $$| $$ /$$_____/       /$$ $$/$$      | $$       /$$__  $$| $$ | $$ | $$ /$$_____ /\n" +
    "  | $$__  $$| $$  | $$| $$| $$|  $$$$$$       | $$  $$_/      | $$      | $$  \\ $$| $$ | $$ | $$|  $$$$$$ \n" +
    "  | $$  \\ $$| $$  | $$| $$| $$ \\____  $$      | $$\\  $$       | $$    $$| $$  | $$| $$ | $$ | $$ \\____  $$\n" +
    "  | $$$$$$$/|  $$$$$$/| $$| $$ /$$$$$$$/      |  $$$$/$$      |  $$$$$$/|  $$$$$$/|  $$$$$/$$$$/ /$$$$$$$/\n" +
    "  |_______/  \\______/ |__/|__/|_______/        \\____/\\_/       \\______/  \\______/  \\_____/\\___/ |_______/ \n");

                OutputWriteLine("Hi, and welcome to Bulls and Cows!");
                OutputWriteLine("Rules: If the four (4) matching digits are in their right positions, they are \"bulls\" (\"B\"), \n" +
                    "       if in different positions, they are \"cows\" (\"C\").\n");
            }
            else
            {
                OutputWriteLine("\n" +
    "  $$\\   $$\\                         $$\\                                     $$\\ \n" +
    "  $$$\\  $$ |                        $$ |                                    $$ | \n" +
    "  $$$$\\ $$ |$$\\   $$\\ $$$$$$\\$$$$\\  $$$$$$$\\   $$$$$$\\   $$$$$$\\   $$$$$$$\\ $$ |  \n" +
    "  $$ $$\\$$ |$$ |  $$ |$$  _$$  _$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\ $$  _____|$$ |  \n" +
    "  $$ \\$$$$ |$$ |  $$ |$$ / $$ / $$ |$$ |  $$ |$$$$$$$$ |$$ |  \\__|\\$$$$$$\\  \\__|  \n" +
    "  $$ |\\$$$ |$$ |  $$ |$$ | $$ | $$ |$$ |  $$ |$$   ____|$$ |       \\____$$\\  \n" +
    "  $$ | \\$$ |\\$$$$$$  |$$ | $$ | $$ |$$$$$$$  |\\$$$$$$$\\ $$ |      $$$$$$$  |$$\\ \n" +
    "  \\__|  \\__| \\______/ \\__| \\__| \\__|\\_______/  \\_______|\\__|      \\_______/ \\__| \n");


                OutputWriteLine("Hi, and welcome to this number guessing game!");
                OutputWriteLine("Rules: Guess a number between 0 and 100. The game will tell you if your guess is too high\n" +
                    "       or too low. Try to get as few guesses as possible. There is a highscore!\n");
            }
        }

        public string Input() => Console.ReadLine().Trim();

        public string InputUserName()
        {
            OutputWrite("Start game by entering your username: ");

            Console.ForegroundColor = ConsoleColor.Green;
            string userName = Input();
            Console.ResetColor();

            return userName;
        }

        public void OutputWriteLine(string s) => Console.WriteLine(s);

        public void OutputWrite(string s) => Console.Write(s);

        void IUserInterface.GameStartText() => OutputWriteLine("\n~'~ Press [H] to see the secret number ~'~\n" +
                                                                "~'~ New game started. Make your guess ~'~");

        void IUserInterface.ClearScreen() => Console.Clear();

        bool IUserInterface.Exit() => Console.ReadKey(true).Key == ConsoleKey.Y;

        public void GoodbyeMsg()
        {
            string goodbye = "\nThanks for playing!";
            string goodbye2 = "\nThe program will now close.";

            char[] arr1;
            arr1 = goodbye.ToCharArray();

            char[] arr2;
            arr2 = goodbye2.ToCharArray();

            foreach (var s in arr1)
            {
                OutputWrite(s.ToString());
                Thread.Sleep(50);
            }

            Thread.Sleep(150);

            foreach (var s in arr2)
            {
                OutputWrite(s.ToString());
                Thread.Sleep(50);
            }

            OutputWriteLine("");
        }

        public void ProgressBar()
        {
            using var progress = new ProgressBar();

            for (int i = 0; i <= 100; i++)
            {
                progress.Report((double)i / 100);
                Thread.Sleep(20);
            }
        }

        void IUserInterface.ShowHighScoreByAverage(List<PlayerData> results, string userName)
        {
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

            OutputWrite("\n=========");
            Console.ForegroundColor = ConsoleColor.Yellow;
            OutputWrite("LEADERBOARD");
            Console.ResetColor();
            OutputWriteLine("=========\nPlayer      Games     Average\n=============================");

            foreach (var p in results)
            {
                if (p.Name == userName)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    OutputWriteLine(string.Format("{0,-10}{1,7:D}{2,12:F2}", p.Name, p.NGames, p.Average()));
                    Console.ResetColor();
                }
                else
                {
                    OutputWriteLine(string.Format("{0,-10}{1,7:D}{2,12:F2}", p.Name, p.NGames, p.Average()));
                }
            }
        }
    }
}
