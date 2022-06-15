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
    public class Tankkaart
    {
        public string Kaartnummer { get; private set; }
        public DateTime Geldigheidsdatum { get; private set; }
        public bool Geblokkeerd { get; private set; }
        public int? Pincode { get; private set; }                                                  
        public Brandstoftype? Brandstof { get; private set; } //Moet nog een List van gemaakt worden (zie opgave)
        public string BestuurderId { get; set; }

        public Tankkaart(string kaartnummer, DateTime geldigheidsdatum, bool geblokkeerd,
            int? pincode = null, Brandstoftype? brandstof = null, string bestuurderId = null)
        {
            SetKaartnummer(kaartnummer);
            SetGeldigheidsDatum(geldigheidsdatum);
            SetGeblokkeerd(geblokkeerd);
            SetPincode(pincode);
            SetBrandstof(brandstof);
            SetBestuurderId(bestuurderId);
        }

        #region setters
        public void SetKaartnummer(string kaartnummer)
        {
            if (kaartnummer.Length != 18)
            {
                throw new TankkaartException("Een tankkaartnummer moet uit 18 cijfers zonder spatie bestaan.");
            }

            foreach(char c in kaartnummer)
            {
                if (!char.IsDigit(c))
                {
                    throw new TankkaartException("Een tankkaartnummer mag enkel uit cijfers bestaan.");
                }
            }
            
            Kaartnummer = kaartnummer;
        }

        public void SetGeldigheidsDatum(DateTime geldigheidsdatum)
        {
            DateTime datum;
            if (DateTime.TryParseExact(geldigheidsdatum.ToString("yyyy-MM-dd"), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out datum))
            {
                if (DateTime.Today <= datum) //DateTime.Today.AddYears(-18) >= datum
                {
                    Geldigheidsdatum = datum;
                }
                else
                {
                    throw new TankkaartException("Geldigheidsdatum tankkaart is al verstreken.");
                }
            }
            else
            {
                throw new TankkaartException("Geldigheidsdatum is ongeldig.");
            }
        }
        
        public void SetGeblokkeerd(bool geblokkeerd)
        {
            Geblokkeerd = geblokkeerd;
        }

        public void SetPincode(int? pincode)
        {
            if (pincode != null)
            {
                if (pincode < 1000 || pincode > 9999 || pincode.ToString() == "0000")
                {
                    throw new TankkaartException("Pincode moet uit 4 cijfers bestaan.");
                }
            }

            Pincode = pincode;
        }

        public void SetBrandstof(Brandstoftype? brandstof)
        {
            if (brandstof != null && !Enum.IsDefined(typeof(Brandstoftype), brandstof))
            {
                throw new TankkaartException("Ongeldig brandstoftype.");
            }

            Brandstof = brandstof;
        }

        public void SetBestuurderId(string bestuurderId)
        {
            BestuurderId = bestuurderId;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Kaartnummer: {0}, Geldigheidsdatum: {1}, Brandstof: {2}, Pincode: {3}, Geblokkeerd: {4}, BestuurderId: {5}",
                Kaartnummer, Geldigheidsdatum, Brandstof, Pincode, Geblokkeerd, BestuurderId);
        }
    }
}
