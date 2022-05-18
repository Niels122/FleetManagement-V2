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

        public int VoertuigId { get; private set; }
        public string Merk { get; private set; } //Merk en Model in een dictionary steken?
        public string Model { get; private set; }
        public string Chassisnummer { get; private set; }
        public string Nummerplaat { get; private set; }
        public Brandstoftype Brandstoftype { get; private set; }
        public Wagentype Wagentype { get; private set; }
        public string Kleur { get; private set; }
        public int? AantalDeuren { get; private set; }
        public int? BestuurderId { get; private set; }

        public override string ToString()
        {
            return string.Format("VoertuigId: {0}, Merk: {1}, Model: {2}, Chassisnummer: {3}, Nummerplaat: {4}, Brandstoftype: {5}, " +
                "Wagentype: {6}, Nummerplaat: {7}, Brandstoftype: {8}, Wagentype: {9}",
                VoertuigId, Merk, Model, Chassisnummer, Nummerplaat, Brandstoftype, Wagentype, Kleur, AantalDeuren, BestuurderId);
        }

        public Voertuig(int voertuigId, string merk, string model, string chassisnummer, string nummerplaat, 
            Brandstoftype brandstoftype, Wagentype wagentype, string kleur = null, int? aantalDeuren = null, int? bestuurderId = null)
        {
            VoertuigId = voertuigId;
            SetMerk(merk);
            SetModel(model);
            SetChassisnummer(chassisnummer);
            SetNummerplaat(nummerplaat);
            Brandstoftype = brandstoftype;
            Wagentype = wagentype;
            Kleur = kleur;
            AantalDeuren = aantalDeuren;
            BestuurderId = bestuurderId;
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

        public void SetChassisnummer(string chassisnummer)
        {
            //foreach (string chassisnr in _voertuigRepo.GeefChassisnummers())
            //{
            //    if (chassisnr == chassisnummer)
            //    {
            //        throw new Exception("Deze wagen zit reeds in het systeem.");
            //    }
            //}

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

                //foreach (string nrplaat in _voertuigRepo.GeefNummerplaten())
                //{
                //    if (nrplaat == nummerplaat)
                //    {
                //        throw new Exception("Deze nummer plaats zit reeds in het systeem");
                //    }
                //}

                Nummerplaat = nummerplaat;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //public override string ToString()
        //{
        //    return string.Format($"Merk, Model, Chassisnummer, Nummerplaat, Brandstoftype, Wagentype, Kleur, {AantalDeuren}");
        //}
    }
}
