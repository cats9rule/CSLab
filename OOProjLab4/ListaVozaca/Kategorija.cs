using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Podaci;

namespace ListaVozaca
{
    public partial class Kategorija : Form
    {
        public List<Podaci.Kategorija> ImaDozvole
        {
            get;
            set;
        }

        #region Constructors
        public Kategorija()
        {
            InitializeComponent();
        }
        public Kategorija(ref List<Podaci.Kategorija> poseduje) : this()
        {
            ImaDozvole = poseduje;
        }
        #endregion

        #region Methods

        private bool Validacija()
        {
            // sva polja treba da budu popunjena pre dodavanja nove dozvole
            if(cbKategorije.Text.Length > 0 && dtpDatumDo.Value.ToString().Length > 0 && dtpDatumOd.Value.ToString().Length >0 
                && dtpDatumDo.Value.Date > dtpDatumOd.Value.Date)
            {
                bool nema = true;
                foreach(Podaci.Kategorija kz in ImaDozvole)
                {
                    if (kz.Oznaka == cbKategorije.Text)
                    {
                        nema = false;
                    }
                }
                return nema;
            }
            return false;
        }

        #endregion

        #region EventHandlers
        private void btnZatvori_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Forma ce biti zatvorena", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void btnProsledi_Click(object sender, EventArgs e)
        {
            if (Validacija())
            {
                Podaci.Kategorija nova = new Podaci.Kategorija(cbKategorije.Text, dtpDatumOd.Value, dtpDatumDo.Value);
                ImaDozvole.Add(nova);

                MessageBox.Show("Dozvola je uspesno dodata.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Molim Vas popunite sva polja validnim podacima!\nDupliranje dozvola je zabranjeno!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
