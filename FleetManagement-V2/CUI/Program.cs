// See https://aka.ms/new-console-template for more information


using Domein.Controllers;
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

            Console.WriteLine("Dit zijn de voertuigen:");
            dc.GeefVoertuigen().ForEach(Console.WriteLine);



        }
    }
}