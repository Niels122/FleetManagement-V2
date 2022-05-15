using Domein.Enums;
using Domein.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Objects
{
    public class Tankkaart
    {
        private ITankkaartRepository _tankkaartRepo;

        public int Kaartnummer { get; set; }
        public DateTime Geldigheidsdatum { get; set; }
        public bool Geblokkeerd { get; set; } //Toegevoegd om te kunnen checken of een tankkaart al dan niet geblokkeerd is
        public int? Pincode { get; set; }
        public Brandstoftype Brandstof { get; set; }
        public Bestuurder? Bestuurder { get; set; }



        public Tankkaart(int kaartnummer, DateTime geldigheidsdatum, bool geblokkeerd)
        {
            SetKaartnummer(kaartnummer);
            Geldigheidsdatum = geldigheidsdatum;
            Geblokkeerd = geblokkeerd;
        }

        public Tankkaart(int kaartnummer, DateTime geldigheidsdatum, bool geblokkeerd, int? pincode, Brandstoftype brandstof, Bestuurder? bestuurder) : this(kaartnummer, geldigheidsdatum, geblokkeerd)
        {
            Pincode = pincode;
            Brandstof = brandstof;
            Bestuurder = bestuurder;
        }

        public void SetKaartnummer(int kaartnummer)
        {
            foreach (int kaartnr in _tankkaartRepo.GeefTankkaartnummers())
            {
                if (kaartnr == kaartnummer)
                {
                    throw new Exception("Deze tankkaart zit al in het systeem."); //stopt deze exception de verdere uitvoer van deze klasse? 
                }                                                                   //of moet ik nog een check doen voor kaartnummer wordt ingesteld?
            }

            Kaartnummer = kaartnummer;
        }
    }
}
