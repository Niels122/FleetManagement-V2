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
    public class Voertuig
    {
        public string Merk { get; private set; } //Merk en Model in een dictionary steken?
        public string Model { get; private set; }
        public string Chassisnummer { get; private set; }
        public string Nummerplaat { get; private set; }
        public Brandstoftype Brandstoftype { get; private set; }
        public Wagentype Wagentype { get; private set; }
        public string Kleur { get; private set; }
        public int? AantalDeuren { get; private set; }
        public string BestuurderId { get; set; }

        public Voertuig(string merk, string model, string chassisnummer, string nummerplaat, Brandstoftype brandstoftype,
            Wagentype wagentype, string kleur = null, int? aantalDeuren = null, string bestuurderId = null)
        {
            SetMerk(merk);
            SetModel(model);
            SetChassisnummer(chassisnummer);
            SetNummerplaat(nummerplaat);
            SetBrandstoftype(brandstoftype);
            SetWagentype(wagentype);
            SetKleur(kleur);
            SetAantalDeuren(aantalDeuren);
            SetBestuurderId(bestuurderId);
        }

        #region setters
        public void SetMerk(string merk)
        {
            if (string.IsNullOrWhiteSpace(merk))
            {
                throw new VoertuigException("Merk moet ingevuld zijn!");
            }

            string output = char.ToUpper(merk[0]) + merk.Substring(1).ToLower();
            Merk = output;
        }

        public void SetModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new VoertuigException("Model moet ingevuld zijn!");
            }

            Model = model;
        }

        public void SetChassisnummer(string chassisnummer)
        {
            if (chassisnummer.Length != 17)
            {
                throw new VoertuigException("Chassisnummer moet 17 karakters lang zijn.");
            }

            string nummer = chassisnummer.ToUpper();
            string letters = "ABCDEFGHJKLMNPRSTUVWXYZ0123456789";            
            foreach(char c in nummer)
            {
                if (!letters.Contains(c))
                {
                    throw new VoertuigException("Chassisnummer bevat ongeldige karakters (o, i of q zijn ongeldig).");
                }
            }

            Chassisnummer = nummer;
        }

        public void SetNummerplaat(string nummerplaat)
        {
            if (string.IsNullOrWhiteSpace(nummerplaat))
            {
                throw new VoertuigException("Nummerplaat moet ingevuld zijn.");
            }

            string nummer = "";
            foreach(char c in nummerplaat)
            {
                if (char.IsLetter(c) || char.IsDigit(c))
                {
                    nummer += c;
                }
            }

            if (nummer.Length != 7)
            {
                throw new VoertuigException("Lengte nummerplaat is verkeerd.");
            }

            //if (int.Parse(nummer.Substring(0, 1)) <= 9 || int.Parse(nummer.Substring(0, 1)) != 2)
            //{
            //    throw new VoertuigException("Eerste cijfer van nummerplaat is ongeldig.");
            //}

                if (!(char.IsDigit(nummer[0]) && char.IsDigit(nummer[4]) && char.IsDigit(nummer[5]) && char.IsDigit(nummer[6]) &&
                char.IsLetter(nummer[1]) && char.IsLetter(nummer[2]) && char.IsLetter(nummer[3])))
            {
                throw new VoertuigException("Nummerplaat is ongeldig.");
            }

            string plaat = nummer.Insert(1, "-");
            string plaat2 = plaat.Insert(5, "-");

            Nummerplaat = plaat2.ToUpper();

        }

        public void SetBrandstoftype(Brandstoftype brandstoftype)
        {
            if (Enum.IsDefined(typeof(Brandstoftype), brandstoftype))
            {
                Brandstoftype = brandstoftype;
            }
            else
            {
                throw new VoertuigException("Ongeldig brandstoftype");
            }
        }

        public void SetWagentype(Wagentype wagentype)
        {
            if (Enum.IsDefined(typeof(Wagentype), wagentype))
            {
                Wagentype = wagentype;
            }
            else
            {
                throw new VoertuigException("Ongeldig wagentype");
            }
        }

        public void SetKleur(string kleur)
        {
            string output = kleur;
            if (kleur != null)
            {
                output = char.ToUpper(kleur[0]) + kleur.Substring(1).ToLower();
            }

            Kleur = output;
        }

        public void SetAantalDeuren(int? aantalDeuren)
        {
            AantalDeuren = aantalDeuren;
        }

        public void SetBestuurderId(string bestuurderId)
        {
            BestuurderId = bestuurderId;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Merk: {0}, Model: {1}, Chassisnummer: {2}, Nummerplaat: {3}, Brandstoftype: {4}, " +
                "Wagentype: {5}, Kleur: {6}, AantalDeuren: {7}, BestuurderId: {8}",
                Merk, Model, Chassisnummer, Nummerplaat, Brandstoftype, Wagentype, Kleur, AantalDeuren, BestuurderId);
        }
    }
}
