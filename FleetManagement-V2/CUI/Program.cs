// See https://aka.ms/new-console-template for more information


using Domein.Controllers;
using Domein.dbVullers;
using Domein;
using Domein.Objects;
using Domein.Enums;
using Persistentie;
using System;

namespace CUI
{
    internal class Program
    {

        static void Main(string[] args)
        {
            BestuurderRepository bestuurderRepo = new BestuurderRepository();
            AdresRepository adresRepo = new AdresRepository();
            VoertuigRepository voertuigRepo = new VoertuigRepository();
            TankkaartRepository tankkaartRepo = new TankkaartRepository();

            BestuurderController bestuurderCon = new BestuurderController(bestuurderRepo);
            AdresController adresCon = new AdresController(adresRepo);
            VoertuigController voertuigCon = new VoertuigController(voertuigRepo);
            TankkaartController tankkaartCon = new TankkaartController(tankkaartRepo);

            BestuurderVuller bv = new BestuurderVuller();
            AdresVuller av = new AdresVuller();
            VoertuigVuller vv = new VoertuigVuller();
            TankkaartVuller tv = new TankkaartVuller();

            DomeinController dc = new DomeinController(voertuigCon, tankkaartCon, bestuurderCon, adresCon, bv, av, vv, tv);


            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));

            #region Vuller

            //dc.DatabankVuller(10000);

            #endregion

            #region filter

            //Console.WriteLine("Bestuurderfilter: ");
            //Console.Write("BestuurderId: ");
            //string bestuurderId = Console.ReadLine();
            //Console.Write("Naam: ");
            //string naam = Console.ReadLine();
            //Console.Write("Voornaam: ");
            //string voornaam = Console.ReadLine();
            //Console.Write("Geboortedatum: ");
            //string geboortedatum = Console.ReadLine();
            //Console.Write("Rijksregisternummer: ");
            //string rijksnummer = Console.ReadLine();
            //Console.Write("Rijbewijs: ");
            //string rijbewijstype = Console.ReadLine();
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            //foreach (Bestuurder bestuurder in dc.FilterLijstBestuurderV2(bestuurderId, naam, voornaam, geboortedatum, rijksnummer, rijbewijstype))
            //{
            //    Console.WriteLine(bestuurder.ToString());
            //}

            //Console.WriteLine("Tankaartfilter: ");
            //Console.Write("kaartnummer: ");
            //string kaartnummer = Console.ReadLine();
            //Console.Write("geldigheidsdatum: ");
            //string geldigheidsdatum = Console.ReadLine();
            //Console.Write("geblokkeerd: ");
            //bool geblokkeerd = Convert.ToBoolean(Console.ReadLine());
            //Console.Write("pincode: ");
            //string pincode = Console.ReadLine();
            //Console.Write("brandstof: ");
            //string brandstof = Console.ReadLine();
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            //foreach (Tankkaart tankkaart in dc.FilterLijstTankkaartV2(kaartnummer, geldigheidsdatum, geblokkeerd, pincode, brandstof))
            //{
            //    Console.WriteLine(tankkaart.ToString());
            //}

            //Console.WriteLine("Voertuigfilter: ");
            //Console.Write("merk: ");
            //string merk = Console.ReadLine();
            //Console.Write("model: ");
            //string model = Console.ReadLine();
            //Console.Write("chassisnummer: ");
            //string chassisnummer = Console.ReadLine();
            //Console.Write("nummerplaat: ");
            //string nummerplaat = Console.ReadLine();
            //Console.Write("brandstoftype: ");
            //string brandstoftype = Console.ReadLine();
            //Console.Write("wagentype: ");
            //string wagentype = Console.ReadLine();
            //Console.Write("kleur: ");
            //string kleur = Console.ReadLine();
            //Console.Write("aantaldeuren: ");
            //string aantaldeuren = Console.ReadLine();
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            //foreach (Voertuig voertuig in dc.FilterLijstVoertuigV2(merk, model, chassisnummer, nummerplaat, brandstoftype, wagentype, kleur, aantaldeuren))
            //{
            //    Console.WriteLine(voertuig.ToString());
            //}

