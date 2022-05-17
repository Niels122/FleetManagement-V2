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






        
        //foreach (string rijksnr in _bestuurdersRepo.GeefRijksregisternummers()) 
        //{
        //    if (rijksnr == rijksnummer)
        //    {
        //        throw new RijksregisternummerException("Dit rijksregisternummer zit al in het systeem.");
        //    }
        //}


        //public List<List<string>> GeefBestuurders() //geeft lijst van bestuurders terug in een string
        //{
        //    return _bestuurderRepo.GeefBestuurders()
        //        .Select(bestuurder => new List<string>()
        //        {
        //            bestuurder.Naam,
        //            bestuurder.Voornaam,
        //            bestuurder.Geboortedatum.ToString(),
        //            bestuurder.Rijksregisternummer,
        //            bestuurder.Rijbewijs.ToString(),
        //            bestuurder.Adres.ToString()
        //        })
        //        .ToList();
        //}
    }
}
