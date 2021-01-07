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
        private bool _izmena;
        private List<Podaci.Osoba> lista;
        private string putanja;

        #endregion


        public Vozac()
        {
            InitializeComponent();
            vozac = null;
            _izmena = false;
            putanja = "";
        }
        public Vozac(ref List<Podaci.Osoba> l)
        {
            InitializeComponent();
            vozac = null;
            _izmena = false;
            putanja = "";
            lista = l;
        }

        public Vozac(ref Podaci.Osoba o, ref List<Podaci.Osoba> l)
        {
            InitializeComponent();
            vozac = o;
            _izmena = true;
            lista = l;
            putanja = o.SlikaPath;

            tbIme.Text = vozac.Ime;
            tbPrezime.Text = vozac.Prezime;
            dtpDatumRodj.Value = vozac.Rodjendan;
            dtpDozvolaOd.Value = vozac.VazenjeOd;
            dtpDozvolaDo.Value = vozac.VazenjeDo;
            tbBrVozacke.Text = vozac.BrVozacke;
            tbMesto.Text = vozac.MestoIzdavanja;
            cbPol.Text = vozac.Pol.ToString();

            dgvKategorije.DataSource = vozac.Dozvole.ToList();
            dgvKategorije.Update();
            dgvKategorije.Refresh();
            dgvZabrane.DataSource = vozac.Zabrane.ToList();
            dgvZabrane.Update();
            dgvZabrane.Refresh();

            picBoxLicna.Image = Image.FromFile(putanja);
        }

        #region Methods

        public bool Validacija()
        {
            if (String.IsNullOrEmpty(tbIme.Text))
            {
                MessageBox.Show("Ime je prazno!", "Greska", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(tbPrezime.Text))
            {
                MessageBox.Show("Prezime je prazno!", "Greska", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(tbBrVozacke.Text))
            {
                MessageBox.Show("Broj vozacke dozvole je prazno!", "Greska", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(tbMesto.Text))
            {
                MessageBox.Show("Mesto nije specificirano!", "Greska", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(cbPol.Text))
            {
                MessageBox.Show("Niste izabrali pol!", "Greska",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (picBoxLicna.Image == null)
            {
                MessageBox.Show("Slika nije izabrana!", "Greska", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #endregion


        #region EventHandlers

        private void Vozac_Load(object sender, EventArgs e)
        {
            if(vozac != null)
            {
                tbIme.Text = vozac.Ime;
                tbPrezime.Text = vozac.Prezime;
                dtpDatumRodj.Value = vozac.Rodjendan;
                dtpDozvolaOd.Value = vozac.VazenjeOd;
                dtpDozvolaDo.Value = vozac.VazenjeDo;
                tbBrVozacke.Text = vozac.BrVozacke;
                tbMesto.Text = vozac.MestoIzdavanja;
                cbPol.Text = vozac.Pol.ToString();

                dgvKategorije.DataSource = vozac.Dozvole.ToList();
                dgvKategorije.Update();
                dgvKategorije.Refresh();
                dgvZabrane.DataSource = vozac.Zabrane.ToList();
                dgvZabrane.Update();
                dgvZabrane.Refresh();

                picBoxLicna.Image = Image.FromFile(putanja);
                picBoxLicna.ImageLocation = putanja;
            }
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            OpenFileDialog res = new OpenFileDialog();
            res.ShowDialog();
            string path = res.FileName;
            if (path != "")
            {
                picBoxLicna.Image = Image.FromFile(path);
                picBoxLicna.ImageLocation = path;
                putanja = path;
                MessageBox.Show("Postavljena je slika.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Greska pri dodavanju slike.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        private void btnDodajKategoriju_Click(object sender, EventArgs e)
        {
            Kategorija form = new Kategorija();
            DialogResult res = form.DialogResult;
            if(res == DialogResult.OK)
            {
                // dodata je nova kategorija
                dgvKategorije.Update();
                dgvKategorije.Refresh();
            }
        }

        private void btnObrisiKategoriju_Click(object sender, EventArgs e)
        {
            if (dgvKategorije.SelectedRows.Count == 0)
                return;

            DialogResult res = MessageBox.Show("Da li zelite da obrisete ovu kategoriju?", 
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == System.Windows.Forms.DialogResult.No)
                return;

            int ind = dgvKategorije.SelectedRows[0].Index;
            Podaci.Kategorija K = vozac.Dozvole[ind];
            vozac.Dozvole.RemoveAt(ind);
            if (vozac.Dozvole.Contains(K))
            {
                MessageBox.Show("Doslo je do greske pri brisanju.", "Greska", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Brisanje uspesno.", "Obavestenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDodajZabranu_Click(object sender, EventArgs e)
        {
            Zabrana form = new Zabrana();
            DialogResult res = form.DialogResult;
            if (res == DialogResult.OK)
            {
                // dodata je nova kategorija
                dgvZabrane.Update();
                dgvZabrane.Refresh();
            }
        }

        private void btnObrisiZabranu_Click(object sender, EventArgs e)
        {
            if (dgvKategorije.SelectedRows.Count == 0)
                return;

            DialogResult res = MessageBox.Show("Da li zelite da obrisete ovu zabranu?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == System.Windows.Forms.DialogResult.No)
                return;

            int ind = dgvZabrane.SelectedRows[0].Index;
            Podaci.Zabrana Z = vozac.Zabrane[ind];
            vozac.Zabrane.RemoveAt(ind);
            if (vozac.Zabrane.Contains(Z))
            {
                MessageBox.Show("Doslo je do greske pri brisanju.", "Greska",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Brisanje uspesno.", "Obavestenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnProsledi_Click(object sender, EventArgs e)
        {
            if (Validacija()) 
            {
                if (_izmena)
                {
                    // vozac vec postoji, treba ga menjati
                    // postoji lista vozaca
                    vozac.Ime = tbIme.Text; //tbIme.Text = vozac.Ime;
                    vozac.Prezime = tbPrezime.Text;  // tbPrezime.Text = vozac.Prezime;
                    vozac.Rodjendan = dtpDatumRodj.Value; //dtpDatumRodj.Value = vozac.Rodjendan;
                    vozac.VazenjeOd = dtpDozvolaOd.Value; //dtpDozvolaOd.Value = vozac.VazenjeOd;
                    vozac.VazenjeDo = dtpDozvolaDo.Value; //dtpDozvolaDo.Value = vozac.VazenjeDo;
                    vozac.BrVozacke = tbBrVozacke.Text;  //tbBrVozacke.Text = vozac.BrVozacke;
                    vozac.MestoIzdavanja = tbMesto.Text;
                    vozac.Pol = cbPol.Text;

                    vozac.SlikaPath = putanja;

                    MessageBox.Show("Izmena vozaca uspesna.", "Obavestenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // potrebno je dodati
                    Podaci.Osoba o = new Podaci.Osoba(tbIme.Text, tbPrezime.Text, dtpDatumRodj.Value,
                        tbBrVozacke.Text, tbMesto.Text, dtpDozvolaOd.Value, dtpDozvolaDo.Value,  
                        cbPol.SelectedItem.ToString(), putanja);
                    lista.Add(o);
                    MessageBox.Show("Dodavanje vozaca uspesno.", "Obavestenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Close();
                DialogResult = System.Windows.Forms.DialogResult.OK; 
            }
            return;
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Forma ce biti zatvorena", "Obavestenje", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void dgvKategorije_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int ind = e.RowIndex;
            dgvKategorije.Rows[ind].Selected = true;
        }
        private void dgvZabrane_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int ind = e.RowIndex;
            dgvZabrane.Rows[ind].Selected = true;
        }


        private void tbIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                //MessageBox.Show("Mozete uneti samo karaktere", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tbPrezime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                //MessageBox.Show("Mozete uneti samo karaktere", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tbBrVozacke_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                //MessageBox.Show("Mozete uneti samo brojeve", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tbMesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                //MessageBox.Show("Mozete uneti samo karaktere", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
