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

        public Adres GeefLaatsteAdres()
        {
            return _adresRepo.GeefLaatsteAdres();
        }

        public void CreateAdres(string straatnaam, string huisnummer, int postcode, string stad)
        {
            _adresRepo.CreateAdres(straatnaam, huisnummer, postcode, stad);
        }
        public void UpdateAdres(Adres adres)
        {
            _adresRepo.UpdateAdres(adres);
        }
        
        public void DeleteAdres(Adres adres)
        {
            _adresRepo.DeleteAdres(adres);
        }

        public void RetrieveAdres(Adres adres)
        {
            _adresRepo.RetrieveAdres(adres);
        }
    }
}
