using Domein.Objects;
using Domein.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public class DomeinController
    {
        private VoertuigController _voertuigCon;
        private TankkaartController _tankkaartCon;
        private BestuurderController _bestuurderCon;
        private AdresController _adresCon;

        public DomeinController(VoertuigController vc, TankkaartController tc, BestuurderController bc, AdresController ac)
        {
            _voertuigCon = vc;
            _tankkaartCon = tc;
            _bestuurderCon = bc;
            _adresCon = ac;
        }

        //public List<Bestuurder> Geef

        #region Bestuurder
        public List<Bestuurder> GeefBestuurders()
        {
            return _bestuurderCon.GeefBestuurders();
        }
        #endregion

        #region Adres
        public List<Adres> GeefAdressen()
        {
            return _adresCon.GeefAdressen();
        }
        #endregion

        #region Tankkaart
        public List<Tankkaart> GeefTankkaarten()
        {
            return _tankkaartCon.GeefTankkaarten();
        }
        #endregion

        #region Voertuig
        public List<Voertuig> GeefVoertuigen()
        {
            return _voertuigCon.GeefVoertuigen();
        }
        #endregion


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
