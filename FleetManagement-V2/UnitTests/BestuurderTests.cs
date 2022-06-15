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
    public class BestuurderTests
    {
        [Fact]
        public void Test_NieuweBestuurder_Valid()
        {   
            Bestuurder bestuurder = new Bestuurder("123456aa", "Van Maelzaeke", "Niels", new DateTime(1997, 1, 23), "40042943449", Rijbewijs.B);
        }

        #region Check Naam en voornaam
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetVoornaam_Invalid(string voornaam)
        {
            var Exception = Assert.Throws<BestuurderException>(() => new Bestuurder("123456aa", voornaam, "Niels", new DateTime(1997, 1, 23), "40042943449", Rijbewijs.B));
            Assert.Equal("Voornaam van de bestuurder moet ingevuld zijn!", Exception.Message);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetNaam_Invalid(string naam)
        {
            var Exception = Assert.Throws<BestuurderException>(() => new Bestuurder("123456aa", "Van Maelzaeke", naam, new DateTime(1997, 1, 23), "40042943449", Rijbewijs.B));
            Assert.Equal("Naam van de bestuurder moet ingevuld zijn!", Exception.Message);
        }
        #endregion

        #region Check Geboortedatum ingevuld

        [Theory]
        [InlineData(null)]
        public void Test_SetGeboortedatum_Invalid(DateTime geboortedatum)
        {
            var Exception = Assert.Throws<BestuurderException>(() => new Bestuurder("123456aa", "Van Maelzaeke", "Niels", geboortedatum, "40042943449", Rijbewijs.B));
            Assert.Equal("Geboortedatum mag niet leeg zijn", Exception.Message);
        }

        #endregion

        #region Rijksregisternummer Checks
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetRijksregisternummer_Invalid(string rijksregisternummer)
        {
            var Exception = Assert.Throws<RijksregisternummerException>(() => new Bestuurder("123456aa", "Van Maelzaeke", "Niels", new DateTime(1997, 1, 23), rijksregisternummer, Rijbewijs.B));
            Assert.Equal("Rijksregister mag niet leeg zijn", Exception.Message);
        }

        #endregion

    }
}
