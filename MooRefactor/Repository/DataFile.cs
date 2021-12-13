using MooRefactor.Models;
using MooRefactor.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor.Repository
{
    public class DataFile : IDataFile
    {
        private readonly IUserInterface _ui;

        public DataFile(IUserInterface ui)
        {
            this._ui = ui;
        }


        public void Save(string userName, int numOfGuesses, string gameName)
        {
            using (StreamWriter output = new(gameName + "Highscore.txt", append: true))
            {
                output.WriteLine(userName + "-#-" + numOfGuesses);
                output.Close();
            }
        }

        public void HighscoreByAverage(string gameName)
        {
            List<PlayerData> results = new();
            string line;
            string name = "";

            try
            {
                using (StreamReader sr = new(gameName + "Highscore.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] nameAndScore = line.Split(new string[] { "-#-" }, StringSplitOptions.None);
                        name = nameAndScore[0];
                        int guesses = Convert.ToInt32(nameAndScore[1]);
                        PlayerData player = new(name, guesses);

                        int pos = results.IndexOf(player);
                        if (pos < 0)
                            results.Add(player);
                        else
                            results[pos].Update(guesses);
                    }
                }
            }
            catch (Exception e)
            {
                _ui.OutputWriteLine("The file could not be read:");
                _ui.OutputWriteLine(e.Message);
            }

            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

            _ui.OutputWrite("\n=========");
            Console.ForegroundColor = ConsoleColor.Yellow;
            _ui.OutputWrite("LEADERBOARD");
            Console.ResetColor();
            _ui.OutputWriteLine("=========\nPlayer      Games     Average\n=============================");

            foreach (var p in results)
            {
                if (p.Name == name)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    _ui.OutputWriteLine(string.Format("{0,-10}{1,7:D}{2,12:F2}", p.Name, p.NGames, p.Average()));
                    Console.ResetColor();
                }
                else
                {
                    _ui.OutputWriteLine(string.Format("{0,-10}{1,7:D}{2,12:F2}", p.Name, p.NGames, p.Average()));
                }
            }
        }
    }
}
