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
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string insertSql = $"INSERT INTO bestuurder (naam, voornaam, geboortedatum, rijksregisternummer, rijbewijstype, voertuigId, tankkaartId, adresId" +
                        $"VALUES ('{bestuurder.Naam}', '{bestuurder.Voornaam}', '{bestuurder.Geboortedatum}', '{bestuurder.Rijksregisternummer}', '{bestuurder.Rijbewijs}', '{bestuurder.VoertuigId}', '{bestuurder.TankkaartId}', '{bestuurder.AdresId}');";
                    SqlCommand insertCommand = new(insertSql, conn);
                    insertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBestuurder(Bestuurder bestuurder)
        {
            throw new NotImplementedException();
        }

        public List<Bestuurder> GeefBestuurders()
        {
            List<Bestuurder> bestuurders = new List<Bestuurder>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new("SELECT id, naam, voornaam, geboortedatum, rijksregisternummer, rijbewijstype, voertuigId, tankkaartId, adresId FROM bestuurder;", connection);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                int driverId = (int)dataReader["id"];
                                string naam = (string)dataReader["naam"];
                                string voornaam = (string)dataReader["voornaam"];
                                DateTime geboortedatum = (DateTime)dataReader["geboortedatum"]; //checken of het het het juiste date format is. DateTime.ParseExact((string)dataReader["geboortedatum"], "yyyy-MM-dd", null);
                                string rijksregisternummer = (string)dataReader["rijksregisternummer"];
                                string rijbewijs = (string)dataReader["rijbewijstype"];
                                int voertuigId = (int)dataReader["voertuigId"];
                                int tankkaartId = (int)dataReader["tankkaartId"];
                                int adresId = (int)(dataReader["adresId"]);

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
                                bestuurders.Add(new Bestuurder(driverId, naam, voornaam, geboortedatum, rijksregisternummer, _rijbewijs, adresId, voertuigId, tankkaartId));
                            }
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                throw new BestuurderException($"Er ging iets mis bij het ophalen van GeefBestuurders in de persistentielaag, {ex.Message}" );
            }

            return bestuurders;
        }

        public List<string> GeefRijksregisternummers()
        {
            List<string> rijksnummers = new List<string>();

            return rijksnummers;
        }

        public Bestuurder ReadBestuurder()
        {
            throw new NotImplementedException();
        }

        public void UpdateBestuurder(Bestuurder bestuurder)
        {
            throw new NotImplementedException();
        }
    }
}
