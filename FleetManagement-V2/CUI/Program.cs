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

            //Console.WriteLine("Dit zijn de bestuurders met hun adres, automodel en tankkaartid:");
            //foreach(Bestuurder bestuurder in bc.GeefBestuurdersMetDetails)

            #region Bestuurder
            //Console.WriteLine("Dit zijn de bestuurders:");            
            //foreach(Bestuurder bestuurder in dc.GeefBestuurders())
            //{
            //    Console.WriteLine(bestuurder.ToString());   
            //}
            #endregion

            #region
            Console.WriteLine("Dit zijn de adressen:");
            foreach(Adres adres in adresCon.GeefAdressen())
            {
                Console.WriteLine(adres.ToString());
            }
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