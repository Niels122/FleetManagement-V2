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
        List<int> GeefChassisnummers();
        List<string> GeefNummerplaten();

        #region CRUD operations
        void CreateVoertuig(Voertuig voertuig);
        Voertuig ReadVoertuig();
        void UpdateVoertuig(Voertuig voertuig);
        void DeleteVoertuig(Voertuig voertuig);
        #endregion
    }
}
