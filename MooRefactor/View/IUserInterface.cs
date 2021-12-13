using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor.View
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
    }
}
