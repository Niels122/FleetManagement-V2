using Domein.Interfaces;
using Domein.Objects;
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

        public List<Tankkaart> GeefTankkaarten()
        {
            return _tankkaartRepo.GeefTankkaarten();
        }
        public void CreateTankkaart(Tankkaart tankkaart)
        {
            _tankkaartRepo.CreateTankkaart(tankkaart);
        }

        public void DeleteTankkaart(Tankkaart tankkaart)
        {
            _tankkaartRepo.DeleteTankkaart(tankkaart);
        }
        public void UpdateTankkaart(Tankkaart tankkaart)
        {
            _tankkaartRepo.UpdateTankkaart(tankkaart);
        }
    }
}
