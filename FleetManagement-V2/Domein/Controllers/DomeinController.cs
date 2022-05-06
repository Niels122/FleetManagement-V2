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

        public List<List<String>> GeefBestuurders()
        {
            return _bc.GeefBestuurders();
        }
    }
}
