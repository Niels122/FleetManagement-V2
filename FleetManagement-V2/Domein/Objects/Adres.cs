using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Objects
{
    public class Adres
    {
        public string Straat { get; set; }
        public string Nummer { get; set; }
        public string Stad { get; set; }
        public string Postcode { get; set; }

        public Adres(string straat, string nummer, string stad, string postcode)
        {
            Straat = straat;
            Nummer = nummer;
            Stad = stad;
            Postcode = postcode;
        }
    }
}
