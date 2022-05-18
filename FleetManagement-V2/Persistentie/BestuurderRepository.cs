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

        public void CreateBestuurder(Bestuurder bestuurder)
        {
            throw new NotImplementedException();
        }

        public void DeleteBestuurder(Bestuurder bestuurder)
        {
            throw new NotImplementedException();
        }

        public List<Bestuurder> GeefBestuurders()
        {
            List<Bestuurder> bestuurders = new();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new("SELECT * FROM bestuurder;", connection);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                string naam = (string)dataReader["naam"];
                                string voornaam = (string)dataReader["voornaam"];
                                DateTime geboortedatum = (DateTime)dataReader["geboortedatum"]; //checken of het het het juiste date format is. DateTime.ParseExact((string)dataReader["geboortedatum"], "yyyy-MM-dd", null);
                                string rijksregisternummer = (string)dataReader["rijksregisternummer"]; 
                                //Rijbewijs rijbewijs = (Rijbewijs)dataReader["rijbewijs"];

                                bestuurders.Add(new Bestuurder(naam, voornaam, geboortedatum, rijksregisternummer, Rijbewijs.G, null, null, null));
                            }
                        }
                    }

                }
            }
            catch
            {
                throw new BestuurderException("Er ging iets mis bij het ophalen van GeefBestuurders in de persistentielaag.");
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
