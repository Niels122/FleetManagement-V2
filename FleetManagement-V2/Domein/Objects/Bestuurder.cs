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
        public string Naam { get; private set; }
        public string Voornaam { get; private set; }
        public DateTime Geboortedatum { get; private set; } //kan dit niet gewoon in string want wordt gecheckt in setter als bij het ophalen uit db
        public string Rijksregisternummer { get; private set; }
        public Rijbewijs Rijbewijs { get; private set; }
        public Adres Adres { get; private set; }
        public Voertuig Voertuig { get; private set; }
        public Tankkaart Tankkaart { get; private set; }

        #region constructoren
        // https://stackoverflow.com/questions/1814953/how-to-do-constructor-chaining-in-c-sharp
        // https://stackoverflow.com/questions/40660936/constructor-chaining-with-class-as-parameter
        public Bestuurder(string naam, string voornaam, DateTime geboortedatum, string rijksregisternummer, Rijbewijs rijbewijs, Adres adres = null, Voertuig voertuig = null, Tankkaart tankkaart = null)
        {
            SetNaam(naam);
            SetVoornaam(voornaam);
            SetGeboortedatum(geboortedatum);
            SetRijksregisternummer(rijksregisternummer);
            SetRijbewijs(rijbewijs);
            if (adres != null) SetAdres(adres);
            if (voertuig != null) SetVoertuig(voertuig);
            if (tankkaart != null) SetTankkaart(tankkaart);
        }
        #endregion
        
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
        public void SetGeboortedatum(DateTime geboortedatum)
        {
            DateTime datum;
            if (DateTime.TryParseExact(geboortedatum.ToString(), "DD/MM/YYYY", null, System.Globalization.DateTimeStyles.None, out datum))
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

        public void SetAdres(Adres adres)
        {
            Adres = adres;
        }

        public void SetVoertuig(Voertuig voertuig)
        {
            Voertuig = voertuig;
        }

        public void SetTankkaart(Tankkaart tankkaart)
        {
            Voertuig = Voertuig;
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
                if (0 < int.Parse(rijksnummer.Substring(0, 2)) && int.Parse(rijksnummer.Substring(0, 2)) < 32) //geboortedag check
                {
                    if (0 < int.Parse(rijksnummer.Substring(2, 2)) && int.Parse(rijksnummer.Substring(2, 2)) < 13) // geboortemaand check
                    {
                        if (-1 < int.Parse(rijksnummer.Substring(4, 2)) && int.Parse(rijksnummer.Substring(4, 2)) < 100) //geboortejaar chek
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
            return string.Format("Naam: {0}, Voornaam: {1}, Geboortedatum: {2}, Rijksregisternummer: {3}, Rijbewijs:",
                Naam, Voornaam, Geboortedatum, Rijksregisternummer);
        }
    }
}
