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
        public int TankkaartId { get; private set; }
        public string Kaartnummer { get; private set; }
        public DateTime Geldigheidsdatum { get; private set; }
        public bool Geblokkeerd { get; private set; } //Toegevoegd om te kunnen checken of een tankkaart al dan niet geblokkeerd is
                                                            //Moet dit niet enkel in de database?
        public Brandstoftype? Brandstof { get; private set; } //Moet nog een List van gemaakt worden (zie opgave)
        public int? Pincode { get; private set; }
        public int? BestuurderId { get; private set; }

        public Tankkaart(int tankkaartId, string kaartnummer, DateTime geldigheidsdatum, 
            int? pincode = null, Brandstoftype? brandstof = null, int? bestuurderId = null)
        {
            TankkaartId = tankkaartId;
            Kaartnummer = kaartnummer;
            Geldigheidsdatum = geldigheidsdatum;
            Pincode = pincode;
            Brandstof = brandstof;
            BestuurderId = bestuurderId;
        }

        //public void SetKaartnummer(int kaartnummer)
        //{
        //    foreach (int kaartnr in _tankkaartRepo.GeefTankkaartnummers())
        //    {
        //        if (kaartnr == kaartnummer)
        //        {
        //            throw new Exception("Deze tankkaart zit al in het systeem."); //stopt deze exception de verdere uitvoer van deze klasse? 
        //        }                                                                   //of moet ik nog een check doen voor kaartnummer wordt ingesteld?
        //    }

        //    Kaartnummer = kaartnummer;
        //}

        public override string ToString()
        {
            return string.Format("TankkaartId: {0}, Kaartnummer: {1}, Geldigheidsdatum: {2}, Brandstof: {3}, Pincode: {4}, BestuurderId: {5}",
                TankkaartId, Kaartnummer, Geldigheidsdatum, Brandstof, Pincode, BestuurderId);
        }
    }
}
