using Domein.Objects;
using Domein.Controllers;
using Domein.dbVullers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public class DomeinController
    {
        private VoertuigController _voertuigCon;
        private TankkaartController _tankkaartCon;
        private BestuurderController _bestuurderCon;
        private AdresController _adresCon;

        private BestuurderVuller _bv;
        private AdresVuller _av;
        private VoertuigVuller _vv;
        private TankkaartVuller _tv;

        public DomeinController(VoertuigController vc, TankkaartController tc, BestuurderController bc, AdresController ac,
                                    BestuurderVuller bv, AdresVuller av, VoertuigVuller vv, TankkaartVuller tv)
        {
            _voertuigCon = vc;
            _tankkaartCon = tc;
            _bestuurderCon = bc;
            _adresCon = ac;
            _bv = bv;
            _av = av;
            _vv = vv;
            _tv = tv;
        }

        /// <summary>
        /// Deze methode vult alle 4 de databasetabellen aan met x aantal gegevens, gekozn door de gebruiker.
        /// Wordt opgeroepen in de DatabaseVullerPagina in de WPF.
        /// De paramaters die worden meegegeven worden random gegenereerd in de klassen AdresVuller, BestuurderVuller, TankkaartVuller en VoertuigVuller (in de map dbVullers).
        /// Alle gegenereerde parameters voldoen aan de checks in de klassen Adres, Bestuurder, Tankkaart en Voertuig.
        /// 
        /// Werking per for-loop:
        /// Er wordt een nieuw Adres aangemaakt en weer opgehaald samen met het door de databank gegenereerd AdresId.
        /// Er wordt een nieuw Voertuig aangemaakt, de randomMerkModelArray zorgt voor matching Merk en Model.
        /// Er wordt een nieuwe Tankkaart aangemaakt.
        /// Er wordt een nieuwe Bestuurder aangemaakt, inclusief 60% om elk van Chassisnummer, Kaartnummer en AdresId mee te geven aan de Bestuurder.
        /// </summary>
        Random random = new Random();
        public void DatabankVuller(int aantal)
        {
            string merk;
            string model;
            string[] merkModel = new string[2];
            
            for (int i = 0; i < aantal; i++)
            {
                try
                {
                    string straatnaam = _av.randomStraatnaam();
                    string huisnummer = _av.randomNummer();
                    int postcode = _av.randomPostcode();
                    string stad = _av.randomStad();
                    _adresCon.CreateAdres(straatnaam, huisnummer, postcode, stad);
                    merkModel = _vv.randomMerkModelArray();
                    merk = merkModel[0];
                    model = merkModel[1];
                    Voertuig voertuig = new Voertuig(merk, model, _vv.randomChassisnummer(), _vv.randomNummerplaat(), _vv.randomBrandstoftype(),
                                                        _vv.randomWagentype(), _vv.randomKleur(), _vv.randomAantalDeuren());
                    Tankkaart tankkaart = new Tankkaart(_tv.randomKaartnummer(), _tv.randomGeldigheidsdatum(), _tv.randomGeblokkeerd(),
                                                            _tv.randomPincode(), _tv.randomBrandstoftype());

                    string chassisnummer = null;
                    string kaartnummer = null;
                    int? adresId = null;
                    if (random.Next(10) < 6)
                    {
                        chassisnummer = voertuig.Chassisnummer;
                    }
                    if (random.Next(10) < 6)
                    {
                        kaartnummer = tankkaart.Kaartnummer;
                    }
                    if (random.Next(10) < 6)
                    {
                        adresId = _adresCon.GeefLaatsteAdres().AdresId;
                    }
                    Bestuurder bestuurder = new Bestuurder(_bv.randomId(), _bv.randomNaam(), _bv.randomVoornaam(), _bv.randomDatum(), _bv.randomRijksregisternummer(),
                                                            _bv.randomRijbewijs(), chassisnummer, kaartnummer, adresId);

                    _voertuigCon.CreateVoertuig(voertuig);
                    _tankkaartCon.CreateTankkaart(tankkaart);
                    _bestuurderCon.CreateBestuurder(bestuurder);
                }
                catch
                {
                    i--;
                }
            }
        }



        #region Bestuurder

        public List<Bestuurder> FilterLijstBestuurderV2(string bestuurderId, string naam, string voornaam, 
                                                        string geboortedatum, string rijksnummer, string rijbewijs )
        {
            List<Bestuurder> lijst = new List<Bestuurder>();

            foreach (Bestuurder bestuurder in _bestuurderCon.GeefBestuurders())
            {
                if ((bestuurder.BestuurderId.ToLower().Contains(bestuurderId.ToLower()) || bestuurderId == "")
                    && (bestuurder.Naam.ToLower().Contains(naam.ToLower()) || naam == "")
                    && (bestuurder.Voornaam.ToLower().Contains(voornaam.ToLower()) || voornaam == "")
                    && (bestuurder.Geboortedatum.ToString().Contains(geboortedatum) || geboortedatum == "")
                    && (bestuurder.Rijksregisternummer.Contains(rijksnummer) || rijksnummer == "")
                    && (bestuurder.Rijbewijs.ToString().ToLower().Contains(rijbewijs.ToLower()) || rijbewijs == ""))
                {
                    lijst.Add(bestuurder);
                }
            }

            return lijst;
        }

        public List<Bestuurder> GeefBestuurders()
        {
            return _bestuurderCon.GeefBestuurders();
        }

        public void CreateBestuurder(Bestuurder bestuurder)
        {
            _bestuurderCon.CreateBestuurder(bestuurder);
        }

        public void UpdateBestuurder(Bestuurder bestuurder)
        {
            _bestuurderCon.UpdateBestuurder(bestuurder);
        }


        public void DeleteBestuurder(Bestuurder bestuurder)
        {
            _bestuurderCon.DeleteBestuurder(bestuurder);
        }

        public void RetrieveBestuurder(Bestuurder bestuurder)
        {
            _bestuurderCon.RetrieveBestuurder(bestuurder);
        }

        public List<Bestuurder> FilterLijstBestuurder(string zoekterm, string kolom)
        {
            List<Bestuurder> lijst = new List<Bestuurder>();
            string k = kolom.ToLower();
            string z = zoekterm.ToLower();

            foreach (Bestuurder bestuurder in _bestuurderCon.GeefBestuurders())
            {
                List<string> paramater = new List<string>();
                if (k == "bestuurderid" || k == "all") paramater.Add(bestuurder.BestuurderId);
                if (k == "naam" || k == "all") paramater.Add(bestuurder.Naam);
                if (k == "voornaam" || k == "all") paramater.Add(bestuurder.Voornaam);
                if (k == "geboortedatum" || k == "all") paramater.Add(bestuurder.Geboortedatum.ToString());
                if (k == "rijksregisternummer" || k == "all") paramater.Add(bestuurder.Rijksregisternummer);
                if (k == "rijbewijs" || k == "all") paramater.Add(bestuurder.Rijbewijs.ToString());

                foreach (string p in paramater)
                {
                    if (p.ToLower().Contains(z))
                    {
                        if (!lijst.Contains(bestuurder))
                        {
                            lijst.Add(bestuurder);
                        }
                    }
                }
            }

            return lijst;
        }

        #endregion



        #region Adres

        public List<Adres> GeefAdressen()
        {
            return _adresCon.GeefAdressen();
        }

        public Adres GeefLaatsteAdres()
        {
            return _adresCon.GeefLaatsteAdres();
        }

        public void CreateAdres(string straatnaam, string huisnummer, int postcode, string stad)
        {
            _adresCon.CreateAdres(straatnaam, huisnummer, postcode, stad);
        }

        public void UpdateAdres(Adres adres)
        {
            _adresCon.UpdateAdres(adres);
        }

        public void DeleteAdres(Adres adres)
        {
            _adresCon.DeleteAdres(adres);
        }

        public void RetrieveAdres(Adres adres)
        {
            _adresCon.RetrieveAdres(adres);
        }

        //public List<Adres> GeefAdressenMetBestuurder()
        //{
        //    List<Adres> adressen = new List<Adres>();
        //    foreach (Adres adres in _adresCon.GeefAdressen())
        //    {
        //        adres.BestuurderId = _bestuurderCon.GeefBestuurderIdByAdresId(adres.AdresId);
        //        adressen.Add(adres);
        //    }
        //    return adressen;
        //}

        #endregion



        #region Tankkaart

        public List<Tankkaart> FilterLijstTankkaartV2(string kaartnummer, string geldigheidsdatum, bool geblokkeerd,
                                                        string pincode, string brandstof)
        {
            List<Tankkaart> lijst = new List<Tankkaart>();

            foreach (Tankkaart tankkaart in _tankkaartCon.GeefTankkaarten())
            {
                if ((tankkaart.Kaartnummer.ToLower().Contains(kaartnummer.ToLower()) || kaartnummer == "")
                    && (tankkaart.Geldigheidsdatum.ToString().Contains(geldigheidsdatum) || geldigheidsdatum == "")
                    && (tankkaart.Geblokkeerd == geblokkeerd)
                    && (tankkaart.Pincode.ToString().Contains(pincode) || pincode == "")
                    && (tankkaart.Brandstof.ToString().ToLower().Contains(brandstof.ToLower()) || brandstof == ""))
                {
                    lijst.Add(tankkaart);
                }
            }

            return lijst ;
        }

        public List<Tankkaart> GeefTankkaarten()
        {
            return _tankkaartCon.GeefTankkaarten();
        }

        public List<Tankkaart> GeefTankkaartenMetBestuurderId()
        {
            List<Tankkaart> tankkaarten = _tankkaartCon.GeefTankkaarten();
            List<Bestuurder> bestuurders = _bestuurderCon.GeefBestuurders();

            foreach (Bestuurder bestuurder in bestuurders)
            {
                Tankkaart tankkaart = tankkaarten.Where(t => t.Kaartnummer == bestuurder.TankkaartNummer).FirstOrDefault(); //TODO: deze methode moet over alle tankkaarten lopen (ook deleted)
                if (tankkaart != null)
                {
                    tankkaart.BestuurderId = bestuurder.BestuurderId;

                }
                else { continue; }                                                                                                            //of moet gewoon skippen als er een tankkaart nie wordt gevonden
            }

            return tankkaarten;
        }

        public void CreateTankkaart(Tankkaart tankkaart)
        {
            _tankkaartCon.CreateTankkaart(tankkaart);
        }

        public void DeleteTankkaart(Tankkaart tankkaart)
        {
            _tankkaartCon.DeleteTankkaart(tankkaart);
        }
        public void UpdateTankkaart(Tankkaart tankkaart)
        {
            _tankkaartCon.UpdateTankkaart(tankkaart);
        }

        public void RetrieveTankkaart(Tankkaart tankkaart)
        {
            _tankkaartCon.RetrieveTankkaart(tankkaart);
        }

        public List<Tankkaart> FilterLijstTankkaart(string zoekterm, string kolom) 
        {
            List<Tankkaart> lijst = new List<Tankkaart>();
            string k = kolom.ToLower();
            string z = zoekterm.ToLower();

            foreach (Tankkaart tankkaart in _tankkaartCon.GeefTankkaarten())
            {
                List<string> paramater = new List<string>();
                if (k == "kaartnummer" || k == "all") paramater.Add(tankkaart.Kaartnummer);
                if (k == "geldigheidsdatum" || k == "all") paramater.Add(tankkaart.Geldigheidsdatum.ToString());
                if (k == "brandstof" || k == "all") paramater.Add(tankkaart.Brandstof.ToString());
                if (k == "pincode" || k == "all") paramater.Add(tankkaart.Pincode.ToString());
                if (k == "isGeblokkeerd" || k == "all") paramater.Add(tankkaart.Geblokkeerd.ToString());

                foreach (string p in paramater)
                {
                    if (p.ToLower().Contains(z))
                    {
                        if (!lijst.Contains(tankkaart))
                        {
                            lijst.Add(tankkaart);
                        }
                    }
                }
            }

            return lijst;
        }

        #endregion



        #region Voertuig

        public List<Voertuig> FilterLijstVoertuigV2(string merk, string model, string chassisnummer, string nummerplaat,
                                                        string brandstoftype, string wagentype, string kleur, string aantalDeuren)
        {
            List<Voertuig> lijst = new List<Voertuig>();

            foreach (Voertuig voertuig in _voertuigCon.GeefVoertuigen())
            {
                if ((voertuig.Merk.ToLower().Contains(merk.ToLower()) || merk == "")
                    && (voertuig.Model.ToLower().Contains(model.ToLower()) || model == "")
                    && (voertuig.Chassisnummer.ToUpper().Contains(chassisnummer.ToUpper()) || chassisnummer == "")
                    && (voertuig.Nummerplaat.ToUpper().Contains(nummerplaat.ToUpper()) || nummerplaat == "")
                    && (voertuig.Brandstoftype.ToString().ToLower().Contains(brandstoftype.ToLower()) || brandstoftype == "")
                    && (voertuig.Wagentype.ToString().ToLower().Contains(wagentype.ToLower()) || wagentype == "")
                    && (voertuig.Kleur.ToLower().Contains(kleur.ToLower()) || kleur == "")
                    && (voertuig.AantalDeuren.ToString().Contains(aantalDeuren) || aantalDeuren == "")
                    )
                {
                    lijst.Add(voertuig);
                }
            }

            return lijst;
        }

        public List<Voertuig> GeefVoertuigen()
        {
            return _voertuigCon.GeefVoertuigen();
        }

        public List<Voertuig> GeefVoertuigenMetBestuurderId()
        {
            List<Voertuig> voertuigen = _voertuigCon.GeefVoertuigen();
            List<Bestuurder> bestuurders = _bestuurderCon.GeefBestuurders();

            foreach (Bestuurder bestuurder in bestuurders)
            {
                Voertuig voertuig = voertuigen.Where(v => v.Chassisnummer == bestuurder.ChassisnummerVoertuig).FirstOrDefault();

                if (voertuig != null)
                {
                    voertuig.BestuurderId = bestuurder.BestuurderId;

                }
                else
                {
                    continue;
                }
            }

            return voertuigen;
        }

        public void CreateVoertuig(Voertuig voertuig)
        {
            _voertuigCon.CreateVoertuig(voertuig);
        }

        public void UpdateVoertuig(Voertuig voertuig)
        {
            _voertuigCon.UpdateVoertuig(voertuig);

        }

        public void DeleteVoertuig(Voertuig voertuig)
        {
            _voertuigCon.DeleteVoertuig(voertuig);

        }

        public void RetrieveVoertuig(Voertuig voertuig)
        {
            _voertuigCon.RetrieveVoertuig(voertuig);

        }

        public List<Voertuig> FilterLijstVoertuig(string zoekterm, string kolom)
        {
            List<Voertuig> lijst = new List<Voertuig>();
            string k = kolom.ToLower();
            string z = zoekterm.ToLower();

            foreach (Voertuig voertuig in _voertuigCon.GeefVoertuigen())
            {
                List<string> paramater = new List<string>();
                if (k == "chassisnummer" || k == "all") paramater.Add(voertuig.Chassisnummer);
                if (k == "nummerplaat" || k == "all") paramater.Add(voertuig.Nummerplaat);
                if (k == "merk" || k == "all") paramater.Add(voertuig.Merk);
                if (k == "model" || k == "all") paramater.Add(voertuig.Model);
                if (k == "typevoertuig" || k == "all") paramater.Add(voertuig.Wagentype.ToString());
                if (k == "brandstof" || k == "all") paramater.Add(voertuig.Brandstoftype.ToString());
                if (k == "kleur" || k == "all") paramater.Add(voertuig.Kleur);
                if (k == "aantalDeuren" || k == "all") paramater.Add(voertuig.AantalDeuren.ToString());

                foreach (string p in paramater)
                {
                    if (p.ToLower().Contains(z))
                    {
                        if (!lijst.Contains(voertuig))
                        {
                            lijst.Add(voertuig);
                        }
                    }
                }
            }

            return lijst;
        }

        #endregion



    }
}
