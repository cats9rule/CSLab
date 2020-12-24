using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podaci
{
    public class Zabrana : Kategorija
    {
        public Zabrana() : base() { }
        public Zabrana(string o, DateTime od, DateTime doo) : base(o, od, doo) { }
    }
}
