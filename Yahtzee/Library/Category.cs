using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee.Library
{
    /// <summary>
    /// Enum list of differnt categories/ Roles Yahtzee game currently supports
    /// </summary>
    public enum Category
    {
        /// <summary>
        /// Ones category
        /// </summary>
        Ones,
        /// <summary>
        /// Twos category
        /// </summary>
        Twos,
        /// <summary>
        /// Threes category
        /// </summary>
        Threes,
        /// <summary>
        /// Fours category
        /// </summary>
        Fours,
        /// <summary>
        /// Fives category
        /// </summary>
        Fives,
        /// <summary>
        /// Sixes category
        /// </summary>
        Sixes,
        /// <summary>
        /// Pairs category- Can be 2,2 or 3,3 or 4,4 or 5,5 or 6,6- Highest pair total is considered.
        /// </summary>
        Pairs,
        /// <summary>
        /// Twopairs category - can be 2,3 and 3,3 or 4,4 and 5,5 so on.
        /// </summary>
        TwoPairs,
        /// <summary>
        /// ThreeOfKind category- can be 3,3,3 or 4,4,4
        /// </summary>
        ThreeOfKind,
        /// <summary>
        /// FourOfKind category- can be 1,1,1,1 or 2,2,2,2
        /// </summary>
        FourOfKind,
        /// <summary>
        /// SmallStraight category- has to be 1,2,3,4,5
        /// </summary>
        SmallStraight,
        /// <summary>
        /// Large straight category- 2,3,4,5,6
        /// </summary>
        LargeStraight,
        /// <summary>
        /// Full house category can have 2's and 3's kind for example- 2,2 and 4,4,4 pairs
        /// </summary>
        FullHouse,
        /// <summary>
        /// Chance category- can conatin any data
        /// </summary>
        Chance,
        /// <summary>
        /// Bingo!!! All dices with same number will score the player 50 bumper score.
        /// </summary>
        Yahtzee

    }
}
