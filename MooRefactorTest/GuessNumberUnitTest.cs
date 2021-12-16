using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooRefactor.Games;
using System;

namespace MooRefactorTest
{
    [TestClass]
    public class GuessNumberUnitTest
    {
        GuessSecretNumber guessSecretNumberGame;

        string testSecretNumber = "12";
        string guess = "";
        string result = "";

        [TestInitialize]
        public void InitTest()
        {
            guessSecretNumberGame = new();
        }


        [TestMethod]
        public void GetRandomNumber1to100Test()
        {
            bool number = false;
            string numb = guessSecretNumberGame.GetRandomNumber();
            int myIntNumb = Convert.ToInt32(numb);

            if (myIntNumb >= 1 && myIntNumb < 101)
                number = true;

            Assert.IsTrue(number);
        }

        [TestMethod]
        public void CalcSecretNumber1to100TooLowTest()
        {
            guess = "11";

            string numb = guessSecretNumberGame.CalcSecretNumber(testSecretNumber, guess);
            Assert.AreEqual("noMatch", numb);
        }

        [TestMethod]
        public void CalcSecretNumber1to100TooHighTest()
        {
            guess = "13";

            string numb = guessSecretNumberGame.CalcSecretNumber(testSecretNumber, guess);
            Assert.AreEqual("noMatch", numb);
        }

        [TestMethod]
        public void CalcSecretNumber1to100CorrectTest()
        {
            guess = "12";

            string numb = guessSecretNumberGame.CalcSecretNumber(testSecretNumber, guess);
            Assert.AreEqual("Correct", numb);
        }
    }
}
