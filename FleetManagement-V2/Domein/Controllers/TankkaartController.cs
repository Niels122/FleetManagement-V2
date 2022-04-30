using Domein.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Controllers
{
    public class TankkaartController
    {
        private ITankkaartRepository _tankkaartRepo;

        public TankkaartController(ITankkaartRepository tankkaartRepo)
        {
            _tankkaartRepo = tankkaartRepo;
        }
    }
}
