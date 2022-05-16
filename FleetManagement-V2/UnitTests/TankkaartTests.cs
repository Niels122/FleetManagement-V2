using Domein.Enums;
using Domein.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class TankkaartTests
    {
        [Fact]
        public void Test_NieuweTankkaart_Valid()
        {
            Tankkaart tankkaart = new(123456789, new DateTime(2023, 12, 31), false);
        }
        [Fact]
        public void Test_NieuweTankkaartOverloadedCtor_Valid()
        {
            Bestuurder bestuurderNiels = new("Van Maelzaeke", "Niels", 07121999, "99120750392", Rijbewijs.B);

            Tankkaart tankkaart = new(123456789, new DateTime(2023, 12, 31), false, 1234, Brandstoftype.benzine, bestuurderNiels);
        }
    }
}
