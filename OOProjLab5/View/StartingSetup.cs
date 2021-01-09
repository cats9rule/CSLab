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

namespace CardGame.View
{
    public partial class StartingSetup : Form
    {
        private GameController controller;

        public StartingSetup()
        {
            InitializeComponent();
        }
        public StartingSetup(ref GameController c) 
            : this()
        {
            controller = c;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(nubPoints.Value > 0 && cbColour.SelectedIndex >= 0)
            {
                controller.CreateDeck((string)cbColour.SelectedItem);
                controller.SetPoints((int)nubPoints.Value);
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
