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
        public List<Bestuurder> GeefBestuurders()
        {
            return _bc.GeefBestuurders();
        }
        #endregion



        #region Tankkaart

        #endregion


        #region Voertuig
        public List<Voertuig> GeefVoertuigen(bool metBestuurder = true) //linken van voertuig aan bestuurder
        {
            var result = _vc.GeefVoertuigen();
            if (metBestuurder)
            {
                var bestuurders = _bc.GeefBestuurders();
                foreach (var bestuurder in bestuurders)
                {
                    var voertuig = result.Where(v => v.Id == bestuurder.VoertuigId).FirstOrDefault();
                    voertuig.Bestuurder = bestuurder;

                }

            }
            return result;



        }
        //public List<Voertuig> GeefVoertuigen()
        //{
        //    return _vc.GeefVoertuigen();
        //}
        #endregion
    }
}
