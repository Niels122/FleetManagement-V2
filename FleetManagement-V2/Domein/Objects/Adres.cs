using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Objects
{
    public class Adres
    {   
        public int AdresId { get; private set; }
        public string Straat { get; private set; }
        public string Nummer { get; private set; }
        public int Postcode { get; private set; }
        public string Stad { get; private set; }

        public Adres(int adresId, string straat, string nummer, int postcode, string stad)
        {
            AdresId = adresId;
            Straat = straat;
            Nummer = nummer;
            Postcode = postcode;
            Stad = stad;
        }



        public override string ToString()
        {
            return string.Format("AdresId: {0}, Straat: {1}, Nummer: {2}, Stad: {3}, Postcode: {4}",
                AdresId, Straat, Nummer, Stad, Postcode);
        }
    }
}
