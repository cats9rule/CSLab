using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podaci
{
    public class Kategorija // klasa se koristi i kao zabrana - poseduje potpuno iste atribute
    {
        #region Attributes

        private string _oznaka;
        private DateTime _datumOd;
        private DateTime _datumDo;

        #endregion

        #region Properties

        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if(value != "AM" && value != "A1" && value != "A2" && value != "A" && value != "B1" && value != "B"
                    && value != "BE" && value != "C1" && value != "C1E" && value != "C" && value != "CE" && value != "D1"
                    && value != "D1E" && value != "D" && value != "DE" && value != "F" && value != "M")
                {
                    // oznaka kategorije nije validna
                    _oznaka = "";
                }
                else
                {
                    _oznaka = value;
                }
            }
        }
        public DateTime DatumOd
        {
            get
            {
                return _datumOd;
            }
            set
            {
                _datumOd = value;
            }
        }
        public DateTime DatumDo
        {
            get
            {
                return _datumDo;
            }
            set
            {
                if(_datumOd < _datumDo)
                {
                    _datumDo = value;
                }
            }
        }

        #endregion

        #region Constructors

        public Kategorija() { }
        public Kategorija(string o, DateTime od, DateTime doo)
        {
            Oznaka = o;
            _datumOd = od;
            DatumDo = doo;
        }

        #endregion

        #region Methods



        #endregion
    }
}
