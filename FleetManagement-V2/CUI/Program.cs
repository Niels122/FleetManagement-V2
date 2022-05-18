// See https://aka.ms/new-console-template for more information


using Domein.Controllers;
using Domein.Objects;
using Persistentie;
using System;

namespace CUI
{
    internal class Program
    {

        static void Main(string[] args)
        {
            

            VoertuigRepository vr = new VoertuigRepository();
            BestuurderRepository br = new BestuurderRepository();
            TankkaartRepository tr = new TankkaartRepository();

            VoertuigController vc = new VoertuigController(vr);
            BestuurderController bc = new BestuurderController(br);
            TankkaartController tc = new TankkaartController(tr);


            DomeinController dc = new DomeinController(vc,tc,bc);



            #region Bestuurder
            //alle mogelijke constructoren van Bestuurder
            Bestuurder a = new Bestuurder("", "", new DateTime(1999 - 11 - 11), "", Domein.Enums.Rijbewijs.G);
            Bestuurder aa = new Bestuurder("", "", new DateTime(1999 - 11 - 11), "", Domein.Enums.Rijbewijs.G, new Adres());
            Bestuurder aaa = new Bestuurder("", "", new DateTime(1999 - 11 - 11), "", Domein.Enums.Rijbewijs.G, new Adres(), new Voertuig());
            Bestuurder aaaa = new Bestuurder("", "", new DateTime(1999 - 11 - 11), "", Domein.Enums.Rijbewijs.G, new Adres(), new Voertuig(), new Tankkaart());
            Bestuurder aaaaa = new Bestuurder("", "", new DateTime(1999 - 11 - 11), "", Domein.Enums.Rijbewijs.G, new Adres(), new Tankkaart());
            Bestuurder aaaaaa = new Bestuurder("", "", new DateTime(1999 - 11 - 11), "", Domein.Enums.Rijbewijs.G, new Voertuig());
            Bestuurder aaaaaaa = new Bestuurder("", "", new DateTime(1999 - 11 - 11), "", Domein.Enums.Rijbewijs.G, new Voertuig(), new Tankkaart());
            Bestuurder aaaaaaaa = new Bestuurder("", "", new DateTime(1999 - 11 - 11), "", Domein.Enums.Rijbewijs.G, new Tankkaart());

            Console.WriteLine("Dit zijn de bestuurders:");
            
            foreach(List<string> bestuurdersLijst in dc.GeefBestuurders())
            {
                bestuurdersLijst.ForEach(x => Console.WriteLine(x));
            }

            #endregion


            Console.WriteLine("Dit zijn de voertuigen:");

            foreach (List<string> voertuig in dc.GeefVoertuigen())
            {
                voertuig.ForEach(x => Console.WriteLine(x));
            }

            //voertuigen.ForEach(Console.WriteLine);

            //foreach (Voertuig voertuig in dc.GeefVoertuigen())
            //{
            //    Console.WriteLine(voertuig.ToString());
            //}

        }
    }
}