using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooRefactor.Games;
using System;

namespace MooRefactorTest
{
    [TestClass]
    public class MooUnitTest
    {
        MooGame mooGame;

        string secretNumber = "1234";
        string guess = "";
        string result = "";

        [TestInitialize]
        public void InitTest()
        {
            mooGame = new();
        }

        [TestMethod]
        public void GetRandomNumberTest()
        {
            string getSecretNumber = mooGame.GetRandomNumber();
            Assert.AreEqual(4, getSecretNumber.Length);
        }

        [TestMethod]
        public void CheckSecretNumberAllWrongTest()
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
        public void CheckSecretNumber2BullTest()
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
        public void CheckSecretNumber2CowTest()
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
        public void CheckSecretNumber2Bull2CowTest()
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
        public void CheckSecretNumberCorrectTest()
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
