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



        #region Bestuurder
        public List<Bestuurder> GeefBestuurders()
        {
            return _bestuurderCon.GeefBestuurders();
        }
        public void CreateBestuurder(Bestuurder bestuurder)
        {
            _bestuurderCon.CreateBestuurder(bestuurder);
        }

        public void UpdateBestuurder(Bestuurder bestuurder)
        {
            _bestuurderCon.UpdateBestuurder(bestuurder);
        }

        public void DeleteBestuurder(Bestuurder bestuurder)
        {
            _bestuurderCon.DeleteBestuurder(bestuurder);
        }
        #endregion




        #region Adres
        public List<Adres> GeefAdressen()
        {
            return _adresCon.GeefAdressen();
        }

        public List<Adres> GeefAdressenMetBestuurder()
        {
            List<Adres> adressen = new List<Adres>();
            foreach (Adres adres in _adresCon.GeefAdressen())
            {
                adres.BestuurderId = _bestuurderCon.GeefBestuurderByAdresId(adres.AdresId);
                adressen.Add(adres);
            }
            return adressen;
        }

        public void CreateAdres(Adres adres)
        {
            _adresCon.CreateAdres(adres);
        }
        public void UpdateAdres(Adres adres)
        {
            _adresCon.UpdateAdres(adres);
        }
        public void DeleteAdres(Adres adres)
        {
            _adresCon.DeleteAdres(adres);
        }

        #endregion




        #region Tankkaart
        public List<Tankkaart> GeefTankkaarten()
        {
            return _tankkaartCon.GeefTankkaarten();
        }

        public void CreateTankkaart(Tankkaart tankkaart)
        {
            _tankkaartCon.CreateTankkaart(tankkaart);
        }

        public void DeleteTankkaart(Tankkaart tankkaart)
        {
            _tankkaartCon.DeleteTankkaart(tankkaart);
        }
        public void UpdateTankkaart(Tankkaart tankkaart)
        {
            _tankkaartCon.UpdateTankkaart(tankkaart);
        }
        #endregion



        #region Voertuig
        public List<Voertuig> GeefVoertuigen()
        {
            return _voertuigCon.GeefVoertuigen();
        }
        public void CreateVoertuig(Voertuig voertuig)
        {
            _voertuigCon.CreateVoertuig(voertuig);
        }

        public void DeleteVoertuig(Voertuig voertuig)
        {
            _voertuigCon.DeleteVoertuig(voertuig);

        }
        public void UpdateVoertuig(Voertuig oudVoertuig, Voertuig nieuwVoertuig)
        {
            _voertuigCon.UpdateVoertuig(oudVoertuig, nieuwVoertuig);

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