            #endregion

            #region Bestuurder

            //Console.WriteLine("Dit zijn de bestuurders:");
            //foreach (Bestuurder bestuurder in dc.GeefBestuurders())
            //{
            //    Console.WriteLine(bestuurder.ToString());
            //}
            //Console.WriteLine("-----------------------------------------------");

            //Bestuurder testBestuurder = new Bestuurder("208476xf", "Baele", "Joerie", new DateTime(1977, 7, 18), "30092408879", Domein.Enums.Rijbewijs.B, "ADMLFKSDFJ498PSPW", "111111111111111111", 7);
            //bestuurderCon.CreateBestuurder(testBestuurder);
            //bestuurderCon.UpdateBestuurder(testBestuurder);   //getest op normale input, foute input (exception persistentie) en onbestaande input (exception persistentie)
            //bestuurderCon.DeleteBestuurder(testBestuurder);   //getest op normale input, foute input en onbestaande input
            //bestuurderCon.RetrieveBestuurder(testBestuurder); //getest op normale input, foute input en onbestaande input

            //Console.WriteLine("-----------------------------------------------");
            //Console.WriteLine("Dit zijn de bestuurders:");
            //foreach (Bestuurder bestuurder in dc.GeefBestuurders())
            //{
            //    Console.WriteLine(bestuurder.ToString());
            //}

            #endregion

            #region Adressen

            //Console.WriteLine("Dit zijn de adressen:");
            //foreach (Adres adres in adresCon.GeefAdressen())
            //{
            //    Console.WriteLine(adres.ToString());
            //}
            //Console.WriteLine("-----------------------------------------------");


            //Console.WriteLine(dc.GeefLaatsteAdres().ToString());
            //adresCon.CreateAdres("Bladerdeeglaan", "47", 9040, "Gent");
            //adresCon.UpdateAdres(new Adres(6, "Antwerpsesteenweg", "77", 4000, "Hasselt"));
            //Console.WriteLine(dc.GeefLaatsteAdres().ToString());

            //Console.WriteLine("-----------------------------------------------");
            //Console.WriteLine("Dit zijn de adressen:");
            //foreach (Adres adres in adresCon.GeefAdressen())
            //{
            //    Console.WriteLine(adres.ToString());
            //}

            #endregion

            #region Voertuigen

            //Console.WriteLine("Dit zijn de voertuigen:");
            //foreach (Voertuig voertuig in voertuigCon.GeefVoertuigen())
            //{
            //    Console.WriteLine(voertuig.ToString());
            //}
            //Console.WriteLine("-----------------------------------------------");

            //voertuigCon.UpdateVoertuig(new Voertuig("Mercedes", "CLA", "ADMLFkSDFJ498PSPW", "1-kzo-999", Brandstoftype.Diesel, Wagentype.Bestelwagen, "geel", 33));

            //Console.WriteLine("-----------------------------------------------");
            //Console.WriteLine("Dit zijn de voertuigen met BestuurderId:");
            //foreach (Voertuig voertuig in dc.GeefVoertuigenMetBestuurderId())
            //{
            //    Console.WriteLine(voertuig.ToString());
            //}

            #endregion

            #region Tankkaarten

            //Console.WriteLine("Dit zijn de tankkaarten:");
            //foreach (Tankkaart tankkaart in tankkaartCon.GeefTankkaarten())
            //{
            //    Console.WriteLine(tankkaart.ToString());
            //}
            //Console.WriteLine("-----------------------------------------------");

            //Tankkaart test = new Tankkaart("111111111111111111", new DateTime(2040, 11, 15), false, 7777, Brandstoftype.diesel);
            //tankkaartCon.CreateTankkaart(test);

            //Console.WriteLine("-----------------------------------------------");
            //Console.WriteLine("Dit zijn de tankkaarten:");
            //foreach (Tankkaart tankkaart in dc.GeefTankkaartenMetBestuurderId())
            //{
            //    Console.WriteLine(tankkaart.ToString());
            //}

            #endregion

            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
        }
    }
}