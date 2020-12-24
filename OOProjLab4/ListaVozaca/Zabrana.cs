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
    public partial class Zabrana : Form
    {
        #region Properties

        public List<Podaci.Kategorija> ImaDozvole
        {
            get;
            set;
        }
        public List<Podaci.Zabrana> ImaZabrane
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public Zabrana()
        {
            InitializeComponent();
        }

        public Zabrana(List<Podaci.Kategorija> poseduje, List<Podaci.Zabrana> zabranjeno) : this()
        {
            ImaDozvole = poseduje;
            ImaZabrane = zabranjeno;
        }

        #endregion

        #region Methods

        private bool Validacija()
        {
            // sva polja treba da budu popunjena pre dodavanja nove dozvole
            if (cbKategorije.Text.Length > 0 && dtpDatumDo.Value.ToString().Length > 0 && dtpDatumOd.Value.ToString().Length > 0
                && dtpDatumDo.Value.Date > dtpDatumOd.Value.Date)
            {
                bool moze = false;
                foreach (Podaci.Zabrana zz in ImaZabrane)
                {
                    if (zz.Oznaka == cbKategorije.Text)
                    {
                        return false;
                    }
                }
                foreach (Podaci.Kategorija kz in ImaDozvole)
                {
                    if(kz.Oznaka == cbKategorije.Text)
                    {
                        moze = true;
                    }
                }
                return moze;
            }
            return false;
        }

        #endregion

        #region EventHandlers
        private void btnProsledi_Click(object sender, EventArgs e)
        {
            if (Validacija())
            {
                Podaci.Zabrana nova = new Podaci.Zabrana(cbKategorije.Text, dtpDatumOd.Value, dtpDatumDo.Value);
                ImaZabrane.Add(nova);

                MessageBox.Show("Zabrana je uspesno dodata.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Molim Vas popunite sva polja validnim podacima!\nDupliranje zabrana je zabranjeno!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Forma ce biti zatvorena", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion
    }
}
