using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee.Library;

namespace YahtzeeTest
{
    [TestClass]
    public class YahtzeeUnitTest
    {
        [TestMethod]
        public void TestOnes()
        {
           string data = "12134";
           int result = YahtzeeScorerFactory.Score(data, Category.Ones);
           Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestTwos()
        {
            string data = "12325";
            int result = YahtzeeScorerFactory.Score(data, Category.Twos);
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestThrees()
        {
            string data = "13334";
            int result = YahtzeeScorerFactory.Score(data, Category.Threes);
            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void TestFours()
        {
            string data = "12434";
            int result = YahtzeeScorerFactory.Score(data, Category.Fours);
            Assert.AreEqual(result, 8);
        }

        [TestMethod]
        public void TestFives()
        {
            string data = "15534";
            int result = YahtzeeScorerFactory.Score(data, Category.Fives);
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void TestSixes()
        {
            string data = "16664";
            int result = YahtzeeScorerFactory.Score(data, Category.Sixes);
            Assert.AreEqual(result,18);
        }

        [TestMethod]
        public void TestPairs()
        {
            //Negative test case
            string data = "16664";
            int result = YahtzeeScorerFactory.Score(data, Category.Pairs);
            Assert.AreEqual(result, 0);

            //Posituve test case
             data = "33664";
             result = YahtzeeScorerFactory.Score(data, Category.Pairs);
            Assert.AreEqual(result, 12);
        }

        [TestMethod]
        public void TestTwoPairs()
        {
            //Negative test case
            string data = "46664";
            int result = YahtzeeScorerFactory.Score(data, Category.TwoPairs);
            Assert.AreEqual(result, 0);

            //Positive test case
             data = "46364";
             result = YahtzeeScorerFactory.Score(data, Category.TwoPairs);
            Assert.AreEqual(result, 20);
        }

        [TestMethod]
        public void TestThreeOfKind()
        {
            //Negative test case
            string data = "16564";
            int result = YahtzeeScorerFactory.Score(data, Category.ThreeOfKind);
            Assert.AreEqual(result, 0);

            //Positive test case
            data = "16664";
             result = YahtzeeScorerFactory.Score(data, Category.ThreeOfKind);
            Assert.AreEqual(result, 18);
        }

        [TestMethod]
        public void TestFourOfKind()
        {
            //Negative test case
            string data = "16664";
            int result = YahtzeeScorerFactory.Score(data, Category.FourOfKind);
            Assert.AreEqual(result, 0);

            //Positive test case
             data = "16666";
             result = YahtzeeScorerFactory.Score(data, Category.FourOfKind);
            Assert.AreEqual(result, 24);

        }

        [TestMethod]
        public void TestSmallStraight()
        {
            //Negative test case
            string data = "16664";
            int result = YahtzeeScorerFactory.Score(data, Category.SmallStraight);
            Assert.AreEqual(result, 0);

            //Positive test case
             data = "12345";
             result = YahtzeeScorerFactory.Score(data, Category.SmallStraight);
             Assert.AreEqual(result, 15);
        }

        [TestMethod]
        public void TestLargeStraight()
        {
            //Negative test case
            string data = "16664";
            int result = YahtzeeScorerFactory.Score(data, Category.LargeStraight);
            Assert.AreEqual(result, 0);

            ////Negative test case, sending wrong parameter
            //data = "62345";
            //result = Utility.NStraights(data, true);
            //Assert.AreEqual(result, 0);

            //Positive test case
            data = "62345";
            result = YahtzeeScorerFactory.Score(data, Category.LargeStraight);
            Assert.AreEqual(result, 20);
        }

        [TestMethod]
        public void TestFullHouse()
        {
            //Negative Test case
            string data = "16664";
            int result = YahtzeeScorerFactory.Score(data,Category.FullHouse);
            Assert.AreEqual(result, 0);

            //Positive test case
             data = "46664";
             result = YahtzeeScorerFactory.Score(data, Category.FullHouse);
            Assert.AreEqual(result, 26);
        }

        [TestMethod]
        public void TestChance()
        {
            string data = "16664";
            int result = YahtzeeScorerFactory.Score(data, Category.Chance);
            Assert.AreEqual(result, 23);
        }

        [TestMethod]
        public void TestYahtzee()
        {
            //Negative test case
            string data = "16664";
            int result = YahtzeeScorerFactory.Score(data, Category.Yahtzee);
            Assert.AreEqual(result, 0);

            //positive test case
             data = "66666";
             result = YahtzeeScorerFactory.Score(data, Category.Yahtzee);
            Assert.AreEqual(result, 50);
        }

        [TestMethod]
        public void TestMaxScore()
        {
            //Positive test cases
             string data = "16664";
             YahtzeeScorerFactory.YahtzeeScore result= YahtzeeScorerFactory.MaxScore(data);
             Assert.AreEqual(result.Score, 23);
             Assert.AreEqual(result.Category, Category.Chance);

             data = "66666";
              result = YahtzeeScorerFactory.MaxScore(data);
             Assert.AreEqual(result.Score, 50);
             Assert.AreEqual(result.Category, Category.Yahtzee);
          
        }

    }
}
