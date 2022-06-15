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
        public string ChassisnummerVoertuig { get; set; }
        public string TankkaartNummer { get; set; }
        public int? AdresId { get; set; }

        public Bestuurder(string bestuurderId, string naam, string voornaam, DateTime geboortedatum, string rijksregisternummer,
            Rijbewijs rijbewijs, string chassisnummerVoertuig = null, string tankkaartnummer = null, int? adresId = null)
        {
            setBestuurderId(bestuurderId);
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
        public void setBestuurderId(string bestuurderId)
        {
            if (bestuurderId.Length != 8)
            {
                throw new BestuurderException("BestuurderId moet uit 8 tekens bestaan.");
            }

            string cijfers = bestuurderId.Substring(0, 6);
            string letters = bestuurderId.Substring(6, 2);

            foreach (char c in cijfers)
            {
                if (!char.IsDigit(c))
                {
                    throw new BestuurderException("De eerste 6 karakters van bestuurderId moeten cijfers zijn.");
                }
            }

            foreach(char c in letters)
            {
                if (!char.IsLetter(c))
                {
                    throw new BestuurderException("De laatste 2 karakters van bestuurderId moeten letters zijn.");
                }
            }

            BestuurderId = bestuurderId.ToLower();
        }

        public void SetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                throw new BestuurderException("Naam van de bestuurder moet ingevuld zijn.");
            }

            string output = char.ToUpper(naam[0]) + naam.Substring(1);
            Naam = output;
        }

        public void SetVoornaam(string voornaam)
        {
            if (string.IsNullOrWhiteSpace(voornaam))
            {
                throw new BestuurderException("Voornaam van de bestuurder moet ingevuld zijn.");
            }

            string output = char.ToUpper(voornaam[0]) + voornaam.Substring(1).ToLower();
            Voornaam = output;
        }

        //https://stackoverflow.com/questions/371987/how-to-validate-a-datetime-in-c
        //https://stackoverflow.com/questions/2193012/string-was-not-recognized-as-a-valid-datetime-format-dd-mm-yyyy
        //https://stackoverflow.com/questions/33807694/how-to-check-if-date-is-in-correct-format-i-e-yyyy-mmm-dd
        public void SetGeboortedatum(DateTime geboortedatum) 
        {
            DateTime datum;
            if (DateTime.TryParseExact(geboortedatum.ToString("yyyy-MM-dd"), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out datum))
            {
                if (DateTime.Today.AddYears(-18) >= datum)
                {
                    Geboortedatum = datum;
                }
                else
                {
                    throw new BestuurderException("Bestuurder moet ouder zijn dan 18 jaar.");
                }
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
            
            if (ValideerRijksregisternummer(rijksnummer))
            {
                Rijksregisternummer = rijksnummer;
            }
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

        public bool ValideerRijksregisternummer(string rijksregisternummer)
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
                string eerste9 = rijksnummer.Substring(0, 9);
                string controlegetal = rijksnummer.Substring(9, 2);

                if (-1 < int.Parse(rijksnummer.Substring(0, 2)) && int.Parse(rijksnummer.Substring(0, 2)) < 100) //geboortejaar check
                {
                    if (0 < int.Parse(rijksnummer.Substring(2, 2)) && int.Parse(rijksnummer.Substring(2, 2)) < 13) // geboortemaand check
                    {
                        if (0 < int.Parse(rijksnummer.Substring(4, 2)) && int.Parse(rijksnummer.Substring(4, 2)) < 32) //geboortejaar check
                        {
                            if (0 < int.Parse(rijksnummer.Substring(6, 3)) && int.Parse(rijksnummer.Substring(6, 3)) < 999) //herkenningsgetal check
                            {
                                if ((97 - (int.Parse(eerste9) % 97)) == int.Parse(controlegetal)) //controlegetal check
                                {
                                    return true;
                                }
                                else if (int.Parse(rijksnummer.Substring(0, 2)) < int.Parse(DateTime.Today.AddYears(-80).Year.ToString().Substring(2))
                                    && (97 - (int.Parse(eerste9.Insert(0, "2")) % 97)) == int.Parse(controlegetal)) //geboren na het jaar 2000                                    
                                {
                                    return true;
                                }
                                else { throw new RijksregisternummerException("Het controlegetal (laatste twee cijfers) in het rijksregisternummer is ongeldig."); }
                            }
                            else { throw new RijksregisternummerException("Cijfers 7, 8 en 9 in het rijksregisternummer moeten een getal tussen 0 en 999 vormen."); }
                        }
                        else { throw new RijksregisternummerException("Geboortejaar in het rijksregisternummer is ongeldig"); }
                    }
                    else { throw new RijksregisternummerException("Geboortemaand in het rijksregisternummer is ongeldig."); }
                }
                else { throw new RijksregisternummerException("Geboortedag in het rijksregisternummer is ongeldig."); }
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
