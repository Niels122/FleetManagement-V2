﻿// See https://aka.ms/new-console-template for more information


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

            DomeinController dc = new DomeinController(voertuigCon, tankkaartCon, bestuurderCon, adresCon);

            BestuurderVuller bv = new BestuurderVuller(bestuurderCon);

            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));





            //Random random = new Random();
            //public void Tabelvuller(int aantal)
            //{
            //    bv.VulBestuurderTabel(aantal);
            //    List<Bestuurder> bestuurders = bestuurderCon.GeefBestuurders();
            //    Bestuurder bestuurder;
            //    Adres adres;
            //    Voertuig voertuig;
            //    Tankkaart tankkaart;

            //    for (int i = 0; i < aantal; i++) //KANSEN NOG IMPLEMENTEREN
            //    {
            //        bestuurder = bestuurders[random.Next(bestuurders.Count())]; //OF bestuurder = bv.MaakBestuur() met retur het gecreerde object
            //        adres = adresCon.CreateAdres(); //moet wss nog een return Adres erbij zodat het in adres kan gestoken worden
            //        voertuig = voertuigCon.CreateVoertuig();
            //        tankkaart = tankkaartCon.CreateTankkaart();
            //        bestuurderCon.UpdateBestuurder(new Bestuurder(bestuurder.BestuurderId, bestuurder.Naam, bestuurder.Voornaam, bestuurder.Geboortedatum,
            //                              bestuurder.Rijksregisternummer, bestuurder.Rijbewijs, voertuig.Chassisnummer, tankkaart.Kaartnummer, adres.AdresId))
            //        bestuurders.Remove(bestuurder);
            //    }
            //}




            #region Vuller

            //Bestuurder test = new Bestuurder(bv.randomId(), bv.randomNaam(), bv.randomVoornaam(), bv.randomDatum(), bv.randomRijksregisternummer(), bv.randomRijbewijs());
            //bestuurderCon.CreateBestuurder(test);

            //bv.VulBestuurderTabel(1);

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

            //Bestuurder testBestuurder = new Bestuurder("519462jv", "Baele", "Joerie", new DateTime(1977, 7, 18), "30092408879", Domein.Enums.Rijbewijs.B, "5TDZK22C39S270189", "321456987", 3);
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

            ////adresCon.CreateAdres("Langesteenweg", "347", 9020, "Drongen");
            //adresCon.UpdateAdres(new Adres(6, "Antwerpsesteenweg", "77", 4000, "Hasselt"));

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

            //voertuigCon.RetrieveVoertuig(new Voertuig("Mercedes", "CLA", "ADMLFISDFJ498P", "1-ZZZ-999", Brandstoftype.diesel, Wagentype.bestelwagen, "geel", 33));

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
            //TankkaartCon.UpdateTankkaart(test);

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