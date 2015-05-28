using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee.Library
{
    /// <summary>
    /// This class conatins method to calculate various scores depending upon category.
    /// </summary>
    public static  class YahtzeeScorerFactory
    {

        public struct YahtzeeScore
        {
            public int Score;
            public Category Category;

            public override string ToString()
            {
                string str;
                str = "Score: " + Score + "\r\nCategory: " + Category;
                return str;
            }
        }
            
        /// <summary>
        /// Gives the score result based on category and roll.
        /// </summary>
        /// <param name="roll"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public static int Score(string roll, Category category)
        {
            IYahtzeeScorer yahtzeeScorer;
            switch(category)
            {
                case Category.Ones:
                    yahtzeeScorer = new Ones();
                    break;
                case Category.Twos:
                    yahtzeeScorer = new Twos();
                    break;
                case Category.Threes:
                    yahtzeeScorer = new Threes();
                    break;
                case Category.Fours:
                    yahtzeeScorer = new Fours();
                    break;
                case Category.Fives:
                    yahtzeeScorer = new Fives();
                    break;
                case Category.Sixes:
                    yahtzeeScorer = new Sixes();
                    break;
                case Category.Pairs:
                    yahtzeeScorer = new Pairs();
                    break;
                case Category.TwoPairs:
                    yahtzeeScorer = new TwoPairs();
                    break;
                case Category.ThreeOfKind:
                    yahtzeeScorer = new ThreeOfKind();
                    break;
                case Category.FourOfKind:
                    yahtzeeScorer = new FourOfKind();
                    break;
                case Category.SmallStraight:
                    yahtzeeScorer = new SmallStraight();
                    break;
                case Category.LargeStraight:
                    yahtzeeScorer = new LargeStraight();
                    break;
                case Category.FullHouse:
                    yahtzeeScorer = new FullHouse();
                    break;
                case Category.Chance:
                    yahtzeeScorer = new Chance();
                    break;
                case Category.Yahtzee:
                    yahtzeeScorer = new Yahtzee();
                    break;
                default:
                    return 0;

            }
            return  yahtzeeScorer.Score(roll);;
        }

        /// <summary>
        /// Method determines  category and score where the roll will yield the most points
        /// </summary>
        /// <param name="roll"></param>
        /// <returns></returns>
        public static YahtzeeScore MaxScore(string roll)
        {
            YahtzeeScore yahtzeeScore;
            List<YahtzeeScore> scores = new List<YahtzeeScore>();
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                int result = Score(roll, category);
                YahtzeeScore newScore;
                newScore.Score = result;
                newScore.Category = category;
                scores.Add(newScore);
            }

            yahtzeeScore  = scores.OrderByDescending(x => x.Score).First();
            return yahtzeeScore;
        }
        
    }

    #region Utility Class
    
    public static class Utility
    {
        /// <summary>
        /// Validates the input data. It determines if the value is an valid integer or not.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static bool ValidateData(string data)
        {
            int val;
            if (int.TryParse(data.ToString(), out val))
            {
                if (val > 0 && val < 7)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Does a conditional addition based on categories which is used in yahtzee. if Condition == 0 , then it belongs to chance category so sum of all dice are done.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        internal static int ConditionalAddition(string data, int condition)
        {
            int result = 0;
            char[] arrayData = data.ToCharArray(0, data.Length);
            
                for (int i = 0; i < arrayData.Length; i++)
                {
                    if (ValidateData(arrayData[i].ToString()))
                    {
                        if(condition == 0)
                        {
                            result += int.Parse(arrayData[i].ToString());
                        }
                        else
                        { 
                        if (int.Parse(arrayData[i].ToString()) == condition)
                            result += condition;
                        }
                    }
                }
            return result;
        }

        /// <summary>
        /// Used for calculating  pairs,Two Pairs,three of kind and four of kind categories score.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nKind">Represents what category type for example, if it is pairs- then nKind = 2. if it is 
        /// three of kind category then nkind = 3 and so on</param>
        /// <returns></returns>
        internal static int NofKindAddition(string data, int nKind, bool isTwoPair = false)
        {
            int result = 0;
            char[] arrayData = data.ToCharArray(0, data.Length);
            List<char> list = arrayData.ToList();
            int pairCount = 0;
            List<int> addedNumbers = new List<int>();
            for(int i=6; i>0;i--)
            {
                //ASCII code for 0 starts at 30 hence 30 is added.
                char n = (char)(i + 0x30);

                for (int j = 0; j < arrayData.Length;j++ )
                {
                    if (n == arrayData[j])
                    {
                        int count = (from a in list where a == n select list).Count();
                        if (count == nKind)
                        {
                           if(!addedNumbers.Contains(i))
                           { 
                            if(!isTwoPair)
                            { 
                                return result = i * nKind;
                            }
                            else
                            {
                                pairCount++;
                                if(pairCount >2)
                                return result = i * nKind;

                                result += i * nKind;
                            }
                           }
                            addedNumbers.Add(i);
                        }
                    }
                }
            }
            if(isTwoPair)
            {
                if (pairCount < 2)
                    return 0;
            }
            return result;
        }

        /// <summary>
        /// Used for calculating  small and large straight category score.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isSmall"></param>
        /// <returns></returns>
        internal static int NStraights(string data, bool isSmall)
        {
            int result = 0;
            char[] arrayData = data.ToCharArray(0, data.Length);
            List<char> list = arrayData.ToList();
            bool mayBeSmall = false;
            if (list.Contains('1'))
            {
                mayBeSmall = true;
            }
            if (isSmall != mayBeSmall)
                return 0;

                for (int i = 0; i < 5; i++)
                {
                     int temp=0;
                     if (mayBeSmall)
                         temp = i + 1;
                     else
                         temp = i + 2;

                    //ASCII code for 0 starts at 30 hence 30 is added.
                    char n = (char)(temp + 0x30);
                    if (!list.Contains(n))
                    {
                        return 0;
                    }
                    result += temp;
                }
                return result;
        }

        /// <summary>
        /// Used for calculating  Fullhouse score. (If the dice are two of a kind and three of a kind, the player scores the sum of all the dice otherwise 0.)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static int FullHouse(string data)
        {
            int result = 0;
            bool twoOfkind = false, threeOfKind = false;
            char[] arrayData = data.ToCharArray(0, data.Length);
            
            List<char> list = arrayData.ToList();
            char n;
            for (int i = 0; i < 5;i++ )
            {
                n = list[i] ;
                int count = (from a in list where a == n select list).Count();
                if(count == 2)
                {
                    twoOfkind = true;
                }
                if(count== 3)
                {
                    threeOfKind = true;
                }
                if(!(twoOfkind || threeOfKind))
                {
                    return 0;
                }
            }
            if(twoOfkind && threeOfKind)
            {
                for(int i=0;i<5;i++)
                {
                    //ASCII code for 0 starts at 30 hence 30 is subtracted.
                    n = (char)(list[i] - 0x30);
                    result += n;
                }
            }
                return result;
        }

        /// <summary>
        /// Used for calculation Yahtzee score.( If all dice have the same number, the player scores 50 points).
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static int Yahtzee(string data)
        {
            char[] arrayData = data.ToCharArray(0, data.Length);
            List<char> list = arrayData.ToList();
            char n;
            
            int result = 0;

            for(int i=0;i<4;i++)
            {
                if(list[i] != list[i+1])
                {
                    return 0;
                }

                //ASCII code for 0 starts at 30 hence 30 is subtracted.
                //n = (char)(list[i] - 0x30);
                
                //result += n;
            }
            //n = (char)(list[4] - 0x30);
            
            //Bingo!!
            return 50;
        }
    }

    
    
    #endregion

    #region Concerte classes


    public  class Ones : IYahtzeeScorer
    {
        public  int Score(string roll,  Category category= Category.Ones)
        {
            return Utility.ConditionalAddition(roll, 1);
        }
    }

    public  class Twos : IYahtzeeScorer
    {
        public  int Score(string roll, Category category = Category.Twos)
        {
            return Utility.ConditionalAddition(roll, 2);
        }
    }

    public  class Threes : IYahtzeeScorer
    {
        public  int Score(string roll, Category category= Category.Threes)
        {
            return Utility.ConditionalAddition(roll, 3);
        }
    }

    public  class Fours : IYahtzeeScorer
    {
        public  int Score(string roll, Category category= Category.Fours)
        {
            return Utility.ConditionalAddition(roll, 4);
        }
    }

    public  class Fives : IYahtzeeScorer
    {
        public  int Score(string roll, Category category=Category.Fives)
        {
            return Utility.ConditionalAddition(roll, 5);
        }
    }

    public  class Sixes : IYahtzeeScorer
    {
        public  int Score(string roll, Category category= Category.Sixes)
        {
            return Utility.ConditionalAddition(roll, 6);
        }
    }

    public class Pairs : IYahtzeeScorer
    {
        public int Score(string roll, Category category = Category.Pairs)
        {
            return Utility.NofKindAddition(roll, 2);
        }
    }

        public class TwoPairs : IYahtzeeScorer
        {
            public int Score(string roll, Category category = Category.TwoPairs)
            {
                return Utility.NofKindAddition(roll, 2, true);
            }
        }

        public class ThreeOfKind : IYahtzeeScorer
        {
            public int Score(string roll, Category category = Category.ThreeOfKind)
            {
                return Utility.NofKindAddition(roll, 3);
            }
        }

        public class FourOfKind : IYahtzeeScorer
        {
            public int Score(string roll, Category category = Category.FourOfKind)
            {
                return Utility.NofKindAddition(roll, 4);
            }
        }

        public class SmallStraight : IYahtzeeScorer
        {
            public int Score(string roll, Category category = Category.SmallStraight)
            {
               return Utility.NStraights(roll, true);
            }
        }

        public class LargeStraight : IYahtzeeScorer
        {
            public int Score(string roll, Category category = Category.LargeStraight)
            {
                return Utility.NStraights(roll, false);
            }
        }

        public class FullHouse : IYahtzeeScorer
        {
            public int Score(string roll, Category category = Category.FullHouse)
            {
                return Utility.FullHouse(roll);
            }
        }

        public class Chance : IYahtzeeScorer
        {
            public int Score(string roll, Category category = Category.Chance)
            {
                return Utility.ConditionalAddition(roll, 0);
            }
        }

        public class Yahtzee : IYahtzeeScorer
        {
            public int Score(string roll, Category category = Category.Yahtzee)
            {
                return Utility.Yahtzee(roll);
            }
        }


    #endregion
   
    
}
