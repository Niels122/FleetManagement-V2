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
        //List<string> GeefRijksregisternummers();

        #region CRUD operations
        void CreateBestuurder(Bestuurder bestuurder);
        Bestuurder ReadBestuurder();
        void UpdateBestuurder(Bestuurder bestuurder);
        void RetrieveBestuurder(Bestuurder bestuurder);
        void DeleteBestuurder(Bestuurder bestuurder); //Soft delete: implement column "IsDeleted"
        #endregion
    }

}

