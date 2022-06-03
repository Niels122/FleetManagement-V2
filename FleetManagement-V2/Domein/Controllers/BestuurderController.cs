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

        public List<Bestuurder> GeefBestuurders()
        {
            return _bestuurderRepo.GeefBestuurders();
        }

        public int? GeefBestuurderByAdresId(int adresId)
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

        public void DeleteBestuurder(Bestuurder bestuurder)
        {
            _bestuurderRepo.DeleteBestuurder(bestuurder);
        }














        //foreach (string rijksnr in _bestuurdersRepo.GeefRijksregisternummers()) 
        //{
        //    if (rijksnr == rijksnummer)
        //    {
        //        throw new RijksregisternummerException("Dit rijksregisternummer zit al in het systeem.");
        //    }
        //}
    }
}
