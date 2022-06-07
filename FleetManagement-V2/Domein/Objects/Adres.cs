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
        public int? BestuurderId { get; set; }

        public Adres(int adresId, string straat, string nummer, int postcode, string stad, int? bestuurderId = null)
        {
            AdresId = adresId;
            Straat = straat;
            Nummer = nummer;
            Postcode = postcode;
            Stad = stad;
            BestuurderId = bestuurderId;
        }

        public override string ToString()
        {
            return string.Format("AdresId: {0}, Straat: {1}, Nummer: {2}, Stad: {3}, Postcode: {4}, BestuurderId: {5}",
                AdresId, Straat, Nummer, Stad, Postcode, BestuurderId);
        }

        //public List<Voertuig> GeefVoertuigen(bool metBestuurder = true) //linken van voertuig aan bestuurder
        //{
        //    var result = _vc.GeefVoertuigen();
        //    if (metBestuurder)
        //    {
        //        var bestuurders = _bc.GeefBestuurders();
        //        foreach (var bestuurder in bestuurders)
        //        {
        //            var voertuig = result.Where(v => v.Id == bestuurder.VoertuigId).FirstOrDefault();
        //            voertuig.Bestuurder = bestuurder;

        //        }

        //    }
        //    return result;
        //}
    }
}
