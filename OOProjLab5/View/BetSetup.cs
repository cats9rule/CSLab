using CardGame.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame.View
{
    public partial class BetSetup : Form
    {
        private GameController controller;

        public BetSetup()
        {
            InitializeComponent();
        }

        public BetSetup(ref GameController c) 
            : this()
        {
            controller = c;
        }

        private void BetSetup_Load(object sender, EventArgs e)
        {
            nubBetAmount.Maximum = controller.Points;
            nubBetAmount.Minimum = 0;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(nubBetAmount.Value == 0)
            {
                DialogResult res = MessageBox.Show("Betting amount has to be above zero!", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int bet = (int)nubBetAmount.Value;
                controller.BettingPoints = bet;
                controller.PlaceBet(bet);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
