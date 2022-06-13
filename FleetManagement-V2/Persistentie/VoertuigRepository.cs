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

        public List<Voertuig> GeefVoertuigen()
        {
            List<Voertuig> voertuigen = new();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string readSql = "SELECT chassisnummer, nummerplaat, merk, model, typevoertuig, brandstof, " +
                        "kleur, aantalDeuren FROM voertuig WHERE isDeleted = 0";
                    SqlCommand cmd = new(readSql, conn);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                string chassisnummer = (string)dataReader["chassisnummer"];
                                string nummerplaat = (string)dataReader["nummerplaat"];
                                string merk = (string)dataReader["merk"];
                                string model = (string)dataReader["model"];
                                Wagentype wagentype = (Wagentype)Enum.Parse(typeof(Wagentype),(string)dataReader["typevoertuig"]);
                                Brandstoftype brandstoftype = (Brandstoftype)Enum.Parse(typeof(Brandstoftype), (string)dataReader["brandstof"]);
                                string kleur = Convert.IsDBNull(dataReader["kleur"]) ? null : (string)dataReader["kleur"];
                                int? aantaldeuren = Convert.IsDBNull(dataReader["aantalDeuren"]) ? null : (int?)dataReader["aantalDeuren"];

                                voertuigen.Add(new Voertuig(merk, model, chassisnummer, nummerplaat, brandstoftype, wagentype, kleur, aantaldeuren, null));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new VoertuigException($"Er ging iets mis in de persitentielaag bij het ophalen van de voertuigen, {ex.Message}"); 
            }

            return voertuigen;
        }

        public void CreateVoertuig(Voertuig voertuig)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string insertSql = "INSERT INTO voertuig (chassisnummer, nummerplaat, merk, model, typevoertuig, brandstof, kleur, aantalDeuren)" +
                        "VALUES (@Chassisnummer, @Nummerplaat, @Merk, @Model, @Wagentype, @Brandstoftype, @Kleur, @AantalDeuren)";
                    SqlCommand insertCommand = new(insertSql, conn);

                    insertCommand.Parameters.AddWithValue("@Chassisnummer", voertuig.Chassisnummer);
                    insertCommand.Parameters.AddWithValue("@Nummerplaat", voertuig.Nummerplaat);
                    insertCommand.Parameters.AddWithValue("@Merk", voertuig.Merk);
                    insertCommand.Parameters.AddWithValue("@Model", voertuig.Model);
                    insertCommand.Parameters.AddWithValue("@Wagentype", voertuig.Wagentype.ToString());
                    insertCommand.Parameters.AddWithValue("@Brandstoftype", voertuig.Brandstoftype.ToString());
                    if (voertuig.Kleur == null)
                    {
                        insertCommand.Parameters.AddWithValue("@Kleur", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@Kleur", voertuig.Kleur);
                    }
                    if (voertuig.AantalDeuren == null)
                    {
                        insertCommand.Parameters.AddWithValue("@AantalDeuren", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@AantalDeuren", voertuig.AantalDeuren);
                    }

                    insertCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new VoertuigException($"Er ging iets mis in de persitentielaag bij het creeren van het voertuig, { ex.Message }");
            }
        }

        public void UpdateVoertuig(Voertuig voertuig)

        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string updateSql = "UPDATE voertuig SET chassisnummer = @Chassisnummer, nummerplaat = @Nummerplaat, merk = @Merk, " +
                        "model = @Model, typevoertuig = @Wagentype, brandstof = @Brandstoftype, kleur = @Kleur, aantalDeuren = @AantalDeuren " +
                        "WHERE chassisnummer = @Chassisnummer";
                    SqlCommand updateCommand = new(updateSql, conn);

                    updateCommand.Parameters.AddWithValue("@Chassisnummer", voertuig.Chassisnummer);
                    updateCommand.Parameters.AddWithValue("@Nummerplaat", voertuig.Nummerplaat);
                    updateCommand.Parameters.AddWithValue("@Merk", voertuig.Merk);
                    updateCommand.Parameters.AddWithValue("@Model", voertuig.Model);
                    updateCommand.Parameters.AddWithValue("@Wagentype", voertuig.Wagentype.ToString());
                    updateCommand.Parameters.AddWithValue("@Brandstoftype", voertuig.Brandstoftype.ToString());
                    if (voertuig.Kleur == null)
                    {
                        updateCommand.Parameters.AddWithValue("@Kleur", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@Kleur", voertuig.Kleur);
                    }
                    if (voertuig.AantalDeuren == null)
                    {
                        updateCommand.Parameters.AddWithValue("@AantalDeuren", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@AantalDeuren", voertuig.AantalDeuren);
                    }

                    updateCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new VoertuigException($"Er ging iets mis in de persitentielaag bij het updaten van het voertuig, { ex.Message}");
            }
        }

        public void DeleteVoertuig(Voertuig voertuig)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string deleteSql = "UPDATE voertuig SET isDeleted = 1 WHERE chassisnummer = @Chassisnummer";
                    SqlCommand deleteCommand = new(deleteSql, conn);

                    deleteCommand.Parameters.AddWithValue("@Chassisnummer", voertuig.Chassisnummer);

                    deleteCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new VoertuigException($"Er ging iets in de persitentielaag mis bij het verwijderen van het voertuig" +
                    $" met chassisnummer: {voertuig.Chassisnummer}, {ex.Message}");
            }
        }

        public void RetrieveVoertuig(Voertuig voertuig)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string deleteSql = "UPDATE voertuig SET isDeleted = 0 WHERE chassisnummer = @Chassisnummer";
                    SqlCommand deleteCommand = new(deleteSql, conn);

                    deleteCommand.Parameters.AddWithValue("@Chassisnummer", voertuig.Chassisnummer);

                    deleteCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new VoertuigException($"Er ging iets mis in de persitentielaag bij het retrieven van het voertuig " +
                    $"met chassisnummer: {voertuig.Chassisnummer}, {ex.Message}");
            }
        }
    }
}
