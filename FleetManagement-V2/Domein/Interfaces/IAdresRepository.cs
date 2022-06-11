using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domein.Objects;

namespace Domein.Interfaces
{
    public interface IAdresRepository
    {
        List<Adres> GeefAdressen();

        void CreateAdres(string straatnaam,string huisnummer, int postcode,string stad);
        void UpdateAdres(Adres adres);
        void DeleteAdres(Adres adres); //Soft delete: implement column "IsDeleted"
    }
}
