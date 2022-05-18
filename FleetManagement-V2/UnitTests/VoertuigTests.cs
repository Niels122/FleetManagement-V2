using Domein.Enums;
using Domein.Exceptions;
using Domein.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class VoertuigTests
    {

        [Fact]
        public void Test_NieuwVoertuig_Valid()
        {
            Voertuig voertuig = new Voertuig("Mercedes", "CLA", "1224454", "AAA-111", Brandstoftype.benzine, Wagentype.personenauto);
        }

        [Fact]
        public void Test_NieuwVoertuigOverloadCtor_Valid()
        {
            //Bestuurder bestuurderNiels = new("Van Maelzaeke", "Niels", 07121999, "99120750392", Rijbewijs.B);
            //Voertuig voertuig = new Voertuig("Mercedes", "CLA", "1224454", "AAA-111", Brandstoftype.benzine, Wagentype.personenauto, "beige", 3 , bestuurderNiels);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetMerk_MerkIsNullOrEmpty(string merk)
        {
            var exception = Assert.Throws<VoertuigException>(() => new Voertuig(merk, "CLA", "1224454", "AAA-111", Brandstoftype.benzine, Wagentype.personenauto));
            Assert.Equal("Merk moet ingevuld zijn!", exception.Message);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetModel_ModelIsNullOrEmpty(string model)
        {
            var exception = Assert.Throws<VoertuigException>(() => new Voertuig("Mercedes", model, "1224454", "AAA-111", Brandstoftype.benzine, Wagentype.personenauto));
            Assert.Equal("Model moet ingevuld zijn!", exception.Message);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetNummerplaat_NummerplaatIsNullOrEmpty(string nummerplaat)
        {
            var exception = Assert.Throws<VoertuigException>(() => new Voertuig("Mercedes", "CLA", "1224454", nummerplaat, Brandstoftype.benzine, Wagentype.personenauto));
            Assert.Equal("Nummerplaat moet ingevuld zijn!", exception.Message);
        }

    }
}
