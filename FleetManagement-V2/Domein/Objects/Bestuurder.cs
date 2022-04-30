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
        private IBestuurderRepository _bestuurdersRepo;

        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public int Geboortedatum { get; set; }
        public string Rijksregisternummer { get; set; }
        public Rijbewijs Rijbewijs { get; set; }
        public Adres? Adres { get; set; }
        public Voertuig Voertuig { get; set; }
        public Tankkaart Tankkaart { get; set; }

        public Bestuurder(string naam, string voornaam, Rijbewijs rijbewijs)
        {
            SetNaam(naam);
            SetVoornaam(voornaam);
            Rijbewijs = rijbewijs;
        }
        public Bestuurder(string naam, string voornaam, int geboortedatum, string rijksregisternummer, Rijbewijs rijbewijs)
        {
            SetNaam(naam);
            SetVoornaam(voornaam);
            SetGeboortedatum(geboortedatum);
            SetRijksregisternummer(rijksregisternummer.ToString());
            Rijbewijs = rijbewijs;
        }

        public Bestuurder(string naam, string voornaam, int geboortedatum, string rijksregisternummer, Rijbewijs rijbewijs, Adres? adres, Voertuig voertuig, Tankkaart tankkaart) : this(naam, voornaam, geboortedatum, rijksregisternummer, rijbewijs)
        {
            Adres = adres;
            Voertuig = voertuig;
            Tankkaart = tankkaart;
        }
        public void SetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                BestuurderException e = new BestuurderException("Naam van de bestuurder moet ingevuld zijn!");
                throw e;
            }
            Naam = naam;
        }
        public void SetVoornaam(string voornaam)
        {
            if (string.IsNullOrWhiteSpace(voornaam))
            {
                BestuurderException e = new BestuurderException("Voornaam van de bestuurder moet ingevuld zijn!");
                throw e;
            }
            Voornaam = voornaam;
        }

        //TODO: Check op geboortedatum (persoon kan niet voor 1900 geboren zijn, kan niet geboren zijn in de toekomst(na huidige datum)
        //      Een maand kan niet groter zijn dan 12 en dag niet groter dan 31, beide kunnen niet kleiner dan 1
        //      Moet dit geen datetime worden?
        public void SetGeboortedatum(int geboortedatum) 
        {
            if (geboortedatum == null)
            {
                throw new BestuurderException("Geboortedatum mag niet leeg zijn");
            }
            Geboortedatum = geboortedatum;
        }

        public void SetRijksregisternummer(string rijksnummer)
        {
            if (string.IsNullOrWhiteSpace(rijksnummer))
            {
                throw new RijksregisternummerException("Rijksregister mag niet leeg zijn");
            }
            ValideerRijkssregisternummer(rijksnummer);
            foreach (string rijksnr in _bestuurdersRepo.GeefRijksregisternummers()) //TODO: FIX System.NullReferenceException: 'Object reference not set to an instance of an object.'
            {
                if (rijksnr == rijksnummer)
                {
                    throw new RijksregisternummerException("Dit rijksregisternummer zit al in het systeem.");
                }
            }
            //Rijksregisternummer.ToString(rijksnummer);
            Rijksregisternummer = rijksnummer;
        }

        public void ValideerRijkssregisternummer(string rijksnummer)    //in GUI enkel int aanvaarden en dan omzetten naar string om hier te kunnen manipuleren
        {
            if (double.TryParse(rijksnummer, out double result))              //Hier klopt iets nog niet mijn unit test slaagt niet. IK denk dat er ook nog een andere manier is om deze check te doen.
            {

                if (rijksnummer.Length == 11)
                {
                    if (0 < int.Parse(rijksnummer.Substring(0, 1)) && int.Parse(rijksnummer.Substring(0, 1)) < 32)
                    {
                        if (0 < int.Parse(rijksnummer.Substring(2, 2)) && int.Parse(rijksnummer.Substring(2, 2)) < 13) //Controle van MAAND van rijksregisternummer (Geldigheidscheck)
                        {
                            if (0 < int.Parse(rijksnummer.Substring(0, 2)) && int.Parse(rijksnummer.Substring(0, 2)) < 100)//Controle JAAR check.
                            {
                                if (0 < int.Parse(rijksnummer.Substring(6, 3)) && int.Parse(rijksnummer.Substring(6, 3)) < 999)// Controlle 3 cijfers 7-8-9, CHECK
                                {
                                    if (-1 < int.Parse(rijksnummer.Substring(9, 2)) % 97 && int.Parse(rijksnummer.Substring(9, 2)) < 97)
                                    {

                                        //Rijksregisternummer.ToString(rijksnummer);

                                        Rijksregisternummer = rijksnummer;
                                    }
                                    else if (-1 < int.Parse(rijksnummer.Insert(9, "2").Substring(0, 9)) % 97 && int.Parse(rijksnummer.Insert(0, "2").Substring(0, 9)) < 97)
                                    {
                                        //Rijksregisternummer.ToString(rijksnummer);

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
            else { throw new RijksregisternummerException("U mag enkel cijfers ingeven."); }
        }
    }
}
