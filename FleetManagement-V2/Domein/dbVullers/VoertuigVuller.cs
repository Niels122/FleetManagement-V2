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
    public class VoertuigVuller
    {
        VoertuigController _vc;

        public VoertuigVuller(VoertuigController vc)
        {
            _vc = vc;
        }

        public void VulVoertuigTabel(int aantal)
        {
            string merk;
            string model;
            string[] merkModel = new string[2];

            for (int i = 0; i < aantal; i++)
            {
                try
                {
                    merkModel = randomMerkModelArray();
                    merk = merkModel[0];
                    model = merkModel[1];

                    _vc.CreateVoertuig(new Voertuig(merk, model, randomChassisnummer(), randomNummerplaat(), randomBrandstoftype(),
                                                        randomWagentype(), randomKleur(), randomAantalDeuren()));
                }
                catch
                {
                    i--;
                }
            }
        }
        //public Voertuig(string merk, string model, string chassisnummer, string nummerplaat, Brandstoftype brandstoftype,
        // Wagentype wagentype, string kleur = null, int? aantalDeuren = null, string bestuurderId = null)

        Random random = new Random();

        List<string> merkLijst = new List<string> { "Mercedes", "Audi", "BMW", "Nissan", "Volkswagen", "Toyota", "Porsche" };
        List<string> modelLijst = new List<string> { "CLA Coupé", "AMG-GTR", "Q8", "A7", "i8", "X5", "GT-R", "Qashqai",
                                                     "Golf", "Passat", "Fortuner", "Yaris", "911", "Carrera" };
        public string[] randomMerkModelArray()
        {
            string[] merkModel = new string[2];
            merkModel[0] = merkLijst[random.Next(merkLijst.Count())];


            switch (merkModel[0])
            {
                case "Mercedes":
                    merkModel[1] = modelLijst[random.Next(0, 2)];
                    break;
                case "Audi":
                    merkModel[1] = modelLijst[random.Next(2, 4)];
                    break;
                case "BMW":
                    merkModel[1] = modelLijst[random.Next(4, 6)];
                    break;
                case "Nissan":
                    merkModel[1] = modelLijst[random.Next(6, 8)];
                    break;
                case "Volkswagen":
                    merkModel[1] = modelLijst[random.Next(8, 10)];
                    break;
                case "Toyota":
                    merkModel[1] = modelLijst[random.Next(10, 12)];
                    break;
                case "Porsche":
                    merkModel[1] = modelLijst[random.Next(12, modelLijst.Count())];
                    break;
            }

            return merkModel;
        }

        string karakters = "ABCDEFGHJKLMNPRSTUVWXYZ0123456789";
        public string randomChassisnummer()
        {
            string nummer = "";

            for(int i = 0; i < 17; i++)
            {
                nummer += karakters[random.Next(karakters.Length)];
            }

            return nummer;
        }

        string alfabet = "abcdefghijklmnopqrstuvwxyz";
        public string randomNummerplaat()
        {
            string plaat = "";

            plaat += random.Next(1, 3).ToString();
            plaat += alfabet[random.Next(alfabet.Length)];
            plaat += alfabet[random.Next(alfabet.Length)];
            plaat += alfabet[random.Next(alfabet.Length)];
            plaat += random.Next(10).ToString();
            plaat += random.Next(10).ToString();
            plaat += random.Next(10).ToString();

            return plaat;
        }

        Array brandstoftypes = Enum.GetValues(typeof(Brandstoftype));
        public Brandstoftype randomBrandstoftype()
        {
            return (Brandstoftype)brandstoftypes.GetValue(random.Next(brandstoftypes.Length));
        }

        Array wagentypes = Enum.GetValues(typeof(Wagentype));
        public Wagentype randomWagentype()
        {
            return (Wagentype)wagentypes.GetValue(random.Next(wagentypes.Length));
        }

        List<string> kleuren = new List<string> { "Zwart", "Wit", "Groen", "Blauw", "Geel" };
        public string? randomKleur()
        {
            if (random.Next(17) < 1)
            {
                return null;
            }

            return kleuren[random.Next(kleuren.Count())];
        }

        public int? randomAantalDeuren()
        {
            if (random.Next(20) < 1)
            {
                return null;
            }

            if (random.Next(5) < 1)
            {
                return 5;
            }
            else
            {
                return 3;
            }
        }
    }
}
