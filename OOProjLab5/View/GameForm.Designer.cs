
namespace CardGame.View
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDrawReplace = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btnBet = new System.Windows.Forms.Button();
            this.lblTotalPoints = new System.Windows.Forms.Label();
            this.lblBettingPoints = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.pbxCards5 = new System.Windows.Forms.PictureBox();
            this.pbxCards4 = new System.Windows.Forms.PictureBox();
            this.pbxCards3 = new System.Windows.Forms.PictureBox();
            this.pbxCards2 = new System.Windows.Forms.PictureBox();
            this.pbxCards1 = new System.Windows.Forms.PictureBox();
            this.pbxDeck = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDeck)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDrawReplace
            // 
            this.btnDrawReplace.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrawReplace.Location = new System.Drawing.Point(748, 62);
            this.btnDrawReplace.Name = "btnDrawReplace";
            this.btnDrawReplace.Size = new System.Drawing.Size(129, 44);
            this.btnDrawReplace.TabIndex = 0;
            this.btnDrawReplace.Text = "Draw Cards";
            this.btnDrawReplace.UseVisualStyleBackColor = true;
            this.btnDrawReplace.Click += new System.EventHandler(this.btnDrawReplace_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(12, 44);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(84, 27);
            this.lbl1.TabIndex = 7;
            this.lbl1.Text = "Points: ";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(11, 85);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(94, 27);
            this.lbl2.TabIndex = 8;
            this.lbl2.Text = "Betting: ";
            // 
            // btnBet
            // 
            this.btnBet.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBet.Location = new System.Drawing.Point(829, 398);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(75, 55);
            this.btnBet.TabIndex = 1;
            this.btnBet.Text = "Bet!";
            this.btnBet.UseVisualStyleBackColor = true;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // lblTotalPoints
            // 
            this.lblTotalPoints.AutoSize = true;
            this.lblTotalPoints.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPoints.Location = new System.Drawing.Point(118, 47);
            this.lblTotalPoints.Name = "lblTotalPoints";
            this.lblTotalPoints.Size = new System.Drawing.Size(87, 23);
            this.lblTotalPoints.TabIndex = 10;
            this.lblTotalPoints.Text = "0000000";
            // 
            // lblBettingPoints
            // 
            this.lblBettingPoints.AutoSize = true;
            this.lblBettingPoints.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBettingPoints.Location = new System.Drawing.Point(118, 88);
            this.lblBettingPoints.Name = "lblBettingPoints";
            this.lblBettingPoints.Size = new System.Drawing.Size(87, 23);
            this.lblBettingPoints.TabIndex = 11;
            this.lblBettingPoints.Text = "0000000";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.Location = new System.Drawing.Point(797, 199);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(129, 44);
            this.btnNewGame.TabIndex = 2;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // pbxCards5
            // 
            this.pbxCards5.Location = new System.Drawing.Point(640, 372);
            this.pbxCards5.Name = "pbxCards5";
            this.pbxCards5.Size = new System.Drawing.Size(150, 228);
            this.pbxCards5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCards5.TabIndex = 5;
            this.pbxCards5.TabStop = false;
            this.pbxCards5.Click += new System.EventHandler(this.pbxCards5_Click);
            // 
            // pbxCards4
            // 
            this.pbxCards4.Location = new System.Drawing.Point(484, 372);
            this.pbxCards4.Name = "pbxCards4";
            this.pbxCards4.Size = new System.Drawing.Size(150, 228);
            this.pbxCards4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCards4.TabIndex = 4;
            this.pbxCards4.TabStop = false;
            this.pbxCards4.Click += new System.EventHandler(this.pbxCards4_Click);
            // 
            // pbxCards3
            // 
            this.pbxCards3.Location = new System.Drawing.Point(328, 372);
            this.pbxCards3.Name = "pbxCards3";
            this.pbxCards3.Size = new System.Drawing.Size(150, 228);
            this.pbxCards3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCards3.TabIndex = 3;
            this.pbxCards3.TabStop = false;
            this.pbxCards3.Click += new System.EventHandler(this.pbxCards3_Click);
            // 
            // pbxCards2
            // 
            this.pbxCards2.Location = new System.Drawing.Point(172, 372);
            this.pbxCards2.Name = "pbxCards2";
            this.pbxCards2.Size = new System.Drawing.Size(150, 228);
            this.pbxCards2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCards2.TabIndex = 2;
            this.pbxCards2.TabStop = false;
            this.pbxCards2.Click += new System.EventHandler(this.pbxCards2_Click);
            // 
            // pbxCards1
            // 
            this.pbxCards1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxCards1.Location = new System.Drawing.Point(16, 372);
            this.pbxCards1.Name = "pbxCards1";
            this.pbxCards1.Size = new System.Drawing.Size(150, 228);
            this.pbxCards1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCards1.TabIndex = 1;
            this.pbxCards1.TabStop = false;
            this.pbxCards1.Click += new System.EventHandler(this.pbxCards1_Click);
            // 
            // pbxDeck
            // 
            this.pbxDeck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxDeck.Location = new System.Drawing.Point(698, 13);
            this.pbxDeck.Name = "pbxDeck";
            this.pbxDeck.Size = new System.Drawing.Size(228, 150);
            this.pbxDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDeck.TabIndex = 0;
            this.pbxDeck.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(944, 612);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.lblBettingPoints);
            this.Controls.Add(this.lblTotalPoints);
            this.Controls.Add(this.btnBet);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnDrawReplace);
            this.Controls.Add(this.pbxCards5);
            this.Controls.Add(this.pbxCards4);
            this.Controls.Add(this.pbxCards3);
            this.Controls.Add(this.pbxCards2);
            this.Controls.Add(this.pbxCards1);
            this.Controls.Add(this.pbxDeck);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Card Game";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDeck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxDeck;
        private System.Windows.Forms.PictureBox pbxCards1;
        private System.Windows.Forms.PictureBox pbxCards2;
        private System.Windows.Forms.PictureBox pbxCards3;
        private System.Windows.Forms.PictureBox pbxCards4;
        private System.Windows.Forms.PictureBox pbxCards5;
        private System.Windows.Forms.Button btnDrawReplace;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btnBet;
        private System.Windows.Forms.Label lblTotalPoints;
        private System.Windows.Forms.Label lblBettingPoints;
        private System.Windows.Forms.Button btnNewGame;
    }
}