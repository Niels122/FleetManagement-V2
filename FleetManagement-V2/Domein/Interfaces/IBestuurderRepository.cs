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

        List<Bestuurder> GeefBestuurders(int? bestuurId = null);

        #region CRUD operations
        void CreateBestuurder(Bestuurder bestuurder);
        void UpdateBestuurder(Bestuurder bestuurder);
        void RetrieveBestuurder(Bestuurder bestuurder);
        void DeleteBestuurder(Bestuurder bestuurder); 
        #endregion
    }

}

