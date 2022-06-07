﻿using Domein.Enums;
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

        public void CreateBestuurder(Bestuurder bestuurder) //checks gebeuren in domein
        {                                                   //https://cheatsheetseries.owasp.org/cheatsheets/SQL_Injection_Prevention_Cheat_Sheet.html
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertSql = "INSERT INTO bestuurder (id, naam, voornaam, geboortedatum, rijksregisternummer, rijbewijstype, voertuigId, tankkaartId, adresId)" +
                        "VALUES (@BestuurderId, @Naam, @Voornaam, @Geboortedatum, @Rijksregisternummer, @Rijbewijs, @VoertuigId, @TankkaartId, @AdresId)";
                    SqlCommand insertCommand = new(insertSql, connection);

                    insertCommand.Parameters.AddWithValue("BestuurderId", bestuurder.BestuurderId);
                    insertCommand.Parameters.AddWithValue("@Naam", bestuurder.Naam);
                    insertCommand.Parameters.AddWithValue("@Voornaam", bestuurder.Voornaam);
                    insertCommand.Parameters.AddWithValue("@Geboortedatum", bestuurder.Geboortedatum);
                    insertCommand.Parameters.AddWithValue("@Rijksregisternummer", bestuurder.Rijksregisternummer);
                    insertCommand.Parameters.AddWithValue("@Rijbewijs", bestuurder.Rijbewijs);
                    if (bestuurder.VoertuigId == null)
                    {
                        insertCommand.Parameters.AddWithValue("@VoertuigId", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@VoertuigId", bestuurder.VoertuigId);
                    }
                    if (bestuurder.TankkaartId == null)
                    {
                        insertCommand.Parameters.AddWithValue("@TankkaartId", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@TankkaartId", bestuurder.TankkaartId);
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

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new BestuurderException($"Er ging iets mis bij het creeren van een bestuurder in de persistentielaag, { ex.Message }");
            }
        }

        public void DeleteBestuurder(Bestuurder bestuurder)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteSql = $"UPDATE bestuurder SET is_deleted = 1 " +
                        "WHERE id = @BestuurderId AND rijksregisternummer = @Rijksregisternummer";
                    SqlCommand deleteCommand = new(deleteSql, connection);

                    deleteCommand.Parameters.AddWithValue("BestuurderId", bestuurder.BestuurderId);
                    deleteCommand.Parameters.AddWithValue("@Rijksregisternummer", bestuurder.Rijksregisternummer);

                    deleteCommand.ExecuteNonQuery(); 

                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                throw new BestuurderException($"Er ging iets mis bij het soft-deleten van een bestuurder, {ex.Message}");
            }
        }
        public void RetrieveBestuurder(Bestuurder bestuurder)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteSql = $"UPDATE bestuurder SET is_deleted = 0 " +
                        "WHERE id = @BestuurderId AND rijksregisternummer = @Rijksregisternummer";
                    SqlCommand deleteCommand = new(deleteSql, connection);

                    deleteCommand.Parameters.AddWithValue("BestuurderId", bestuurder.BestuurderId);
                    deleteCommand.Parameters.AddWithValue("@Rijksregisternummer", bestuurder.Rijksregisternummer);

                    deleteCommand.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new BestuurderException($"Er ging iets mis bij het soft-deleten van een bestuurder, {ex.Message}");
            }
        }

        public List<Bestuurder> GeefBestuurders()
        {
            List<Bestuurder> bestuurders = new List<Bestuurder>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new($"SELECT id, naam, voornaam, geboortedatum, rijksregisternummer, rijbewijstype, voertuigId, tankkaartId, adresId FROM bestuurder WHERE is_deleted = 0;", connection);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                int bestuurderId = (int)dataReader["id"];
                                string naam = (string)dataReader["naam"];
                                string voornaam = (string)dataReader["voornaam"];
                                DateTime geboortedatum = (DateTime)dataReader["geboortedatum"]; //checken of het het het juiste date format is. DateTime.ParseExact((string)dataReader["geboortedatum"], "yyyy-MM-dd", null);
                                string rijksregisternummer = (string)dataReader["rijksregisternummer"];
                                string rijbewijs = (string)dataReader["rijbewijstype"];
                                int? voertuigId = Convert.IsDBNull(dataReader["voertuigId"]) ? null : (int?)dataReader["voertuigId"];
                                int? tankkaartId = Convert.IsDBNull(dataReader["tankkaartId"]) ? null : (int?)dataReader["tankkaartId"];
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
                                bestuurders.Add(new Bestuurder(bestuurderId, naam, voornaam, geboortedatum, rijksregisternummer, _rijbewijs, adresId, voertuigId, tankkaartId));
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                throw new BestuurderException($"Er ging iets mis bij het ophalen van de bestuurders in de persistentielaag, {ex.Message}" );
            }

            return bestuurders;
        }

        public Bestuurder ReadBestuurder()
        {
            throw new NotImplementedException();
        }

        public void UpdateBestuurder(Bestuurder bestuurder)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateSql = "UPDATE bestuurder SET naam = @Naam, voornaam = @Voornaam, geboortedatum = @Geboortedatum, " +
                        "rijksregisternummer = @Rijksregisternummer, rijbewijstype = @Rijbewijs, voertuigId = @VoertuigId, " +
                        "tankkaartId = @TankkaartId, adresId = AdresId  WHERE id = @BestuurderId";
                    SqlCommand updateCommand = new(updateSql, connection);

                    updateCommand.Parameters.AddWithValue("BestuurderId", bestuurder.BestuurderId);
                    updateCommand.Parameters.AddWithValue("@Naam", bestuurder.Naam);
                    updateCommand.Parameters.AddWithValue("@Voornaam", bestuurder.Voornaam);
                    updateCommand.Parameters.AddWithValue("@Geboortedatum", bestuurder.Geboortedatum);
                    updateCommand.Parameters.AddWithValue("@Rijksregisternummer", bestuurder.Rijksregisternummer);
                    updateCommand.Parameters.AddWithValue("@Rijbewijs", bestuurder.Rijbewijs.ToString());
                    if (bestuurder.VoertuigId == null)
                    {
                        updateCommand.Parameters.AddWithValue("@VoertuigId", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@VoertuigId", bestuurder.VoertuigId);
                    }
                    if (bestuurder.TankkaartId == null)
                    {
                        updateCommand.Parameters.AddWithValue("@TankkaartId", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@TankkaartId", bestuurder.TankkaartId);
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

                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                throw new BestuurderException($"Er ging iets mis bij het updaten van een bestuurder in de persistentielaag, { ex.Message}");
            }
        }

        //public List<string> GeefRijksregisternummers()
        //{
        //    List<string> rijksnummers = new List<string>();

        //    return rijksnummers;
        //}
    }
}
