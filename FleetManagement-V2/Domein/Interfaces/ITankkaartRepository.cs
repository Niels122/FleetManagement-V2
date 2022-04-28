using Domein.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Interfaces
{
    public interface ITankkaartRepository
    {
        List<Tankkaart> GeefTankkaarten();
        List<int> GeefTankkaartnummers();

        #region CRUD operations
        void CreateTankkaart(Tankkaart tankkaart);
        Tankkaart ReadTankkaart(int kaartnummer);
        void UpdateTankkaart(Tankkaart tankkaart);
        void DeleteTankkaart(int kaartnummer);
        #endregion
    }
}
