using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    class BestuurderTests
    {
        [Fact]
        public void Test_NieuweBestuurder_Valid()
        {
            Bestuurder bst = new("Van Maelzaeke", "Niels", 07121999, "99120750392", Rijbewijs.B);
        }

        [Fact]
        public void Test_NieuweBestuurder_OverloadCtor_Valid()
        {
            Voertuig voertuig = new("Mercedes", "CLS", 5555, "AAA-111", Brandstoftype.benzine, Wagentype.personenauto);
            Tankkaart tankkaart = new(1234, new System.DateTime(2022, 12, 20), false);
            Adres adres = new("Pelikaanstraat", "122", "Oudenaarde", "9700");
            Bestuurder bst = new("Van Maelzaeke", "Niels", 07121999, "99120750392", Rijbewijs.B, adres, voertuig, tankkaart);
        }

        #region Check Naam en voornaam
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetVoornaam_Invalid(string voornaam)
        {
            var Exception = Assert.Throws<BestuurderException>(() => new Bestuurder("Van Maelzaeke", voornaam, 07121999, "99120750392", Rijbewijs.B));
            Assert.Equal("Voornaam van de bestuurder moet ingevuld zijn!", Exception.Message);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetNaam_Invalid(string naam)
        {
            var Exception = Assert.Throws<BestuurderException>(() => new Bestuurder(naam, "Niels", 07121999, "99120750392", Rijbewijs.B));
            Assert.Equal("Naam van de bestuurder moet ingevuld zijn!", Exception.Message);
        }
        #endregion

        #region Rijksregisternummer Checks
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetRijksregisternummer_Invalid(string rijksregisternummer)
        {
            var Exception = Assert.Throws<RijksregisternummerException>(() => new Bestuurder("Van Maelzaeke", "Niels", 07121999, rijksregisternummer, Rijbewijs.B));
            Assert.Equal("Rijksregister mag niet leeg zijn", Exception.Message);
        }

        #endregion

        #region Check Geboortedatum ingevuld

        [Theory]
        [InlineData(null)]
        public void Test_SetGeboortedatum_Invalid(int geboortedatum)
        {
            var Exception = Assert.Throws<BestuurderException>(() => new Bestuurder("Van Maelzaeke", "Niels", geboortedatum, "99120750392", Rijbewijs.B));
            Assert.Equal("Geboortedatum mag niet leeg zijn", Exception.Message);
        }

        #endregion
    }
}
