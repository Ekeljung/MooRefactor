using MooRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor.Repository
{
    public interface IDataFile
    {
        void Save(string userName, int numOfGuesses, string gameName);
        void HighscoreByAverage(string gameName);
    }
}
