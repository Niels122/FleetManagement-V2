using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistentie
{
    public class VoertuigRepository : IVoertuigRepository
    {
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
    }
}
