using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domein.Controllers;
using Domein.Enums;
using Domein.Objects;

namespace Domein.dbVullers
{
    public class TankkaartVuller
    {
        TankkaartController _tc;

        public TankkaartVuller(TankkaartController tc)
        {
            _tc = tc;
        }

        public void VulTankkaarTabel(int aantal)
        {
            for(int i = 0; i < aantal; i++)
            {
                try
                {
                    _tc.CreateTankkaart(new Tankkaart(randomKaartnummer(), randomGeldigheidsdatum(), randomGeblokkeerd(), randomPincode(), randomBrandstoftype()));
                }
                catch
                {
                    i--;
                }
            }
        }

        Random random = new Random();

        public string randomKaartnummer()
        {
            string kaarnummer = "";

            for(int i = 0; i < 18; i++)
            {
                kaarnummer += random.Next(10).ToString();
            }

            return kaarnummer;
        }

        DateTime start = DateTime.Today;
        int verschil = (DateTime.Today.AddYears(10) - DateTime.Today).Days;
        public DateTime randomGeldigheidsdatum()
        {
            return start.AddDays(random.Next(verschil));
        }

        public bool randomGeblokkeerd()
        {
            if (random.Next(20) < 1)
            {
                return true;
            }

            return false;
        }    
        
        public int? randomPincode()
        {
            if (random.Next(17) < 1)
            {
                return null;
            }

            return random.Next(1000, 10000);
        }

        List<Brandstoftype> brandstoftypes = new List<Brandstoftype> { Brandstoftype.Benzine, Brandstoftype.Diesel };
        public Brandstoftype? randomBrandstoftype()
        {
            if (random.Next(12) < 1)
            {
                return null;
            }
            return brandstoftypes[random.Next(brandstoftypes.Count())];
        }
    }
}
