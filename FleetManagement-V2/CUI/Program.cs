// See https://aka.ms/new-console-template for more information


using Domein.Controllers;
using Domein.dbVullers;
using Domein;
using Domein.Objects;
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



            #region Vuller

            //Bestuurder test = new Bestuurder(bv.randomId(), bv.randomNaam(), bv.randomVoornaam(), bv.randomDatum(), bv.randomRijksregisternummer(), bv.randomRijbewijs());
            //bestuurderCon.CreateBestuurder(test);
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            //bv.VulBestuurderTabel(1000);
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));

            #endregion

            #region filter

            //bestuurderfilterlijst
            //Console.Write("Zoekterm: ");
            //string zoekterm = Console.ReadLine();
            //Console.Write("Kolom ('all' voor elke kolom): ");
            //string kolom = Console.ReadLine();
            //foreach (Bestuurder bestuurder in dc.FilterLijstBestuurder(zoekterm, kolom))
            //{
            //    Console.WriteLine(bestuurder.ToString());
            //}

            //tankkaartfilterlijst
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

            //Bestuurder testBestuurder = new Bestuurder("755952bs", "Baele", "Gert", DateTime.Parse("02/02/2002"), "77031925424", Domein.Enums.Rijbewijs.B);
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

            Console.WriteLine("Dit zijn de adressen:");
            foreach (Adres adres in adresCon.GeefAdressen())
            {
                Console.WriteLine(adres.ToString());
            }
            
            #endregion

            #region Voertuigen

            //Console.WriteLine("Dit zijn de voertuigen:");
            //foreach (Voertuig voertuig in voertuigCon.GeefVoertuigen())
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

            //Tankkaart test = new Tankkaart("7474747474", new DateTime(2028, 2, 22), false, 1956, Domein.Enums.Brandstoftype.diesel);
            //tankkaartCon.UpdateTankkaart(test);

            #endregion
        }
    }
}