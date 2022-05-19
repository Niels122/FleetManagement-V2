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
            Tankkaart tankkaart = new(1 ,"123456789", new DateTime(2023, 12, 31));
        }
        [Fact]
        public void Test_NieuweTankkaartOverloadedCtor_Valid()
        {
            Bestuurder bestuurderNiels = new(1,"Van Maelzaeke", "Niels", new DateTime(2022, 12, 07), "99120750392", Rijbewijs.B);

            Tankkaart tankkaart = new(1, "123456789", new DateTime(2023, 12, 31));
        }
    }
}
