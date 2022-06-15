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
            Voertuig voertuig = new Voertuig("Mercedes", "CLA", "12H9GNYN9VFV7KGRM", "1-AAA-111", Brandstoftype.Benzine, Wagentype.Personenauto);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetMerk_MerkIsNullOrEmpty(string merk)
        {
            var exception = Assert.Throws<VoertuigException>(() => new Voertuig(merk, "CLA", "12H9GNYN9VFV7KGRM", "1-AAA-111", Brandstoftype.Benzine, Wagentype.Personenauto));
            Assert.Equal("Merk moet ingevuld zijn!", exception.Message);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetModel_ModelIsNullOrEmpty(string model)
        {
            var exception = Assert.Throws<VoertuigException>(() => new Voertuig("Mercedes", model, "12H9GNYN9VFV7KGRM", "1-AAA-111", Brandstoftype.Benzine, Wagentype.Personenauto));
            Assert.Equal("Model moet ingevuld zijn!", exception.Message);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetNummerplaat_NummerplaatIsNullOrEmpty(string nummerplaat)
        {
            var exception = Assert.Throws<VoertuigException>(() => new Voertuig("Mercedes", "CLA", "12H9GNYN9VFV7KGRM", nummerplaat, Brandstoftype.Benzine, Wagentype.Personenauto));
            Assert.Equal("Nummerplaat moet ingevuld zijn!", exception.Message);
        }

    }
}
