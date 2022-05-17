using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Objects
{
    public class Adres
    {
        public string Straat { get; private set; }
        public string Nummer { get; private set; }
        public string Stad { get; private set; }
        public string Postcode { get; private set; }

        public Adres(string straat, string nummer, string stad, string postcode)
        {
            Straat = straat;
            Nummer = nummer;
            Stad = stad;
            Postcode = postcode;
        }
    }
}
