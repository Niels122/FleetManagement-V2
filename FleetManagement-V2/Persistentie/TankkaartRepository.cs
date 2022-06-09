using Domein.Interfaces;
using Domein.Objects;
using Domein.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Domein.Enums;

namespace Persistentie
{
    public class TankkaartRepository : ITankkaartRepository
    {
        private const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog = FleetmanagementDB; Integrated Security = True; TrustServerCertificate=True";

        public List<Tankkaart> GeefTankkaarten()
        {
            List<Tankkaart> tankkaarten = new List<Tankkaart>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string readSql = "SELECT tankkaartnummer, geldigheidsdatum, brandstof, pincode, " +
                        "isGeblokkeerd FROM tankkaart WHERE isDeleted = 0";
                    SqlCommand cmd = new(readSql, conn);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                string tankkaartnummer = (string)dataReader["tankkaartnummer"];
                                DateTime geldigheidsdatum = (DateTime)dataReader["geldigheidsdatum"];
                                bool isGeblokkeerd = (bool)dataReader["isGeblokkeerd"];
                                string brandstoftype = (string)dataReader["brandstof"];
                                int? pincode = (int?)dataReader["pincode"];

                                #region setBrandstoftype
                                Brandstoftype brandstof;
                                if (brandstoftype == "elektrisch")
                                {
                                    brandstof = Brandstoftype.elektrisch;
                                }
                                else if (brandstoftype == "diesel")
                                {
                                    brandstof = Brandstoftype.diesel;
                                }
                                else if (brandstoftype == "hybridebenzine")
                                {
                                    brandstof = Brandstoftype.hybrideBenzine;
                                }
                                else if (brandstoftype == "hybridediesel")
                                {
                                    brandstof = Brandstoftype.hybrideDiesel;
                                }
                                else
                                {
                                    brandstof = Brandstoftype.benzine;
                                }
                                #endregion

                                tankkaarten.Add(new Tankkaart(tankkaartnummer, geldigheidsdatum, isGeblokkeerd, pincode, brandstof, null));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new TankkaartException($"Er ging iets mis in de persitentielaag bij het ophalen van de tankkaarten, {ex.Message}");
            }

            return tankkaarten;
        }

        public void CreateTankkaart(Tankkaart tankkaart)
        {
            throw new NotImplementedException();
        }

        public void DeleteTankkaart(Tankkaart tankkaart)
        {
            throw new NotImplementedException();
        }

        public List<int> GeefTankkaartnummers()
        {
            List<int> tanknummers = new List<int>();

            return tanknummers;
        }

        public Tankkaart ReadTankkaart(Tankkaart tankkaart)
        {
            throw new NotImplementedException();
        }

        public void UpdateTankkaart(Tankkaart tankkaart)
        {
            throw new NotImplementedException();
        }
    }
}
