using Domein.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Interfaces
{
     public interface IVoertuigRepository
    {
        List<Voertuig> GeefVoertuigen();

        void CreateVoertuig(Voertuig voertuig);

        void UpdateVoertuig(Voertuig voertuig);

        void DeleteVoertuig(Voertuig voertuig);

        void RetrieveVoertuig(Voertuig voertuig);
    }
}
