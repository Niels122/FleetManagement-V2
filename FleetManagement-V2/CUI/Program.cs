// See https://aka.ms/new-console-template for more information


using Domein.Controllers;
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




            #region Bestuurder

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
            #endregion

            #region CRUD
            Console.WriteLine("Dit zijn de bestuurders:");
            foreach (Bestuurder bestuurder in dc.GeefBestuurders())
            {
                Console.WriteLine(bestuurder.ToString());
            }
            Console.WriteLine("-----------------------------------------------");

            Bestuurder testBestuurder = new Bestuurder(0, "Hazard", "Eden", DateTime.Parse("23/10/1956"), "72111878912", Domein.Enums.Rijbewijs.A);
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

        #endregion

            #region
            //Console.WriteLine("Dit zijn de adressen:");
            //foreach(Adres adres in adresCon.GeefAdressen())
            //{
            //    Console.WriteLine(adres.ToString());
            //}

            //Console.WriteLine("Dit zijn de adressen met bestuurders:");
            //foreach (Adres adres in dc.GeefAdressenMetBestuurder())
            //{
            //    Console.WriteLine(adres.ToString());
            //}
            #endregion

            #region
            //Console.WriteLine("Dit zijn de voertuigen:");
            //foreach(Voertuig voertuig in voertuigCon.GeefVoertuigen())
            //{
            //    Console.WriteLine(voertuig.ToString());
            //}
            #endregion

            #region
            //Console.WriteLine("Dit zijn de tankkaarten:");
            //foreach(Tankkaart tankkaart in tankkaartCon.GeefTankkaarten())
            //{
            //    Console.WriteLine(tankkaart.ToString());
            //}
            #endregion
        }
    }
}