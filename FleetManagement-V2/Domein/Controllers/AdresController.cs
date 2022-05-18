using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domein.Interfaces;
using Domein.Objects;


namespace Domein.Controllers
{
    public class AdresController
    {
        private IAdresRepository _adresRepo;

        public AdresController(IAdresRepository adresRepo)
        {
            _adresRepo = adresRepo;
        }

        public List<Adres> GeefAdressen()
        {
            return _adresRepo.GeefAdressen();
        }
    }
}
