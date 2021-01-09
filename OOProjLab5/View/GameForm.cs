using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardGame.Controller;
using System.IO;

namespace CardGame.View
{
    public partial class GameForm : Form
    {
        #region Attributes

        private GameController controller;
        private List<PictureBox> handCards;

        #endregion

        #region Constructors

        public GameForm()
        {
            InitializeComponent();
            controller = new GameController();
            handCards = new List<PictureBox>();
            handCards.Add(pbxCards1);
            handCards.Add(pbxCards2);
            handCards.Add(pbxCards3);
            handCards.Add(pbxCards4);
            handCards.Add(pbxCards5);
        }

        #endregion

        #region Methods

        #region Event Handlers
        private void GameForm_Load(object sender, EventArgs e)
        {
            StartingSetup setup = new StartingSetup(ref controller);
            setup.ShowDialog();
            if(setup.DialogResult == DialogResult.OK)
            {
                string col = controller.Deck.Colour;
                string path = "../../../CardSprites/" + col + "_back.png";
                pbxDeck.Image = Image.FromFile(path);
                pbxDeck.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                btnBet.Enabled = false;
            }
            lblTotalPoints.Text = controller.Points.ToString();
        }

        private void btnDrawReplace_Click(object sender, EventArgs e)
        {
            if(btnDrawReplace.Text == "Draw Cards")
            {
                if(controller.Hand.Count == 0)
                {
                    BetSetup betSetup = new BetSetup(ref controller);
                    betSetup.ShowDialog();

                    if(betSetup.DialogResult == DialogResult.OK)
                    {
                        btnDrawReplace.Text = "Replace Cards";
                        btnDrawReplace.Enabled = false;
                        controller.DrawHand();
                        // needs code to actually display hand cards
                        pbxCards1.Image = controller.Hand[0].ImgFront;
                        pbxCards2.Image = controller.Hand[1].ImgFront;
                        pbxCards3.Image = controller.Hand[2].ImgFront;
                        pbxCards4.Image = controller.Hand[3].ImgFront;
                        pbxCards5.Image = controller.Hand[4].ImgFront;

                        lblBettingPoints.Text = controller.BettingPoints.ToString();
                        lblTotalPoints.Text = controller.Points.ToString();
                    }
                }
            }
            else if(btnDrawReplace.Text == "Replace Cards")
            {
                if(controller.SelectedCount > 0)
                {
                    btnDrawReplace.Visible = false;
                    btnDrawReplace.Text = "Draw Cards";
                    controller.ReplaceSelectedCards();
                    DeselectAllSelectedCards();
                    controller.ResetSelection();
                    // redraw cards
                    pbxCards1.Image = controller.Hand[0].ImgFront;
                    pbxCards2.Image = controller.Hand[1].ImgFront;
                    pbxCards3.Image = controller.Hand[2].ImgFront;
                    pbxCards4.Image = controller.Hand[3].ImgFront;
                    pbxCards5.Image = controller.Hand[4].ImgFront;
                }
            }
            btnBet.Enabled = true;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // reset everything

            DeselectAllSelectedCards();
            controller.ResetGame();
            GameForm_Load(sender, e);

            pbxCards1.Image = null;
            pbxCards2.Image = null;
            pbxCards3.Image = null;
            pbxCards4.Image = null;
            pbxCards5.Image = null;

            lblBettingPoints.Text = controller.BettingPoints.ToString();

            btnDrawReplace.Text = "Draw Cards";
            btnDrawReplace.Visible = true;
            btnDrawReplace.Enabled = true;
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            int mul;
            controller.UpdatePoints(out mul);
            if (controller.IsGameOver())
            {
                DialogResult res = MessageBox.Show("You placed a bet too high and came out empty handed. How unfortunate! " +
                    "Perhaps next time you can be smarter hehehe...\nPlay again?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (res == DialogResult.Yes)
                {
                    btnNewGame_Click(sender, e);
                }
                else
                {
                    Close();
                }
            }
            else
            {
                switch (mul)
                {
                    case 100:
                        MessageBox.Show("Congratulations! You managed to score the Great Straight Flush! " +
                            "Be proud of yourself, warrior!", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 60:
                        MessageBox.Show("So you have Four of a Kind. Sweet! This is the " +
                            "second rarest combo. Be proud!", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 40:
                        MessageBox.Show("Wow, a Big Bobtail! Congrats! Did you know there\'s a cat breed " +
                            "named Japanese Bobtail?", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 24:
                        MessageBox.Show("Holly Molly, a Full House! Hopefully this means a heart... full... " +
                            "of pride?", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 16:
                        MessageBox.Show("Well, well, a Flush I see here. Too bad it\'s not... Straight! " +
                            "Ehehehe", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 12:
                        MessageBox.Show("Oh... Straight. Nothing special. " +
                            "You can still be proud if you want though!", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 9:
                        MessageBox.Show("Blaze? Oh, Blaze!!! Cute. A lot of royalty though. " +
                            "I hope your luck runs out.", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 6:
                        MessageBox.Show("Three of a Kind. Are you always this average? " +
                            "I bet you feel happy now. Simpleton.", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 4:
                        MessageBox.Show("Two Pairs are better than one. Unimpressive, in any case. " +
                            "Is this all you\'ve got??", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 2:
                        MessageBox.Show("A Pair of Worthless. Too bad you\'re still single! ", 
                            "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("Congratulations! You managed to score the Great Empty Hand! " +
                            "Lol dude are you even trying?", "Pathetic!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                DeselectAllSelectedCards();
                btnBet.Enabled = false;

                pbxCards1.Image = null;
                pbxCards2.Image = null;
                pbxCards3.Image = null;
                pbxCards4.Image = null;
                pbxCards5.Image = null;

                controller.ResetHand();
                lblBettingPoints.Text = controller.BettingPoints.ToString();
                lblTotalPoints.Text = controller.Points.ToString();

                btnDrawReplace.Text = "Draw Cards";
                btnDrawReplace.Visible = true;
                btnDrawReplace.Enabled = true;
            }
        }

        private void pbxCards1_Click(object sender, EventArgs e)
        {
            if (!controller.SelectedCards[0])
            {
                SelectSpecificCard(0);
            }
            else
            {
                // card was selected
                DeselectSpecificCard(0);
            }
        }

        private void pbxCards2_Click(object sender, EventArgs e)
        {
            if (!controller.SelectedCards[1])
            {
                SelectSpecificCard(1);
            }
            else
            {
                // card was selected
                DeselectSpecificCard(1);
            }
        }

        private void pbxCards3_Click(object sender, EventArgs e)
        {
            if (!controller.SelectedCards[2])
            {
                SelectSpecificCard(2);
            }
            else
            {
                // card was selected
                DeselectSpecificCard(2);
            }
        }

        private void pbxCards4_Click(object sender, EventArgs e)
        {
            if (!controller.SelectedCards[3])
            {
                SelectSpecificCard(3);
            }
            else
            {
                // card was selected
                DeselectSpecificCard(3);
            }
        }

        private void pbxCards5_Click(object sender, EventArgs e)
        {
            if (!controller.SelectedCards[4])
            {
                SelectSpecificCard(4);
            }
            else
            {
                // card was selected
                DeselectSpecificCard(4);
            }
        }
        #endregion

        #region Select and Deselect Cards
        private void DeselectAllSelectedCards()
        {
            for(int i = 0; i < 5; i++)
            {
                if (controller.SelectedCards[i])
                {
                    DeselectSpecificCard(i);
                }
            }
        }

        private void SelectSpecificCard(int index)
        {
            if (controller.SelectedCount < 3)
            {
                if (btnDrawReplace.Enabled == false)
                {
                    btnDrawReplace.Enabled = true;
                }
                // card wasnt selected
                controller.SelectedCount++;
                controller.SelectedCards[index] = true;

                int x = handCards[index].Location.X;
                int y = handCards[index].Location.Y - 20;

                handCards[index].Location = new Point(x, y);
                handCards[index].BorderStyle = BorderStyle.FixedSingle;
                handCards[index].Update();
            }
            else
            {
                MessageBox.Show("You can\'t select more than three cards to replace!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeselectSpecificCard(int index)
        {
            controller.SelectedCount--;
            if (controller.SelectedCount == 0)
            {
                btnDrawReplace.Enabled = false;
            }
            controller.SelectedCards[index] = false;

            int x = handCards[index].Location.X;
            int y = handCards[index].Location.Y + 20;

            handCards[index].Location = new Point(x, y);
            handCards[index].BorderStyle = BorderStyle.None;
            handCards[index].Update();
        }
        #endregion

        #endregion
    }
}
