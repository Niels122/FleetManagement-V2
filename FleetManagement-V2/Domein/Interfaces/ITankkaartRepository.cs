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

        void CreateTankkaart(Tankkaart tankkaart);

        void UpdateTankkaart(Tankkaart tankkaart);

        void DeleteTankkaart(Tankkaart tankkaart);

        void RetrieveTankkaart(Tankkaart tankkaart);
    }
}
