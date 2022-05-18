using Domein.Enums;
using Domein.Exceptions;
using Domein.Interfaces;
using Domein.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient; //in Gevorderd was dit Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistentie
{
    public class VoertuigRepository : IVoertuigRepository
    {
        private const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog = FleetmanagementDB; Integrated Security = True; TrustServerCertificate=True";
        //TODO: implement interface
        public void CreateVoertuig(Voertuig voertuig)
        {
            throw new NotImplementedException();
        }

        public void DeleteVoertuig(Voertuig voertuig)
        {
            throw new NotImplementedException();
        }

        public List<int> GeefChassisnummers()
        {
            List<int> chassisnummers = new List<int>();

            return chassisnummers;
        }

        public List<string> GeefNummerplaten()
        {
            List<string> nummerplaten = new List<string>();

            return nummerplaten;
        }

        public List<Voertuig> GeefVoertuigen()
        {
            List<Voertuig> voertuigen = new();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new("SELECT id, nummerplaat, chassisnummer, merk, model, typevoertuig, brandstof, kleur, aantalDeuren FROM dbo.voertuig", conn);
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int id = (int)reader["id"];
                                    string nummerplaat = (string)reader["nummerplaat"];
                                    string chassisnummer = (string)reader["chassisnummer"];
                                    string merk = (string)reader["merk"];
                                    string model = (string)reader["model"];
                                    string wagentype = (string)reader["typevoertuig"];
                                    string brandstof = (string)reader["brandstof"];
                                    string kleur = (string)reader["kleur"];
                                    int aantaldeuren = (int)reader["aantaldeuren"];
                                    Bestuurder bestuurder = null;

                                    #region setBrandstoftype
                                    //tabel in database met brandstoftype en id + foreign key of switch gebruiken
                                    //dit moet gebeuren omdat brandstoftype een enum is. Misschien is hier een mooiere oplossing voor maar dit is het enige wat ik zelf kon bedenken.
                                    Brandstoftype brandstoftype;
                                    if (brandstof == "elektrisch")
                                    {
                                        brandstoftype = Brandstoftype.elektrisch;
                                    }
                                    else if (brandstof == "diesel")
                                    {
                                        brandstoftype = Brandstoftype.diesel;
                                    }
                                    else if (brandstof == "hybridebenzine")
                                    {
                                        brandstoftype = Brandstoftype.hybrideBenzine;
                                    }
                                    else if (brandstof == "hybridediesel")
                                    {
                                        brandstoftype = Brandstoftype.hybrideDiesel;
                                    }                               
                                    else
                                    {
                                        brandstoftype = Brandstoftype.benzine;
                                    }
                                    #endregion

                                    #region setWagentype
                                    //van string naar enum.
                                    Wagentype _wagentype;
                                    if (wagentype == "personenauto")
                                    {
                                        _wagentype = Wagentype.personenauto;
                                    }
                                    else
                                    {
                                        _wagentype = Wagentype.bestelwagen;
                                    }
                                    #endregion

                                    voertuigen.Add(new Voertuig(id, merk, model, chassisnummer, nummerplaat, brandstoftype, _wagentype, kleur, aantaldeuren, bestuurder));
                                }
                            }
                        }
                    }
                    finally
                    {
                        conn.Close(); //wordt dit niet automatisch gedaan?
                    }
                }
            }
            catch (Exception ex)
            {
                throw new VoertuigException(ex.Message); //snap ik niet
            }

            return voertuigen;
        }

        public Voertuig ReadVoertuig()
        {
            throw new NotImplementedException();
        }

        public void UpdateVoertuig(Voertuig oudVoertuigInfo, Voertuig nieuwVoertuigInfo)
        {
            throw new NotImplementedException();
        }
    }
}
