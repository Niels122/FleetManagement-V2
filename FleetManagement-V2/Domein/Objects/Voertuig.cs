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
        private IVoertuigRepository _voertuigRepo;

        public string Merk { get; set; } //Merk en Model in een dictionary steken?
        public string Model { get; set; }
        public int Chassisnummer { get; set; }
        public string Nummerplaat { get; set; }
        public Brandstoftype Brandstoftype { get; set; }
        public Wagentype Wagentype { get; set; }
        public Kleur Kleur { get; set; }
        public Deuren AantalDeuren { get; set; }
        public Bestuurder Bestuurder { get; set; }

        public Voertuig(string merk, string model, int chassisnummer, string nummerplaat, Brandstoftype brandstoftype, Wagentype wagentype)
        {
            SetMerk(merk);
            SetModel(model);
            SetChassisnummer(chassisnummer);
            SetNummerplaat(nummerplaat);
            Brandstoftype = brandstoftype;
            Wagentype = wagentype;
        }

        public Voertuig(string merk, string model, int chassisnummer, string nummerplaat, Brandstoftype brandstoftype, Wagentype wagentype,
                            Kleur kleur, Deuren deuren, Bestuurder bestuurder) : this(merk, model, chassisnummer, nummerplaat, brandstoftype, wagentype)
        {
            Kleur = kleur;
            AantalDeuren = deuren;
            Bestuurder = bestuurder;
        }

        public void SetMerk(string merk)
        {
            if (string.IsNullOrEmpty(merk))
            {
                throw new VoertuigException("Merk moet ingevuld zijn!");
            }
            this.Merk = merk;
        }
        public void SetModel(string model)
        {
            if (string.IsNullOrEmpty(model))
            {
                throw new VoertuigException("Model moet ingevuld zijn!");
            }
            this.Model = model;
        }

        public void SetChassisnummer(int chassisnummer)
        {
            foreach (int chassisnr in _voertuigRepo.GeefChassisnummers())
            {
                if (chassisnr == chassisnummer)
                {
                    throw new Exception("Deze wagen zit reeds in het systeem.");
                }
            }

            Chassisnummer = chassisnummer;

        }

        public void SetNummerplaat(string nummerplaat)
        {
            if (string.IsNullOrEmpty(nummerplaat))
            {
                throw new VoertuigException("Nummerplaat moet ingevuld zijn!");
            }
            else
            {

                foreach (string nrplaat in _voertuigRepo.GeefNummerplaten())
                {
                    if (nrplaat == nummerplaat)
                    {
                        throw new Exception("Deze nummer plaats zit reeds in het systeem");
                    }
                }

                Nummerplaat = nummerplaat;
            }
        }
    }
}
