using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooRefactor;
using MooRefactor.Controller;
using MooRefactor.Models;
using MooRefactor.View;
using System;

namespace MooRefactorTest
{
    [TestClass]
    public class UnitTest
    {
        GameController controller;
        MooGame mooGame;
        GuessSecretNumber guessSecretNumberGame;
        ConsoleIO ui;

        string secretNumber = "1234";
        string testSecretNumber = "";
        string guess = "";
        string result = "";
        int numOfGuesses = 1;

        [TestInitialize]
        public void TestInit()
        {
            controller = new();
            mooGame = new();
            guessSecretNumberGame = new();
            ui = new();
        }

        [TestMethod]
        public void TestGetRandomNumber1to100()
        {
            bool number = false;
            string numb = guessSecretNumberGame.GetRandomNumber();
            int myIntNumb = Convert.ToInt32(numb);

            if (myIntNumb >= 1 && myIntNumb < 101)
                number = true;

            Assert.IsTrue(number);
        }

        [TestMethod]
        public void TestGetRandomNumber()
        {
            string getSecretNumber = mooGame.GetRandomNumber();
            Assert.AreEqual(4, getSecretNumber.Length);
        }

        [TestMethod]
        public void TestCheckSecretNumberAllWrong()
        {
            /* Bulls: 0
             * Cows: 0
             * */
            secretNumber = "1234";
            guess = "0000";
            result = mooGame.CalcSecretNumber(secretNumber, guess);
            Assert.AreEqual(",", result);
        }

        [TestMethod]
        public void TestCheckSecretNumber2Bull()
        {
            /* Bulls: 2
             * Cows: 0
             * */
            secretNumber = "1234";
            guess = "1200";
            result = mooGame.CalcSecretNumber(secretNumber, guess);
            Assert.AreEqual("BB,", result);
        }

        [TestMethod]
        public void TestCheckSecretNumber2Cow()
        {
            /* Bulls: 0
             * Cows: 2
             * */
            secretNumber = "1234";
            guess = "0012";
            result = mooGame.CalcSecretNumber(secretNumber, guess);
            Assert.AreEqual(",CC", result);
        }

        [TestMethod]
        public void TestCheckSecretNumber2Bull2Cow()
        {
            /* Bulls: 2
             * Cows: 2
             * */
            secretNumber = "1234";
            guess = "1243";
            result = mooGame.CalcSecretNumber(secretNumber, guess);
            Assert.AreEqual("BB,CC", result);
        }

        [TestMethod]
        public void TestCheckSecretNumberCorrect()
        {
            /* Bulls: 4
             * Cows: 0
             * */
            secretNumber = "1234";
            guess = "1234";
            result = mooGame.CalcSecretNumber(secretNumber, guess);
            Assert.AreEqual("BBBB,", result);
        }
    }
}
