
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
            this.pbxDeck = new System.Windows.Forms.PictureBox();
            this.pbxCards1 = new System.Windows.Forms.PictureBox();
            this.pbxCards2 = new System.Windows.Forms.PictureBox();
            this.pbxCards3 = new System.Windows.Forms.PictureBox();
            this.pbxCards4 = new System.Windows.Forms.PictureBox();
            this.pbxCards5 = new System.Windows.Forms.PictureBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblBetting = new System.Windows.Forms.Label();
            this.btnBet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards5)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxDeck
            // 
            this.pbxDeck.Location = new System.Drawing.Point(698, 13);
            this.pbxDeck.Name = "pbxDeck";
            this.pbxDeck.Size = new System.Drawing.Size(228, 150);
            this.pbxDeck.TabIndex = 0;
            this.pbxDeck.TabStop = false;
            // 
            // pbxCards1
            // 
            this.pbxCards1.Location = new System.Drawing.Point(16, 372);
            this.pbxCards1.Name = "pbxCards1";
            this.pbxCards1.Size = new System.Drawing.Size(150, 228);
            this.pbxCards1.TabIndex = 1;
            this.pbxCards1.TabStop = false;
            // 
            // pbxCards2
            // 
            this.pbxCards2.Location = new System.Drawing.Point(172, 372);
            this.pbxCards2.Name = "pbxCards2";
            this.pbxCards2.Size = new System.Drawing.Size(150, 228);
            this.pbxCards2.TabIndex = 2;
            this.pbxCards2.TabStop = false;
            // 
            // pbxCards3
            // 
            this.pbxCards3.Location = new System.Drawing.Point(328, 372);
            this.pbxCards3.Name = "pbxCards3";
            this.pbxCards3.Size = new System.Drawing.Size(150, 228);
            this.pbxCards3.TabIndex = 3;
            this.pbxCards3.TabStop = false;
            // 
            // pbxCards4
            // 
            this.pbxCards4.Location = new System.Drawing.Point(484, 372);
            this.pbxCards4.Name = "pbxCards4";
            this.pbxCards4.Size = new System.Drawing.Size(150, 228);
            this.pbxCards4.TabIndex = 4;
            this.pbxCards4.TabStop = false;
            // 
            // pbxCards5
            // 
            this.pbxCards5.Location = new System.Drawing.Point(640, 372);
            this.pbxCards5.Name = "pbxCards5";
            this.pbxCards5.Size = new System.Drawing.Size(150, 228);
            this.pbxCards5.TabIndex = 5;
            this.pbxCards5.TabStop = false;
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(806, 459);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(120, 34);
            this.btnReplace.TabIndex = 6;
            this.btnReplace.Text = "Replace Cards";
            this.btnReplace.UseVisualStyleBackColor = true;
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.Location = new System.Drawing.Point(12, 44);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(84, 27);
            this.lblPoints.TabIndex = 7;
            this.lblPoints.Text = "Points: ";
            // 
            // lblBetting
            // 
            this.lblBetting.AutoSize = true;
            this.lblBetting.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBetting.Location = new System.Drawing.Point(11, 85);
            this.lblBetting.Name = "lblBetting";
            this.lblBetting.Size = new System.Drawing.Size(94, 27);
            this.lblBetting.TabIndex = 8;
            this.lblBetting.Text = "Betting: ";
            // 
            // btnBet
            // 
            this.btnBet.Location = new System.Drawing.Point(829, 398);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(75, 55);
            this.btnBet.TabIndex = 9;
            this.btnBet.Text = "Bet!";
            this.btnBet.UseVisualStyleBackColor = true;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(941, 612);
            this.Controls.Add(this.btnBet);
            this.Controls.Add(this.lblBetting);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.pbxCards5);
            this.Controls.Add(this.pbxCards4);
            this.Controls.Add(this.pbxCards3);
            this.Controls.Add(this.pbxCards2);
            this.Controls.Add(this.pbxCards1);
            this.Controls.Add(this.pbxDeck);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.Text = "Card Game";
            ((System.ComponentModel.ISupportInitialize)(this.pbxDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCards5)).EndInit();
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
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblBetting;
        private System.Windows.Forms.Button btnBet;
    }
}