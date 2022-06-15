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
    public class AdresVuller
    {
        public AdresVuller()
        {

        }

        Random random = new Random();

        List<string> namen = new List<string> { "Boom", "Vijver", "Kerk", "Fabiola", "Steen", "Bagatten", "Zuid", "Vlaanderen",
                                                "Sint-Jans", "Bijloke", "Kerk", "Koriander", "Park", "Rozier", "Sint-Pieters"};
        List<string> achtervoegsels = new List<string> { "straat", "dreef", "laan" };
        public string randomStraatnaam()
        {
            return namen[random.Next(namen.Count())] + achtervoegsels[random.Next(achtervoegsels.Count())];
        }

        public string randomNummer()
        {
            return random.Next(124).ToString();
        }

        public int randomPostcode()
        {
            return random.Next(1000, 10000);
        }

        List<string> steden = new List<string> { "Gent", "Brugge", "Kortrijk", "Antwerpen", "Brussel", "Hasselt", "Dendermonde",
                                                 "Leuven", "Lokeren", "Genk", "Mechelen", "Aalst", "Evergem", "Lochristi",
                                                 "Oudenaarde", "MerelBeke", "Wetteren", "Eeklo", "Deinze", "Aalter", "Waregem"};
        public string randomStad()
        {
            return steden[random.Next(steden.Count())];
        }
    }
}
