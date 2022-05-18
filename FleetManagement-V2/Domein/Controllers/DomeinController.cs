using Domein.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Controllers
{
    public class DomeinController
    {
        private VoertuigController _vc;
        private TankkaartController _tc;
        private BestuurderController _bc;

        public DomeinController(VoertuigController vc, TankkaartController tc, BestuurderController bc)
        {
            _vc = vc;
            _tc = tc;
            _bc = bc;
        }

        #region Bestuurder
        public List<List<string>> GeefBestuurders()
        {
            return _bc.GeefBestuurders()
                .Select(bestuurder => new List<string>()
                {
                    bestuurder.Naam,
                    bestuurder.Voornaam,
                    bestuurder.Geboortedatum.ToString(),
                    bestuurder.Rijksregisternummer,
                    bestuurder.Rijbewijs.ToString(),
                })
                .ToList();
        }
        #endregion

        #region Tankkaart

        #endregion

        #region Voertuig
        public List<List<string>> GeefVoertuigen()
        {
            return _vc.GeefVoertuigen()
                .Select(voertuig => new List<string>()
                {
                    voertuig.Merk,
                    voertuig.Model,
                    voertuig.Chassisnummer,
                    voertuig.Nummerplaat,
                    voertuig.Brandstoftype.ToString(),
                    voertuig.Wagentype.ToString(),
                    voertuig.Kleur,
                    voertuig.AantalDeuren.ToString(),
                })
                .ToList();
        }

        //public List<Voertuig> GeefVoertuigen()
        //{
        //    return _vc.GeefVoertuigen();
        //}
        #endregion
    }
}
