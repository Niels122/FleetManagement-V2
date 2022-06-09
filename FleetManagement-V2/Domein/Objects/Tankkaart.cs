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
        public string Kaartnummer { get; private set; }
        public DateTime Geldigheidsdatum { get; private set; }
        public bool Geblokkeerd { get; private set; }
        public int? Pincode { get; private set; }                                                  
        public Brandstoftype? Brandstof { get; private set; } //Moet nog een List van gemaakt worden (zie opgave)
        public int? BestuurderId { get; private set; }

        public Tankkaart(string kaartnummer, DateTime geldigheidsdatum, bool geblokkeerd,
            int? pincode = null, Brandstoftype? brandstof = null, int? bestuurderId = null)
        {
            Kaartnummer = kaartnummer;
            Geldigheidsdatum = geldigheidsdatum;
            Geblokkeerd = geblokkeerd;
            Pincode = pincode;
            Brandstof = brandstof;
            BestuurderId = bestuurderId;
        }

        public override string ToString()
        {
            return string.Format("Kaartnummer: {0}, Geldigheidsdatum: {1}, Brandstof: {2}, Pincode: {3}, Geblokkeerd: {4}, BestuurderId: {5}",
                Kaartnummer, Geldigheidsdatum, Brandstof, Pincode, Geblokkeerd, BestuurderId);
        }
    }
}
