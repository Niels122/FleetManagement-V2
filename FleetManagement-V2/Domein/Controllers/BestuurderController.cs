using Domein.Interfaces;
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

        public List<List<string>> GeefBestuurders() //geeft lijst van bestuurders terug in een string
        {
            return _bestuurderRepo.GeefBestuurders()
                .Select(bestuurder => new List<string>()
                {
                    bestuurder.Naam,
                    bestuurder.Voornaam,
                    bestuurder.Geboortedatum.ToString(),
                    bestuurder.Rijksregisternummer,
                    bestuurder.Rijbewijs.ToString(),
                    bestuurder.Adres.ToString()
                })
                .ToList();
        }
    }
}
