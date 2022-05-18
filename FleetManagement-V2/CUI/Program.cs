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


            DomeinController dc = new DomeinController(vc, tc, bc);




            //alle mogelijke constructoren van Bestuurder



            Console.WriteLine("Dit zijn de voertuigen:");
            List<Voertuig> voertuigen = dc.GeefVoertuigen();

            List<string> voertuigenInfo = new();

            foreach (Voertuig voertuig in voertuigen)
            {
                if (voertuig != null)
                {
                    voertuigenInfo.Add(voertuig.ToString());
                }
                else
                {
                    break;
                }


            }
            //List<List<string>> voertuigen = dc.GeefVoertuigen();

            //foreach (List<string> voertuig in voertuigen)
            //{
            //    voertuig.ForEach(x => Console.WriteLine(x));
            //}

            //voertuigen.ForEach(Console.WriteLine);

            //foreach (Voertuig voertuig in dc.GeefVoertuigen())
            //{
            //    Console.WriteLine(voertuig.ToString());
            //}

        }
    }
}