using Domein.Interfaces;
using Domein.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistentie
{
    public class TankkaartRepository : ITankkaartRepository
    {
        //TODO: implement interface
        public void CreateTankkaart(Tankkaart tankkaart)
        {
            throw new NotImplementedException();
        }

        public void DeleteTankkaart(int kaartnummer)
        {
            throw new NotImplementedException();
        }

        public List<Tankkaart> GeefTankkaarten()
        {
            throw new NotImplementedException();
        }

        public List<int> GeefTankkaartnummers()
        {
            List<int> tanknummers = new List<int>();

            return tanknummers;
        }

        public Tankkaart ReadTankkaart(int kaartnummer)
        {
            throw new NotImplementedException();
        }

        public void UpdateTankkaart(Tankkaart tankkaart)
        {
            throw new NotImplementedException();
        }
    }
}
