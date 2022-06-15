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

        public Adres GeefLaatsteAdres()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string readSql = "SELECT id, straat, huisnummer, postcode, stad FROM adres ORDER BY id DESC";
                    SqlCommand cmd = new(readSql, conn);

                    using(SqlDataReader dataReader = cmd.ExecuteReader())
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

                                return new Adres(adresId, straat, huisnummer, postcode, stad);
                            }
                        }
                        else
                        {
                            throw new AdresException("Adres tabel in databank is leeg, laatste adres kan dus niet opgehaald worden.");
                        }
                    }

                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw new AdresException($"Er ging iets mis bij het ophalen van het laatste adres in de persitentielaag, {ex.Message}");
            }

            return null;
        }

        public void CreateAdres(string straatnaam, string huisnummer, int postcode, string stad)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string insertSql = "INSERT INTO adres (straat, huisnummer, postcode, stad)" +
                                        "VALUES (@Straat, @Huisnummer, @Postcode, @Stad)";
                    SqlCommand insertCommand = new(insertSql, conn);

                    insertCommand.Parameters.AddWithValue("@Straat", straatnaam);
                    insertCommand.Parameters.AddWithValue("@Huisnummer", huisnummer);
                    insertCommand.Parameters.AddWithValue("@Postcode", postcode);
                    insertCommand.Parameters.AddWithValue("@Stad", stad);

                    insertCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new AdresException($"Er ging iets mis in de persitentielaag bij het creeren van het adres, { ex.Message }");
            }
        }

        public void UpdateAdres(Adres adres)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string updateSql = "UPDATE adres SET straat = @Straat, huisnummer = @Huisnummer, " +
                        "postcode = @Postcode, stad = @Stad WHERE id = @AdresId";
                    SqlCommand updateCommand = new(updateSql, conn);

                    updateCommand.Parameters.AddWithValue("@AdresId", adres.AdresId);
                    updateCommand.Parameters.AddWithValue("@Straat", adres.Straat);
                    updateCommand.Parameters.AddWithValue("@Huisnummer", adres.Nummer);
                    updateCommand.Parameters.AddWithValue("@Postcode", adres.Postcode);
                    updateCommand.Parameters.AddWithValue("@Stad", adres.Stad);

                    updateCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new BestuurderException($"Er ging iets mis in de persitentielaag bij het updaten van het adres, { ex.Message}");
            }
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
