using MooRefactor.Model;
using System.Collections.Generic;

namespace MooRefactor.Interface
{
    public interface IDataFile
    {
        void Save(string userName, int numOfGuesses, string gameName);
        public List<PlayerData> Read(string gameName);
    }
}
