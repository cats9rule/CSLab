
namespace CardGame.View
{
    partial class StartingSetup
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
            this.label1 = new System.Windows.Forms.Label();
            this.nubPoints = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbColour = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nubPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose starting points: ";
            // 
            // nubPoints
            // 
            this.nubPoints.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nubPoints.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nubPoints.Location = new System.Drawing.Point(206, 16);
            this.nubPoints.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nubPoints.Name = "nubPoints";
            this.nubPoints.Size = new System.Drawing.Size(141, 26);
            this.nubPoints.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose deck colour: ";
            // 
            // cbColour
            // 
            this.cbColour.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbColour.FormattingEnabled = true;
            this.cbColour.Items.AddRange(new object[] {
            "random",
            "red",
            "green",
            "blue",
            "yellow",
            "purple",
            "gray"});
            this.cbColour.Location = new System.Drawing.Point(206, 56);
            this.cbColour.Name = "cbColour";
            this.cbColour.Size = new System.Drawing.Size(141, 27);
            this.cbColour.TabIndex = 3;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(138, 104);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(89, 34);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "OK";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // StartingSetup
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 155);
            this.ControlBox = false;
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cbColour);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nubPoints);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(379, 189);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(379, 189);
            this.Name = "StartingSetup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup your game";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.nubPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nubPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbColour;
        private System.Windows.Forms.Button btnConfirm;
    }
}