using Domein.Enums;
using Domein.Exceptions;
using Domein.Interfaces;
using Domein.Objects;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistentie
{
    public class BestuurderRepository : IBestuurderRepository
    {
        private const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog = FleetmanagementDB; Integrated Security = True; TrustServerCertificate=True";

        public void CreateBestuurder(Bestuurder bestuurder) //https://cheatsheetseries.owasp.org/cheatsheets/SQL_Injection_Prevention_Cheat_Sheet.html 
        {                                                  
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string insertSql = "INSERT INTO bestuurder (id, naam, voornaam, geboortedatum, rijksregisternummer, rijbewijstype, chassisnummerVoertuig, tankkaartnummer, adresId)" +
                        "VALUES (@BestuurderId, @Naam, @Voornaam, @Geboortedatum, @Rijksregisternummer, @Rijbewijs, @ChassisnummerVoertuig, @TankkaartNummer, @AdresId)";
                    SqlCommand insertCommand = new(insertSql, conn);

                    insertCommand.Parameters.AddWithValue("BestuurderId", bestuurder.BestuurderId);
                    insertCommand.Parameters.AddWithValue("@Naam", bestuurder.Naam);
                    insertCommand.Parameters.AddWithValue("@Voornaam", bestuurder.Voornaam);
                    insertCommand.Parameters.AddWithValue("@Geboortedatum", bestuurder.Geboortedatum);
                    insertCommand.Parameters.AddWithValue("@Rijksregisternummer", bestuurder.Rijksregisternummer);
                    insertCommand.Parameters.AddWithValue("@Rijbewijs", bestuurder.Rijbewijs);
                    if (bestuurder.ChassisnummerVoertuig == null)
                    {
                        insertCommand.Parameters.AddWithValue("@ChassisnummerVoertuig", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@ChassisnummerVoertuig", bestuurder.ChassisnummerVoertuig);
                    }
                    if (bestuurder.TankkaartNummer == null)
                    {
                        insertCommand.Parameters.AddWithValue("@TankkaartNummer", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@TankkaartNummer", bestuurder.TankkaartNummer);
                    }

                    if (bestuurder.AdresId == null)
                    {
                        insertCommand.Parameters.AddWithValue("@AdresId", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@AdresId", bestuurder.AdresId);
                    }

                    insertCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new BestuurderException($"Er ging iets mis in de persitentielaag bij het creeren van de bestuurder, { ex.Message }");
            }
        }

        public void DeleteBestuurder(Bestuurder bestuurder)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string deleteSql = $"UPDATE bestuurder SET isDeleted= 1 " +
                        "WHERE id = @BestuurderId AND rijksregisternummer = @Rijksregisternummer";
                    SqlCommand deleteCommand = new(deleteSql, conn);

                    deleteCommand.Parameters.AddWithValue("@BestuurderId", bestuurder.BestuurderId);
                    deleteCommand.Parameters.AddWithValue("@Rijksregisternummer", bestuurder.Rijksregisternummer);

                    deleteCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw new BestuurderException($"Er ging iets in de persitentielaag mis bij het soft-deleten van de bestuurder met ID: {bestuurder.BestuurderId}, {ex.Message}");
            }
        }

        public void RetrieveBestuurder(Bestuurder bestuurder)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string deleteSql = $"UPDATE bestuurder SET isDeleted = 0 " +
                        "WHERE id = @BestuurderId AND rijksregisternummer = @Rijksregisternummer";
                    SqlCommand deleteCommand = new(deleteSql, conn);

                    deleteCommand.Parameters.AddWithValue("@BestuurderId", bestuurder.BestuurderId);
                    deleteCommand.Parameters.AddWithValue("@Rijksregisternummer", bestuurder.Rijksregisternummer);

                    deleteCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new BestuurderException($"Er ging iets mis in de persitentielaag bij het retrieven van de bestuurder met ID: {bestuurder.BestuurderId}, {ex.Message}");
            }
        }

        public List<Bestuurder> GeefBestuurders(string bestuurId = null)
        {
            List<Bestuurder> bestuurders = new List<Bestuurder>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string readSql = "SELECT id, naam, voornaam, geboortedatum, rijksregisternummer, rijbewijstype, " +
                        "chassisnummerVoertuig, tankkaartnummer, adresId FROM bestuurder WHERE isDeleted = 0";
                    if (bestuurId != null) readSql += " AND id = bestuurId";
                    SqlCommand cmd = new(readSql, conn);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                string bestuurderId = (string)dataReader["id"];
                                string naam = (string)dataReader["naam"];
                                string voornaam = (string)dataReader["voornaam"];
                                DateTime geboortedatum = (DateTime)dataReader["geboortedatum"]; //checken of het het het juiste date format is. DateTime.ParseExact((string)dataReader["geboortedatum"], "yyyy-MM-dd", null);
                                string rijksregisternummer = (string)dataReader["rijksregisternummer"];
                                string rijbewijs = (string)dataReader["rijbewijstype"];
                                string chassisnummerVoertuig = Convert.IsDBNull(dataReader["chassisnummerVoertuig"]) ? null : (string)dataReader["chassisnummerVoertuig"];
                                string tankkaartnummer = Convert.IsDBNull(dataReader["tankkaartnummer"]) ? null : (string)dataReader["tankkaartnummer"];
                                int? adresId = Convert.IsDBNull(dataReader["adresId"]) ? null : (int?)dataReader["adresId"];

                                #region setRijbewijs
                                //van string naar enum.
                                Rijbewijs _rijbewijs;
                                if (rijbewijs.ToUpper() == "A") //moet else if zijn om dit juist te doen werken, later veranderen naar switch case
                                {
                                    _rijbewijs = Rijbewijs.A;
                                } else
                                if (rijbewijs.ToUpper() == "B")
                                {
                                    _rijbewijs = Rijbewijs.B;
                                } else
                                if (rijbewijs.ToUpper() == "C")
                                {
                                    _rijbewijs = Rijbewijs.C;
                                } else
                                if (rijbewijs.ToUpper() == "D")
                                {
                                    _rijbewijs = Rijbewijs.D;
                                }                          
                                else
                                {
                                    _rijbewijs = Rijbewijs.B;
                                }
                                #endregion
                                bestuurders.Add(new Bestuurder(bestuurderId, naam, voornaam, geboortedatum, rijksregisternummer, _rijbewijs, chassisnummerVoertuig, tankkaartnummer, adresId));
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw new BestuurderException($"Er ging iets mis in de persitentielaag bij het ophalen van de bestuurders, {ex.Message}");
            }

            return bestuurders;
        }

        public void UpdateBestuurder(Bestuurder bestuurder)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string updateSql = "UPDATE bestuurder SET naam = @Naam, voornaam = @Voornaam, geboortedatum = @Geboortedatum, " +
                        "rijksregisternummer = @Rijksregisternummer, rijbewijstype = @Rijbewijs, chassisnummerVoertuig = @ChassisnummerVoertuig, " +
                        "tankkaartnummer = @TankkaartNummer, adresId = AdresId  WHERE id = @BestuurderId";
                    SqlCommand updateCommand = new(updateSql, conn);

                    updateCommand.Parameters.AddWithValue("BestuurderId", bestuurder.BestuurderId);
                    updateCommand.Parameters.AddWithValue("@Naam", bestuurder.Naam);
                    updateCommand.Parameters.AddWithValue("@Voornaam", bestuurder.Voornaam);
                    updateCommand.Parameters.AddWithValue("@Geboortedatum", bestuurder.Geboortedatum);
                    updateCommand.Parameters.AddWithValue("@Rijksregisternummer", bestuurder.Rijksregisternummer);
                    updateCommand.Parameters.AddWithValue("@Rijbewijs", bestuurder.Rijbewijs.ToString());
                    if (bestuurder.ChassisnummerVoertuig == null)
                    {
                        updateCommand.Parameters.AddWithValue("@ChassisnummerVoertuig", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@ChassisnummerVoertuig", bestuurder.ChassisnummerVoertuig);
                    }
                    if (bestuurder.TankkaartNummer == null)
                    {
                        updateCommand.Parameters.AddWithValue("@TankkaartNummer", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@TankkaartNummer", bestuurder.TankkaartNummer);
                    }

                    if (bestuurder.AdresId == null)
                    {
                        updateCommand.Parameters.AddWithValue("@AdresId", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@AdresId", bestuurder.AdresId);
                    }

                    updateCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw new BestuurderException($"Er ging iets mis in de persitentielaag bij het updaten van de bestuurder met ID: {bestuurder.BestuurderId}, { ex.Message}");
            }
        }
    }
}
