using Domein.Interfaces;
using Domein.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistentie
{
    public class VoertuigRepository : IVoertuigRepository
    {
        //TODO: implement interface
        public void CreateVoertuig(Voertuig voertuig)
        {
            throw new NotImplementedException();
        }

        public void DeleteVoertuig(Voertuig voertuig)
        {
            throw new NotImplementedException();
        }

        public List<int> GeefChassisnummers()
        {
            List<int> chassisnummers = new List<int>();

            return chassisnummers;
        }

        public List<string> GeefNummerplaten()
        {
            List<string> nummerplaten = new List<string>();

            return nummerplaten;
        }

        public List<Voertuig> GeefVoertuigen()
        {
            throw new NotImplementedException();
        }

        public Voertuig ReadVoertuig()
        {
            throw new NotImplementedException();
        }

        public void UpdateVoertuig(Voertuig voertuig)
        {
            throw new NotImplementedException();
        }
    }
}
