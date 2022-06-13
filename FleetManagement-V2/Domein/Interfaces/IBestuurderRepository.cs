using Domein.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Interfaces
{
    public interface IBestuurderRepository
    {

        List<Bestuurder> GeefBestuurders();

        void CreateBestuurder(Bestuurder bestuurder);

        void UpdateBestuurder(Bestuurder bestuurder);

        void DeleteBestuurder(Bestuurder bestuurder);

        void RetrieveBestuurder(Bestuurder bestuurder);
    }

}

