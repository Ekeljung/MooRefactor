using MooRefactor.Model;
using MooRefactor.Interface;
using System;
using System.Collections.Generic;
using System.IO;

namespace MooRefactor.DAL
{
    public class DataFile : IDataFile
    {
        void IDataFile.Save(string userName, int numOfGuesses, string gameName)
        {
            using (StreamWriter output = new(gameName + "Highscore.txt", append: true))
            {
                output.WriteLine(userName + "-#-" + numOfGuesses);
            }
        }

        List<PlayerData> IDataFile.Read(string gameName)
        {
            List<PlayerData> results = new();
            string line;

            try
            {
                using (StreamReader sr = new(gameName + "Highscore.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] nameAndScore = line.Split(new string[] { "-#-" }, StringSplitOptions.None);
                        string name = nameAndScore[0];
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
                throw new Exception(e.Message);
            }

            return results;
        }
    }
}
