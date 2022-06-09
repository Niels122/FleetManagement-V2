using Domein.Enums;
using Domein.Exceptions;
using Domein.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Objects
{
    public class Bestuurder
    {
        public string BestuurderId { get; private set; }
        public string Naam { get; private set; }
        public string Voornaam { get; private set; }
        public DateTime Geboortedatum { get; private set; } 
        public string Rijksregisternummer { get; private set; }
        public Rijbewijs Rijbewijs { get; private set; }
        public string ChassisnummerVoertuig { get; private set; }
        public string TankkaartNummer { get; private set; }
        public int? AdresId { get; private set; }

        public Bestuurder(string bestuurderId, string naam, string voornaam, DateTime geboortedatum, string rijksregisternummer,
            Rijbewijs rijbewijs, string chassisnummerVoertuig = null, string tankkaartnummer = null, int? adresId = null)
        {
            BestuurderId = bestuurderId;
            SetNaam(naam);
            SetVoornaam(voornaam);
            SetGeboortedatum(geboortedatum);
            SetRijksregisternummer(rijksregisternummer);
            SetRijbewijs(rijbewijs);
            SetVoertuig(chassisnummerVoertuig);
            SetTankkaart(tankkaartnummer);
            SetAdres(adresId);
        }

        #region setters
        public void SetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                throw new BestuurderException("Naam van de bestuurder moet ingevuld zijn.");
            }
            Naam = naam;
        }
        public void SetVoornaam(string voornaam)
        {
            if (string.IsNullOrWhiteSpace(voornaam))
            {
                throw new BestuurderException("Voornaam van de bestuurder moet ingevuld zijn.");
            }
            Voornaam = voornaam;
        }

        //https://stackoverflow.com/questions/371987/how-to-validate-a-datetime-in-c
        //https://stackoverflow.com/questions/2193012/string-was-not-recognized-as-a-valid-datetime-format-dd-mm-yyyy
        //https://stackoverflow.com/questions/33807694/how-to-check-if-date-is-in-correct-format-i-e-yyyy-mmm-dd
        public void SetGeboortedatum(DateTime geboortedatum) //TODO: CUI geeft ook uur min en sec na geboortedatum
        {
            DateTime datum;
            if (DateTime.TryParseExact(geboortedatum.ToString("yyyy-MM-dd"), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out datum))
            {
                Geboortedatum = datum;
            }
            else
            {
                throw new BestuurderException("Geboortedatum is ongeldig.");
            }
        }

        public void SetRijksregisternummer(string rijksnummer)
        {
            if (string.IsNullOrWhiteSpace(rijksnummer))
            {
                throw new BestuurderException("Rijksregister mag niet leeg zijn.");
            }
            ValideerRijksregisternummer(rijksnummer);
        }

        public void SetRijbewijs(Rijbewijs rijbewijs)
        {
            if (Enum.IsDefined(typeof(Rijbewijs), rijbewijs))
            {
                Rijbewijs = rijbewijs;
            }
            else
            {
                throw new BestuurderException("Type rijbewijs is niet geldig.");
            }
        }

        public void SetVoertuig(string chassisnummer)
        {
            ChassisnummerVoertuig = chassisnummer;
        }

        public void SetTankkaart(string tankkaart)
        {
            TankkaartNummer = tankkaart;
        }

        public void SetAdres(int? adres)
        {
            AdresId = adres;
        }
        #endregion

        public void ValideerRijksregisternummer(string rijksregisternummer)
        {
            string rijksnummer = "";

            foreach (char c in rijksregisternummer)
            {
                if (char.IsDigit(c))
                {
                    rijksnummer += c;
                }
            }

            if (rijksnummer.Length == 11)
            {
                if (-1 < int.Parse(rijksnummer.Substring(0, 2)) && int.Parse(rijksnummer.Substring(0, 2)) < 100) //geboortedag check
                {
                    if (0 < int.Parse(rijksnummer.Substring(2, 2)) && int.Parse(rijksnummer.Substring(2, 2)) < 13) // geboortemaand check
                    {
                        if (0 < int.Parse(rijksnummer.Substring(4, 2)) && int.Parse(rijksnummer.Substring(4, 2)) < 32) //geboortejaar chek
                        {
                            if (0 < int.Parse(rijksnummer.Substring(6, 3)) && int.Parse(rijksnummer.Substring(6, 3)) < 999) //herkenningsgetal check
                            {
                                if (-1 < int.Parse(rijksnummer.Substring(0, 9)) % 97 && int.Parse(rijksnummer.Substring(0, 9)) % 97 < 97) //controlegetal check
                                {
                                    Rijksregisternummer = rijksnummer;
                                }
                                else if (-1 < int.Parse(rijksnummer.Insert(0, "2").Substring(0, 10)) % 97 && int.Parse(rijksnummer.Insert(0, "2").Substring(0, 10)) % 97 < 97)
                                {
                                    Rijksregisternummer = rijksnummer;
                                }
                                else { throw new RijksregisternummerException("De laatste twee cijfers zijn ongeldig."); }
                            }
                            else { throw new RijksregisternummerException("Cijfers 7, 8 en 9 moeten een getal tussen 0 en 999 vormen."); }
                        }
                        else { throw new RijksregisternummerException("Geboortejaar in rijksregisternummer is ongeldig"); }
                    }
                    else { throw new RijksregisternummerException("Geboortemaand in rijksregisternummer is ongeldig."); }
                }
                else { throw new RijksregisternummerException("Geboortedag in rijksregisternummer is ongeldig."); }
            }
            else { throw new RijksregisternummerException("Lengte rijksregisternummer is verkeerd."); }
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, Naam: {1}, Voornaam: {2}, Geboortedatum: {3}, Rijksregisternummer: {4}, Rijbewijs: {5}, Adres: {6}, Voertuig: {7}, Tankkaart: {8}",
                BestuurderId, Naam, Voornaam, Geboortedatum, Rijksregisternummer, Rijbewijs, AdresId, ChassisnummerVoertuig, TankkaartNummer);
        }
    }
}
