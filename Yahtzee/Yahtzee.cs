using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yahtzee.Library;

namespace Yahtzee
{
    public partial class Yahtzee : Form
    {
        public Yahtzee()
        {
            InitializeComponent();
        }

        #region members
        string RollData;
        #endregion

        #region Methods

        
        /// <summary>
        /// Always returns the latest Rolled data
        /// </summary>
        /// <returns></returns>
        private string UpdatedStringData()
        {
            
            RollData = rtxtFirst.Text + rtxtSecond.Text + rtxtThird.Text + rtxtFourth.Text + rtxtFifth.Text;
            if(string.IsNullOrEmpty(RollData))
            {

            }
            return RollData;
        }
        private bool ValidateData()
        {
            if(string.IsNullOrEmpty( UpdatedStringData()))
            {
                MessageBox.Show("Roll data cannot be empty, Click on Roll button to get roll data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnRoll.Focus();
                return false;
            }
            return true;
        }

        private string GetScore(Category category)
        {
            if (!ValidateData())
                return string.Empty;
            switch(category)
            {
                case Category.Ones:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.Ones).ToString();
                case Category.Twos:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.Twos).ToString();
                case Category.Threes:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.Threes).ToString();
                case Category.Fours:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.Fours).ToString();
                case Category.Fives:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.Fives).ToString();
                case Category.Sixes:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.Sixes).ToString();
                case Category.Pairs:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.Pairs).ToString();
                case Category.TwoPairs:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.TwoPairs).ToString();
                case Category.ThreeOfKind:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.ThreeOfKind).ToString();
                case Category.FourOfKind:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.FourOfKind).ToString();
                case Category.SmallStraight:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.SmallStraight).ToString();
                case Category.LargeStraight:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.LargeStraight).ToString();
                case Category.Chance:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.Chance).ToString();
                case Category.FullHouse:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.FullHouse).ToString();
                case Category.Yahtzee:
                    return YahtzeeScorerFactory.Score(UpdatedStringData(), Category.Yahtzee).ToString();
                default:
                    return string.Empty;



            }
        }

        private void Reset()
        {
            txtOnes.Clear();
            txtTwos.Clear();
            txtThrees.Clear();
            txtThreeOfKind.Clear();
            txtFours.Clear();
            txtFourOfKind.Clear();
            txtFives.Clear();
            txtSixes.Clear();
            txtPairs.Clear();
            txtTwoPairs.Clear();
            txtChance.Clear();
            txtSmallStraight.Clear();
            txtLargeStraight.Clear();
            txtFullHouse.Clear();
            txtYahtzee.Clear();
            rtxtMaxScore.Clear(); 
            rtxtFirst.Clear();
            rtxtSecond.Clear();
            rtxtThird.Clear();
            rtxtFourth.Clear();
            rtxtFifth.Clear();
            btnRoll.Focus();
        }
        #endregion

        #region Events

        private void btnRoll_Click(object sender, EventArgs e)
        {
            Reset();
            Random ran = new Random();
            int first = (ran.Next())%6 +1;
            int second = (ran.Next()) % 6 + 1;
            int third = (ran.Next()) % 6 + 1;
            int fourth = (ran.Next()) % 6 + 1;
            int fifth = (ran.Next()) % 6 + 1;

            rtxtFirst.Text = first.ToString();
            rtxtSecond.Text = second.ToString();
            rtxtThird.Text = third.ToString();
            rtxtFourth.Text = fourth.ToString();
            rtxtFifth.Text = fifth.ToString();

            RollData = rtxtFirst.Text + rtxtSecond.Text + rtxtThird.Text + rtxtFourth.Text + rtxtFifth.Text;

        }
        
        private void btnOnes_Click(object sender, EventArgs e)
        {
            txtOnes.Text = GetScore(Category.Ones);
        }

        private void btnTwos_Click(object sender, EventArgs e)
        {
            txtTwos.Text = GetScore(Category.Twos);
        }

        private void btnThrees_Click(object sender, EventArgs e)
        {
            txtThrees.Text = GetScore(Category.Threes);
        }

        private void btnFours_Click(object sender, EventArgs e)
        {
            txtFours.Text = GetScore(Category.Fours);
        }

        private void btnFives_Click(object sender, EventArgs e)
        {
            txtFives.Text = GetScore(Category.Fives);
        }

        private void btnSixes_Click(object sender, EventArgs e)
        {
            txtSixes.Text = GetScore(Category.Sixes);
        }

        private void btnPairs_Click(object sender, EventArgs e)
        {
            txtPairs.Text = GetScore(Category.Pairs);
        }

        private void btnTwoPairs_Click(object sender, EventArgs e)
        {
            txtTwoPairs.Text = GetScore(Category.TwoPairs);
        }

        private void btnThreeOfKind_Click(object sender, EventArgs e)
        {
            txtThreeOfKind.Text = GetScore(Category.ThreeOfKind);
        }

        private void btnFourOfKind_Click(object sender, EventArgs e)
        {
            txtFourOfKind.Text = GetScore(Category.FourOfKind);
        }

        private void btnSmallStraight_Click(object sender, EventArgs e)
        {
            txtSmallStraight.Text = GetScore(Category.SmallStraight);
        }

        private void btnLargeStraight_Click(object sender, EventArgs e)
        {
            txtLargeStraight.Text = GetScore(Category.LargeStraight);
        }

        private void btnFullHouse_Click(object sender, EventArgs e)
        {
            txtFullHouse.Text = GetScore(Category.FullHouse);
        }

        private void btnChance_Click(object sender, EventArgs e)
        {
            txtChance.Text = GetScore(Category.Chance);
        }

        private void btnYahtzee_Click(object sender, EventArgs e)
        {
            txtYahtzee.Text = GetScore(Category.Yahtzee);
        }

        private void bthChkMaxScore_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            rtxtMaxScore.Text = YahtzeeScorerFactory.MaxScore(UpdatedStringData()).ToString();
        }

        private void rtxtRollValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if (int.Parse(e.KeyChar.ToString()) < 1 || int.Parse(e.KeyChar.ToString()) > 6)
                {
                    e.Handled = true;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

    }
}
