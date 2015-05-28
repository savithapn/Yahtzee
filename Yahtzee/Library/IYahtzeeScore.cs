using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee.Library
{
    interface IYahtzeeScorer
    {
        int Score(string roll, Category category= Category.Ones);
    }
}
