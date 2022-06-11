using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domein.Controllers;
using Domein.Enums;
using Domein.Objects;

namespace Domein.dbVullers
{
    public class BestuurderVuller
    {
        BestuurderController bc;

        public BestuurderVuller(BestuurderController _bc)
        {
            bc = _bc;
        }

        public void VulBestuurderTabel(int aantal)
        {
            for(int i = 0; i < aantal; i++)
            {
                bc.CreateBestuurder(new Bestuurder(randomId(), randomNaam(), randomVoornaam(), randomDatum(), 
                                                    randomRijksregisternummer(), randomRijbewijs()));
            }
        }

        Random random = new Random();

        List<string> naamLijst = new List<string> { "De Wever", "Van De Velde", "De Paepe", "Ketelaere", "Dendoncker", "Maes", "De Waele", 
                                                    "Janssens", "Peters", "Braems", "Mees", "De Praetere", "De Jonckheere", "Vervaet", 
                                                    "Van Den Berghe", "De Ridder", "Verhelst", "Verbrughe", "Van de Vyver", "De Smet" };
        public string randomNaam()
        {
            return naamLijst[random.Next(naamLijst.Count())];
        }

        List<string> voornaamLijst = new List<string> { "Geert", "Els", "Lukas", "Daan", "Laura", "Thomas", "Robbe", "Vicky", 
                                                        "Steven" , "Eva", "Lisa", "Wouter", "Jens", "Pieter", "Brecht", "Michiel", 
                                                        "Ewout", "Kobe", "Hanne", "Amelie", "Jolien", "Manon", "Olivia" };
        public string randomVoornaam()
        {
            return voornaamLijst[random.Next(voornaamLijst.Count())];
        }

        List<Rijbewijs> rijbewijsTypes = new List<Rijbewijs> { Rijbewijs.A, Rijbewijs.B, Rijbewijs.C, Rijbewijs.D };
        public Rijbewijs randomRijbewijs()
        {
            return rijbewijsTypes[random.Next(rijbewijsTypes.Count())];
        }

        string alfabet = "abcdefghijklmnopqrstuvwxyz";
        public string randomId()
        {
            string id = "";

            for (int i = 0; i < 6; i++)
            {
                id += random.Next(10).ToString();
            }

            int index = random.Next(alfabet.Length);
            id += alfabet[index];
            int index2 = random.Next(alfabet.Length);
            id += alfabet[index2];

            return id;
        }

        DateTime start = new DateTime(1990, 1, 1);
        int verschil = (new DateTime(1999, 12, 31) - new DateTime(1990, 1, 1)).Days;
        public DateTime randomDatum()
        {
            return start.AddDays(random.Next(verschil));
        }

        public string randomRijksregisternummer()
        {
            string nummer = "";
            string nummer2 = "";
            string controlegetal = "";
            bool voor2000 = false;

            string jaar = random.Next(100).ToString();
            if (int.Parse(jaar) < 10)
            {
                string jaar2 = jaar.Insert(0, "0");
                nummer = jaar2;
                voor2000 = true;
            }
            else
            {
                nummer = jaar;
            }

            string maand = random.Next(1, 13).ToString();
            if (int.Parse(maand) < 10)
            {
                string maand2 = maand.Insert(0, "0");
                nummer += maand2;
            }
            else
            {
                nummer += maand;
            }

            string dag = random.Next(1, 32).ToString();
            if (int.Parse(dag) < 10)
            {
                string dag2 = dag.Insert(0, "0");
                nummer += dag2;
            }
            else
            {
                nummer += dag;
            }

            string getal = random.Next(1, 999).ToString();
            if (int.Parse(getal) < 100)
            {
                if (int.Parse(getal) < 10)
                {
                    string getal2 = getal.Insert(0, "00");
                    nummer += getal2;
                }
                else
                {
                    string getal3 = getal.Insert(0, "0");
                    nummer += getal3;
                }
            }
            else
            {
                nummer += getal;
            }

            if (voor2000)
            {
                nummer2 = nummer.Insert(0, "2");
                controlegetal = (97 - (int.Parse(nummer2) % 97)).ToString();
            }
            else
            {
                controlegetal = (97 - (int.Parse(nummer) % 97)).ToString();
            }

            if (int.Parse(controlegetal) < 10)
            {
                string controlegetal2 = controlegetal.Insert(0, "0");
                nummer += controlegetal2;
            }
            else
            {
                nummer += controlegetal;
            }

            return nummer;
        }
    }
}
