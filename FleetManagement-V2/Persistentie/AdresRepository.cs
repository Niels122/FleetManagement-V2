using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domein.Objects;
using Domein.Interfaces;
using Domein.Exceptions;
using Domein.Enums;
using Microsoft.Data.SqlClient;

namespace Persistentie
{
    public class AdresRepository : IAdresRepository
    {
        private const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog = FleetmanagementDB; Integrated Security = True; TrustServerCertificate=True";

        public void CreateAdres(string straatnaam, string huisnummer, int postcode, string stad)
        {
            throw new NotImplementedException();
        }

        public void DeleteAdres(Adres adres)
        {
            throw new NotImplementedException();
        }

        public List<Adres> GeefAdressen()
        {
            List<Adres> adressen = new List<Adres>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string readSql = "SELECT id, straat, huisnummer, postcode, stad FROM adres";
                    SqlCommand cmd = new(readSql, conn);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                int adresId = (int)dataReader["id"];
                                string straat = (string)dataReader["straat"];
                                string huisnummer = (string)dataReader["huisnummer"];
                                int postcode = (int)dataReader["postcode"];
                                string stad = (string)dataReader["stad"];

                                adressen.Add(new Adres(adresId, straat, huisnummer, postcode, stad, null));
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new AdresException($"Er ging iets mis bij het ophalen GeefAdressen in de persistentielaag, {ex.Message}");
            }

            return adressen;
        }

        public void CreateAdres(Adres adres)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdres(Adres adres)
        {
            throw new NotImplementedException();
        }

        public void DeleteAdres(Adres adres)
        {
            throw new NotImplementedException();
        }

        public void RetrieveAdres(Adres adres)
        {
            throw new NotImplementedException();
        }
    }
}
