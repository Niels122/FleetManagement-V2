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
            Tankkaart tankkaart = new Tankkaart("111122223333444455", new DateTime(2023-09-17), false, 2222, Brandstoftype.Diesel);
        }
    }
}
