using Domein.Interfaces;
using Domein.Objects;
using Domein.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

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

                    SqlCommand cmd = new("SELECT * FROM tankkaart", conn);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                int tankkaartId = (int)dataReader["id"];
                                string tankkaartnummer = (string)dataReader["tankkaartnummer"];
                                DateTime geldigheidsdatum = (DateTime)dataReader["geldigheidsdatum"];
                                string brandstof = (string)dataReader["brandstof"];
                                int? pincode = (int?)dataReader["pincode"];

                                tankkaarten.Add(new Tankkaart(tankkaartId, tankkaartnummer, geldigheidsdatum, pincode, null, null));
                            }
                        }
                    }
                }
            }
            catch
            {
                throw new TankkaartException("Er ging iets mis bij het ophalen GeefAdressen in de persistentielaag.");
            }

            return tankkaarten;
        }

        public void CreateTankkaart(Tankkaart tankkaart)
        {
            throw new NotImplementedException();
        }

        public void DeleteTankkaart(int kaartnummer)
        {
            throw new NotImplementedException();
        }

        public List<int> GeefTankkaartnummers()
        {
            List<int> tanknummers = new List<int>();

            return tanknummers;
        }

        public Tankkaart ReadTankkaart(int kaartnummer)
        {
            throw new NotImplementedException();
        }

        public void UpdateTankkaart(Tankkaart tankkaart)
        {
            throw new NotImplementedException();
        }
    }
}
