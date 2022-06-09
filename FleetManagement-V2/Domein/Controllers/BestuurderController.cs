using Domein.Interfaces;
using Domein.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Controllers
{
    public class BestuurderController
    {
        private IBestuurderRepository _bestuurderRepo;

        public BestuurderController(IBestuurderRepository bestuurderRepo)
        {
            _bestuurderRepo = bestuurderRepo;
        }

        public List<Bestuurder> GeefBestuurders(string bestuurId = null)
        {
            return _bestuurderRepo.GeefBestuurders(bestuurId);
        }

        public int? GeefBestuurderIdByAdresId(int adresId) //List<int> teruggeven voor als er meerdere bestuurders op 1 adres zijn
        {
            Bestuurder bestuurder = _bestuurderRepo.GeefBestuurders().Where(a => a.AdresId == adresId).FirstOrDefault();
            int? result = bestuurder.AdresId;
            return result;  
        }

        public void CreateBestuurder(Bestuurder bestuurder)
        {
            _bestuurderRepo.CreateBestuurder(bestuurder);
        }

        public void UpdateBestuurder(Bestuurder bestuurder)
        {
            _bestuurderRepo.UpdateBestuurder(bestuurder);
        }

        public void RetrieveBestuurder(Bestuurder bestuurder)
        {
            _bestuurderRepo.RetrieveBestuurder(bestuurder);
        }

        public void DeleteBestuurder(Bestuurder bestuurder)
        {
            _bestuurderRepo.DeleteBestuurder(bestuurder);
        }
    }
}
