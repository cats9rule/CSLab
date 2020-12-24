using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaVozaca
{
    public partial class Vozac : Form
    {
        #region Attributes

        private Podaci.Osoba vozac;

        #endregion


        public Vozac()
        {
            InitializeComponent();
        }
    }
}
