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
    public partial class ListaVozaca : Form
    {
        #region Attributes

        private List<Podaci.Osoba> vozaci;

        #endregion

        #region Properties

        public List<Podaci.Osoba> Vozaci { get; set; }

        #endregion


        public ListaVozaca()
        {
            InitializeComponent();
            dgvVozaci.DataSource = vozaci.ToString();
        }

        private void ListaVozaca_Load(object sender, EventArgs e)
        {
            btnObrisi.Enabled = false;
            btnIzmeni.Enabled = false;
            lblVreme.Text = String.Empty;

            DialogResult dlg = MessageBox.Show("Ucitati podatke iz fajla?", "Obavestenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                OpenFileDialog fileDlg = new OpenFileDialog(); ;
                fileDlg.ShowDialog();
                String putanja = fileDlg.FileName;
                if (putanja != "")
                {
                    // ListaVozaca.izFajla(putanja);
                    // ucitavanjePodataka();
                }
                else
                    fileDlg.ShowDialog();
            }

            tmrVreme.Start();
        }
    }
}
