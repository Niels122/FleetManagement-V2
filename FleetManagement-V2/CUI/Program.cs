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


            //bestuurderfilterlijst
            //Console.Write("Zoekterm: ");
            //string zoekterm = Console.ReadLine();
            //Console.Write("Kolom ('all' voor elke kolom): ");
            //string kolom = Console.ReadLine();
            //foreach (Bestuurder bestuurder in dc.FilterLijstBestuurder(zoekterm, kolom))
            //{
            //    Console.WriteLine(bestuurder.ToString());
            //}

            #region Bestuurder
            Console.WriteLine("Dit zijn de bestuurders:");
            foreach (Bestuurder bestuurder in dc.GeefBestuurders())
            {
                Console.WriteLine(bestuurder.ToString());
            }

            Bestuurder testBestuurder = new Bestuurder(3, "Janssens", "Jan", DateTime.Parse("11/11/1996"), "72111678912", Domein.Enums.Rijbewijs.A, 3, 3, 3);
            bestuurderCon.CreateBestuurder(testBestuurder);

            Console.WriteLine("Dit zijn de bestuurders:");
            foreach (Bestuurder bestuurder in dc.GeefBestuurders())
            {
                Console.WriteLine(bestuurder.ToString());
            }
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