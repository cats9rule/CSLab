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
        GameController controller;
        
        public GameForm()
        {
            InitializeComponent();
            controller = new GameController();
        }

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

        #region Select and Deselect Cards

        private void pbxCards1_Click(object sender, EventArgs e)
        {

            if (!controller.SelectedCards[0])
            {
                if (controller.SelectedCount < 3)
                {
                    if (btnDrawReplace.Enabled == false)
                    {
                        btnDrawReplace.Enabled = true;
                    }
                    // card wasnt selected
                    controller.SelectedCount++;
                    controller.SelectedCards[0] = true;

                    int x = pbxCards1.Location.X;
                    int y = pbxCards1.Location.Y - 20;

                    pbxCards1.Location = new Point(x, y);
                    pbxCards1.BorderStyle = BorderStyle.FixedSingle;
                    pbxCards1.Update();
                }
                else
                {
                    MessageBox.Show("You can\'t select more than three cards to replace!",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // card was selected
                Deselect1();
            }
        }
        private void Deselect1()
        {
            controller.SelectedCount--;
            if (controller.SelectedCount == 0)
            {
                btnDrawReplace.Enabled = false;
            }
            controller.SelectedCards[0] = false;

            int x = pbxCards1.Location.X;
            int y = pbxCards1.Location.Y + 20;

            pbxCards1.Location = new Point(x, y);
            pbxCards1.BorderStyle = BorderStyle.None;
            pbxCards1.Update();
        }

        private void pbxCards2_Click(object sender, EventArgs e)
        {

            if (!controller.SelectedCards[1])
            {
                if (controller.SelectedCount < 3)
                {
                    if (btnDrawReplace.Enabled == false)
                    {
                        btnDrawReplace.Enabled = true;
                    }
                    // card wasnt selected
                    controller.SelectedCount++;
                    controller.SelectedCards[1] = true;

                    int x = pbxCards2.Location.X;
                    int y = pbxCards2.Location.Y - 20;

                    pbxCards2.Location = new Point(x, y);
                    pbxCards2.BorderStyle = BorderStyle.FixedSingle;
                    pbxCards2.Update();
                }
                else
                {
                    MessageBox.Show("You can\'t select more than three cards to replace!",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // card was selected
                Deselect2();
            }
        }
        private void Deselect2()
        {
            controller.SelectedCount--;
            if (controller.SelectedCount == 0)
            {
                btnDrawReplace.Enabled = false;
            }
            controller.SelectedCards[1] = false;

            int x = pbxCards2.Location.X;
            int y = pbxCards2.Location.Y + 20;

            pbxCards2.Location = new Point(x, y);
            pbxCards2.BorderStyle = BorderStyle.None;
            pbxCards2.Update();
        }

        private void pbxCards3_Click(object sender, EventArgs e)
        {

            if (!controller.SelectedCards[2])
            {
                if (controller.SelectedCount < 3)
                {
                    if (btnDrawReplace.Enabled == false)
                    {
                        btnDrawReplace.Enabled = true;
                    }
                    // card wasnt selected
                    controller.SelectedCount++;
                    controller.SelectedCards[2] = true;

                    int x = pbxCards3.Location.X;
                    int y = pbxCards3.Location.Y - 20;

                    pbxCards3.Location = new Point(x, y);
                    pbxCards3.BorderStyle = BorderStyle.FixedSingle;
                    pbxCards3.Update();
                }
                else
                {
                    MessageBox.Show("You can\'t select more than three cards to replace!",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // card was selected
                Deselect3();
            }
        }
        private void Deselect3()
        {
            controller.SelectedCount--;
            if (controller.SelectedCount == 0)
            {
                btnDrawReplace.Enabled = false;
            }
            controller.SelectedCards[2] = false;

            int x = pbxCards3.Location.X;
            int y = pbxCards3.Location.Y + 20;

            pbxCards3.Location = new Point(x, y);
            pbxCards3.BorderStyle = BorderStyle.None;
            pbxCards3.Update();
        }

        private void pbxCards4_Click(object sender, EventArgs e)
        {

            if (!controller.SelectedCards[3])
            {
                if (controller.SelectedCount < 3)
                {
                    if (btnDrawReplace.Enabled == false)
                    {
                        btnDrawReplace.Enabled = true;
                    }
                    // card wasnt selected
                    controller.SelectedCount++;
                    controller.SelectedCards[3] = true;

                    int x = pbxCards4.Location.X;
                    int y = pbxCards4.Location.Y - 20;

                    pbxCards4.Location = new Point(x, y);
                    pbxCards4.BorderStyle = BorderStyle.FixedSingle;
                    pbxCards4.Update();
                }
                else
                {
                    MessageBox.Show("You can\'t select more than three cards to replace!",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // card was selected
                Deselect4();
            }
        }
        private void Deselect4()
        {
            controller.SelectedCount--;
            if (controller.SelectedCount == 0)
            {
                btnDrawReplace.Enabled = false;
            }
            controller.SelectedCards[3] = false;

            int x = pbxCards4.Location.X;
            int y = pbxCards4.Location.Y + 20;

            pbxCards4.Location = new Point(x, y);
            pbxCards4.BorderStyle = BorderStyle.None;
            pbxCards4.Update();
        }

        private void pbxCards5_Click(object sender, EventArgs e)
        {

            if (!controller.SelectedCards[4])
            {
                if (controller.SelectedCount < 3)
                {
                    if (btnDrawReplace.Enabled == false)
                    {
                        btnDrawReplace.Enabled = true;
                    }
                    // card wasnt selected
                    controller.SelectedCount++;
                    controller.SelectedCards[4] = true;

                    int x = pbxCards5.Location.X;
                    int y = pbxCards5.Location.Y - 20;

                    pbxCards5.Location = new Point(x, y);
                    pbxCards5.BorderStyle = BorderStyle.FixedSingle;
                    pbxCards5.Update();
                }
                else
                {
                    MessageBox.Show("You can\'t select more than three cards to replace!",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // card was selected
                Deselect5();
            }
        }
        private void Deselect5()
        {
            controller.SelectedCount--;
            if (controller.SelectedCount == 0)
            {
                btnDrawReplace.Enabled = false;
            }
            controller.SelectedCards[4] = false;

            int x = pbxCards5.Location.X;
            int y = pbxCards5.Location.Y + 20;

            pbxCards5.Location = new Point(x, y);
            pbxCards5.BorderStyle = BorderStyle.None;
            pbxCards5.Update();
        }

        private void DeselectAllSelectedCards()
        {
            for(int i = 0; i < 5; i++)
            {
                if (controller.SelectedCards[i])
                {
                    // card needs to be deselected
                    switch (i)
                    {
                        case 0:
                            Deselect1();
                            break;
                        case 1:
                            Deselect2();
                            break;
                        case 2:
                            Deselect3();
                            break;
                        case 3:
                            Deselect4();
                            break;
                        case 4:
                            Deselect5();
                            break;
                    }
                }
            }
        }

        #endregion

        private void btnBet_Click(object sender, EventArgs e)
        {
            int mul;
            controller.UpdatePoints(out mul);
            if (controller.IsGameOver())
            {
                DialogResult res = MessageBox.Show("You placed a bet too high and came out empty handed. How unfortunate! " +
                    "Perhaps next time you can be smarter ahuhu...\nPlay again?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if(res == DialogResult.Yes)
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
                        MessageBox.Show("Oh... Straight. Well, pretty normal. Nothing special. " +
                            "You can still be proud if you want though! Hehe.", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 9:
                        MessageBox.Show("Blaze? Oh, Blaze!!! Cute. A lot of royalty though. That\'s never a good thing. " +
                            "Enjoy while you can!", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("A Pair of Worthless. Too bad you\'re still single! " +
                            "Don't be so pathetic!", "Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("Congratulations! You managed to score the Great Empty Hand! " +
                            "Lol dude are you even playing?", "Pathetic!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
