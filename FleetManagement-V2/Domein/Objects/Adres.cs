using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domein.Exceptions;

namespace Domein.Objects
{
    public class Adres
    {   
        public int AdresId { get; private set; }
        public string Straat { get; private set; }
        public string Nummer { get; private set; }
        public int Postcode { get; private set; }
        public string Stad { get; private set; }
        public string BestuurderId { get; set; }

        public Adres(int adresId, string straat, string huisnummer, int postcode, string stad, string bestuurderId = null)
        {
            AdresId = adresId;
            SetStraat(straat);
            SetHuisnummer(huisnummer);
            SetPostcode(postcode);
            SetStad(stad);
            SetBestuurderId(bestuurderId);
        }

        #region
        public void SetStraat(string straat)
        {
            if (string.IsNullOrWhiteSpace(straat))
            {
                throw new AdresException("Straatnaam moet ingevuld zijn.");
            }

            string output = char.ToUpper(straat[0]) + straat.Substring(1);
            Straat = output;
        }

        public void SetHuisnummer(string huisnummer)
        {
            if (string.IsNullOrWhiteSpace(huisnummer))
            {
                throw new AdresException("Huisnummer moet ingevuld zijn.");
            }

            Nummer = huisnummer;
        }

        public void SetPostcode(int postcode)
        {
            if (postcode < 1000 || postcode > 9999)
            {
                throw new AdresException("Postcode is ongdeldig.");
            }

            Postcode = postcode;
        }

        public void SetStad(string stad)
        {
            if (string.IsNullOrWhiteSpace(stad))
            {
                throw new AdresException("Stad moet ingevuld zijn.");
            }

            string output = char.ToUpper(stad[0]) + stad.Substring(1);
            Stad = output;
        }

        public void SetBestuurderId(string bestuurderId)
        {
            BestuurderId = bestuurderId;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("AdresId: {0}, Straat: {1}, Nummer: {2}, Postcode: {3}, Stad: {4}, BestuurderId: {5}",
                AdresId, Straat, Nummer, Postcode, Stad, BestuurderId);
        }

        
    }
}
