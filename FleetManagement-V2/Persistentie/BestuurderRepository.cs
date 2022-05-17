using Domein.Enums;
using Domein.Interfaces;
using Domein.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistentie
{
    public class BestuurderRepository : IBestuurderRepository
    {
        private const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog = FleetmanagementDB; Integrated Security = True; TrustServerCertificate=True";

        //TODO: implement interface
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

            var builder = new MySqlConnectionStringBuilder
            {
                Server = "projectwerk2.mysql.database.azure.com",
                UserID = "student",
                Password = "Hogent2022!",
                Database = "mydb",
                //SslMode = MySqlSslMode.VerifyCA
                //SslCa = "/Users/pavel/Downloads/BaltimoreCyberTrustRoot.crt.pem",
            };

            try
            {
                Console.WriteLine("STAP 1");
                using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("STAP 2");
                    Console.WriteLine("State: {0}", connection.State);
                    Console.WriteLine("ConnectionTimeout: {0}", connection.ConnectionTimeout);
                    connection.Open();
                    Console.WriteLine("STAP 3");
                    Console.WriteLine("State: {0}", connection.State);

                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        Console.WriteLine("STAP 4");
                        command.CommandText = "SELECT * FROM bestuurder;";

                        using (MySqlDataReader dataReader = command.ExecuteReader())
                        {
                            Console.WriteLine("STAP 5");
                            if (dataReader.HasRows)
                            {
                                Console.WriteLine("STAP 6");
                                while (dataReader.Read())
                                {
                                    Console.WriteLine("STAP 7");
                                    string naam = (string)dataReader["naam"];
                                    Console.WriteLine("STAP 8");
                                    string voornaam = (string)dataReader["voornaam"];
                                    Console.WriteLine("STAP 9"); 
                                    DateTime geboortedatum = DateTime.ParseExact((string)dataReader["geboortedatum"], "dd-MM-yyyy", null);
                                    Console.WriteLine("STAP 10");
                                    string rijksregisternummer = (string)dataReader["rijksregisternummer"];
                                    Console.WriteLine("STAP 11");
                                    Rijbewijs rijbewijs = (Rijbewijs)dataReader["rijbewijs"];
                                    Console.WriteLine("STAP 12");

                                    bestuurders.Add(new Bestuurder(naam, voornaam, geboortedatum, rijksregisternummer, rijbewijs, null, null, null));
                                    Console.WriteLine("STAP 13");
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("GeefBestuurders error");
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
