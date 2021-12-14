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
        //private readonly IUserInterface _ui;

        //public DataFile(IUserInterface ui)
        //{
        //    _ui = ui;
        //}


        void IDataFile.Save(string userName, int numOfGuesses, string gameName)
        {
            using (StreamWriter output = new(gameName + "Highscore.txt", append: true))
            {
                output.WriteLine(userName + "-#-" + numOfGuesses);
                output.Close();
            }
        }

        List<PlayerData> IDataFile.Read(string gameName)
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
                //_ui.OutputWriteLine("The file could not be read:");
                //_ui.OutputWriteLine(e.Message);
                throw new Exception(e.Message);
            }

            return results;
        }
    }
}
