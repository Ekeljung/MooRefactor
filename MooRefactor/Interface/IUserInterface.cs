using MooRefactor.Model;
using System.Collections.Generic;

namespace MooRefactor.Interface
{
    public interface IUserInterface
    {
        string ChooseGameUI();
        void IntroMsg(string gameName);
        string InputUserName();
        string Input();
        void OutputWriteLine(string s);
        void OutputWrite(string s);
        void GameStartText();
        void ClearScreen();
        bool Exit();
        void GoodbyeMsg();
        void ProgressBar();
        void ShowHighScoreByAverage(List<PlayerData> results, string userName);
    }
}
