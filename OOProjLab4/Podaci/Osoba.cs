using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podaci
{
    public class Osoba
    {
        #region Attributes

        private string _ime, _prezime;

        private DateTime _rodjendan;
        private string _brVozacke;
        private string _mestoIzdavanja;
        private DateTime _vazenjeOd, _vazenjeDo;
        private char _pol;
        private string _slikaPath;

        private List<Kategorija> dozvole;
        private List<Zabrana> zabrane;

        #endregion

        #region Properties

        public string Ime { get; set; }
        public string Prezime { get; set; }

        [Browsable(false)]
        public DateTime Rodjendan
        {
            get
            {
                return _rodjendan.Date;
            }
            set
            {
                if(value.Date.Year < DateTime.Today.Year)
                {
                    _rodjendan = value;
                }
            }
        }

        [DisplayName("Broj vozacke dozvole")]
        public string BrVozacke { get; set; }
        [Browsable(false)]
        public string MestoIzdavanja { get; set; }
        [Browsable(false)]
        public DateTime VazenjeOd
        {
            get
            {
                return _vazenjeOd;
            }
            set
            {
                if (value.Date <= DateTime.Today)
                {
                    _vazenjeOd = value;
                }
            }
        }
        [Browsable(false)]
        public DateTime VazenjeDo
        {
            get
            {
                return _vazenjeDo;
            }
            set
            {
                if (value.Date > _vazenjeOd)
                {
                    _vazenjeOd = value;
                }
            }
        }
        [Browsable(false)]
        public char Pol
        {
            get
            {
                return _pol;
            }
            set
            {
                if(value!='M' && value!='Z')
                {
                    _pol = 'D';
                }
                else
                {
                    _pol = value;
                }
            }
        }
        [Browsable(false)]
        public string SlikaPath
        {
            get
            {
                return _slikaPath;
            }
            set
            {
                if (System.IO.File.Exists(value))
                {
                    _slikaPath = value;
                }
                else
                {
                    _slikaPath = "";
                }
            }
        }

        [Browsable(false)]
        public List<Kategorija> Dozvole { get; set; }
        [Browsable(false)]
        public List<Zabrana> Zabrane { get; set; }

        #endregion

        #region Constructors

        public Osoba() { }
        public Osoba(string i, string p, DateTime r, string brVoz, string mesto, DateTime od, DateTime doo, char pol, string path)
        {
            _ime = i;
            _prezime = p;
            Rodjendan = r;
            _brVozacke = brVoz;
            _mestoIzdavanja = mesto;
            VazenjeOd = od;
            VazenjeDo = doo;
            Pol = pol;
            SlikaPath = path;

            dozvole = new List<Kategorija>();
            zabrane = new List<Zabrana>();
        }

        #endregion

        #region Methods

        public bool ChangePic(string path)
        {
            if (System.IO.File.Exists(path))
            {
                _slikaPath = path;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Update(string i, string p, DateTime r, string brVoz, string mesto, DateTime od, DateTime doo, char pol)
        {
            _ime = i;
            _prezime = p;
            Rodjendan = r;
            _brVozacke = brVoz;
            _mestoIzdavanja = mesto;
            VazenjeOd = od;
            VazenjeDo = doo;
            Pol = pol;
        }

        #endregion
    }
}
