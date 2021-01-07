using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        #region Constructors
        public ListaVozaca()
        {
            InitializeComponent();
            vozaci = new List<Podaci.Osoba>();
        }
        #endregion

        #region Methods

        DialogResult CloseMe()
        {
            return MessageBox.Show("Da li ste sigurni da zelite da zatvorite formu?", "Obavestenje", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public void LoadFromFile(String putanja)
        {
            using (StreamReader sr = new StreamReader(putanja))
            {
                int brojVozaca = int.Parse(sr.ReadLine());
                for (int i = 0; i < brojVozaca; i++)
                {
                    Podaci.Osoba o = new Podaci.Osoba();
                    o.Ime = sr.ReadLine();
                    o.Prezime = sr.ReadLine();
                    o.BrVozacke = sr.ReadLine();
                    o.Rodjendan = DateTime.Parse(sr.ReadLine());
                    o.VazenjeOd = DateTime.Parse(sr.ReadLine());
                    o.VazenjeDo = DateTime.Parse(sr.ReadLine());
                    o.MestoIzdavanja = sr.ReadLine();
                    o.Pol = sr.ReadLine();
                    o.SlikaPath = sr.ReadLine();

                    String linija = sr.ReadLine();
                    String dtOd, dtDo;
                    if (linija == "Dozvole")
                    {
                        linija = sr.ReadLine();
                        while (linija != "Zabrane")
                        {
                            dtOd = sr.ReadLine();
                            dtDo = sr.ReadLine();
                            Podaci.Kategorija k = new Podaci.Kategorija(linija, DateTime.Parse(dtOd), DateTime.Parse(dtDo));
                            o.dozvole.Add(k);

                            linija = sr.ReadLine();
                        }
                        if (linija == "Zabrane")
                        {
                            linija = sr.ReadLine();
                            while (linija != "" && linija != null)
                            {
                                dtOd = sr.ReadLine();
                                dtDo = sr.ReadLine();
                                Podaci.Zabrana z = new Podaci.Zabrana(linija, DateTime.Parse(dtOd), DateTime.Parse(dtDo));
                                o.zabrane.Add(z);

                                linija = sr.ReadLine();
                            }
                        }
                    }
                    vozaci.Add(o);
                }
            }
        }

        public void SaveToFile(String putanja)
        {
            using (StreamWriter sw = new StreamWriter(putanja))
            {
                sw.WriteLine(vozaci.Count);
                foreach (Podaci.Osoba o in vozaci)
                {
                    sw.WriteLine(o.Ime);
                    sw.WriteLine(o.Prezime);
                    sw.WriteLine(o.BrVozacke);
                    sw.WriteLine(o.Rodjendan.ToString());
                    sw.WriteLine(o.VazenjeOd.ToString());
                    sw.WriteLine(o.VazenjeDo.ToString());
                    sw.WriteLine(o.MestoIzdavanja);
                    sw.WriteLine(o.Pol);
                    sw.WriteLine(o.SlikaPath);

                    sw.WriteLine("Dozvole");
                    foreach (Podaci.Kategorija k in o.dozvole)
                    {
                        sw.WriteLine(k.Oznaka);
                        sw.WriteLine(k.DatumOd.ToString());
                        sw.WriteLine(k.DatumDo.ToString());
                    }

                    sw.WriteLine("Zabrane");
                    foreach (Podaci.Zabrana k in o.zabrane)
                    {
                        sw.WriteLine(k.Oznaka);
                        sw.WriteLine(k.DatumOd.ToString());
                        sw.WriteLine(k.DatumDo.ToString());
                    }


                    sw.WriteLine();
                }
            }
        }

        public Podaci.Osoba GetByID(string brvoz)
        {
            foreach(Podaci.Osoba osb in vozaci)
            {
                if(osb.BrVozacke == brvoz)
                {
                    return osb;
                }
            }
            return null;
        }

        private void OsveziGrid()
        {
            dgvVozaci.DataSource = vozaci.ToList();

            if (dgvVozaci.RowCount > 0)
            { 
                btnObrisi.Enabled = true;
                btnIzmeni.Enabled = true;
            }
            else
            {
                btnObrisi.Enabled = false;
                btnIzmeni.Enabled = false;
            }
        }

        #endregion

        #region EventHandlers

        private void ListaVozaca_Load(object sender, EventArgs e)
        {
            btnObrisi.Enabled = false;
            btnIzmeni.Enabled = false;
            lblVreme.Text = String.Empty;
            dgvVozaci.DataSource = vozaci;

            DialogResult res = MessageBox.Show("Ucitati podatke iz fajla?", "Obavestenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                OpenFileDialog findFile = new OpenFileDialog(); ;
                findFile.ShowDialog();
                String putanja = findFile.FileName;
                if (putanja != "")
                {
                    LoadFromFile(putanja);
                    OsveziGrid();
                }
                else
                    findFile.ShowDialog();
            }

            tmrVreme.Start();
        }

        private void ListaVozaca_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Da li zelite da sacuvate podatke u fajl?", "Obavestenje", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                OpenFileDialog fileDlg = new OpenFileDialog(); ;
                fileDlg.ShowDialog();
                String putanja = fileDlg.FileName;
                if (putanja != "")
                    SaveToFile(putanja);
                else
                    fileDlg.ShowDialog();
            }

            if (CloseMe() == DialogResult.No)
                e.Cancel = true;
        }

        private void tmrVreme_Tick(object sender, EventArgs e)
        {
            lblVreme.Text = DateTime.Now.ToString("HH:mm:ss dd.MM.yyyy.");
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Vozac form = new Vozac(ref vozaci);
            DialogResult res = form.ShowDialog();
            if(res == DialogResult.OK)
            {
                OsveziGrid();
            }
            
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvVozaci.SelectedRows.Count == 0)
                return;

            int ind = dgvVozaci.SelectedRows[0].Index;

            Podaci.Osoba vozac = vozaci[ind];

            Vozac form = new Vozac(ref vozac, ref vozaci);
            DialogResult res = form.ShowDialog();
            if(res == DialogResult.OK)
            {
                OsveziGrid();
            }

        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvVozaci.SelectedRows.Count == 0)
                return;

            DialogResult res = MessageBox.Show("Da li zelite da obrisete selektovanog vozaca?", "Obavestenje",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.No)
                return;

            int ind = dgvVozaci.SelectedRows[0].Index;

            Podaci.Osoba o = vozaci[ind];
            vozaci.RemoveAt(ind);
            if (vozaci.Contains(o))
            {
                MessageBox.Show("Doslo je do greske pri brisanju.", "Greska",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Brisanje uspesno.", "Obavestenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                OsveziGrid();
            }

        }

        #endregion


        private void dgvVozaci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //selektovanje bilo koje cell selektuje ceo red
            int index = e.RowIndex;
            dgvVozaci.Rows[index].Selected = true;
        }
    }
}
