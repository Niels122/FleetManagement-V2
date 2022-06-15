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

            BestuurderVuller bv = new BestuurderVuller(bestuurderCon);
            AdresVuller av = new AdresVuller(adresCon);
            VoertuigVuller vv = new VoertuigVuller(voertuigCon);
            TankkaartVuller tv = new TankkaartVuller(tankkaartCon);

            DomeinController dc = new DomeinController(voertuigCon, tankkaartCon, bestuurderCon, adresCon, bv, av, vv, tv);


            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));


            #region Vuller

            dc.DatabankVuller(10);

            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            //bv.VulBestuurderTabel(100); //4 seconden voor 1000
            //Console.Write("Bestuurder: ");
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            //tv.VulTankkaarTabel(100); // 1 seconde voor 1000
            //Console.Write("Tankkaart: ");
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            //vv.VulVoertuigTabel(100); // 17 seconden voor 1000
            //Console.Write("Voertuig: ");
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            //av.VulAdresTabel(1000); // 2 seconden voor 1000
            //Console.Write("Adres: "); //totaal voor 1000 = 24 seconden|5 seconden voor 100
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));

            #endregion

            #region filter
            //bestuurderfilter
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            //Console.Write("Zoekterm: ");
            //string zoekterm = Console.ReadLine();
            //Console.Write("Kolom ('all' voor elke kolom): ");
            //string kolom = Console.ReadLine();
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            //foreach (Bestuurder bestuurder in dc.FilterLijstBestuurder(zoekterm, kolom))
            //{
            //    Console.WriteLine(bestuurder.ToString());
            //}

            //tankkaartfilter
            //Console.Write("Zoekterm: ");
            //string zoekterm = Console.ReadLine();
            //Console.Write("Kolom ('all' voor elke kolom): ");
            //string kolom = Console.ReadLine();
            //foreach (Tankkaart tankkaart in dc.FilterLijstTankkaart(zoekterm, kolom))
            //{
            //    Console.WriteLine(tankkaart.ToString());
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