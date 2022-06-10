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

                    string readSql = "SELECT tankkaartnummer, geldigheidsDatum, brandstof, pincode, isGeblokkeerd " +
                                        "FROM tankkaart WHERE isDeleted = 0";
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
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string insertSql = "INSERT INTO tankkaart (tankkaartnummer, geldigheidsDatum, brandstof, pincode, IsGeblokkeerd)" +
                        "VALUES (@Kaartnummer, @Geldigheidsdatum, @Brandstof, @Pincode, @isGeblokkeerd)";
                    SqlCommand insertCommand = new(insertSql, conn);

                    insertCommand.Parameters.AddWithValue("@Kaartnummer", tankkaart.Kaartnummer);
                    insertCommand.Parameters.AddWithValue("@Geldigheidsdatum", tankkaart.Geldigheidsdatum);
                    insertCommand.Parameters.AddWithValue("@isGeblokkeerd", tankkaart.Geblokkeerd);
                    if (tankkaart.Brandstof == null)
                    {
                        insertCommand.Parameters.AddWithValue("@Brandstof", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@Brandstof", tankkaart.Brandstof);
                    }
                    if (tankkaart.Pincode == null)
                    {
                        insertCommand.Parameters.AddWithValue("@Pincode", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@Pincode", tankkaart.Pincode);
                    }

                    insertCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw new TankkaartException($"Er ging iets mis in de persitentielaag bij het creeren van de tankkaart, {ex.Message}");
            }
        }
        public void UpdateTankkaart(Tankkaart tankkaart)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string updateSql = "UPDATE tankkaart SET tankkaartnummer = @Kaartnummer, geldigheidsDatum = @Geldigheidsdatum, " +
                        "brandstof = @Brandstof, pincode = @Pincode, isGeblokkeerd = @Geblokkeerd WHERE tankkaartnummer = @Kaartnummer";
                    SqlCommand updateCommand = new(updateSql, conn);

                    updateCommand.Parameters.AddWithValue("@Kaartnummer", tankkaart.Kaartnummer);
                    updateCommand.Parameters.AddWithValue("@Geldigheidsdatum", tankkaart.Geldigheidsdatum);
                    updateCommand.Parameters.AddWithValue("@Geblokkeerd", tankkaart.Geblokkeerd);
                    if (tankkaart.Brandstof == null)
                    {
                        updateCommand.Parameters.AddWithValue("@Brandstof", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@Brandstof", tankkaart.Brandstof);
                    }
                    if (tankkaart.Pincode == null)
                    {
                        updateCommand.Parameters.AddWithValue("@Pincode", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@Pincode", tankkaart.Pincode);
                    }

                    updateCommand.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw new TankkaartException($"Er ging iets mis in de persitentielaag bij het updaten van de tankkaart met kaartnummer: {tankkaart.Kaartnummer}, {ex.Message}");
            }
        }

        public void DeleteTankkaart(Tankkaart tankkaart)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string deleteSql = "UPDATE tankkaart SET isDeleted = 1 WHERE tankkaartnummer = @Kaartnummer";
                    SqlCommand deleteCommand = new(deleteSql, conn);

                    deleteCommand.Parameters.AddWithValue("@Kaartnummer", tankkaart.Kaartnummer);

                    deleteCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw new TankkaartException($"Er ging iets mis in de persitentielaag bij het verwijderen van de tankkaart met kaartnummer: {tankkaart.Kaartnummer}, {ex.Message}");
            }
        }

        public void RetrieveTankkaart(Tankkaart tankkaart)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string retrieveSql = "UPDATE tankkaart SET isDeleted = 0 WHERE tankkaartnummer = @Kaartnummer";
                    SqlCommand retrieveCommand = new(retrieveSql, conn);

                    retrieveCommand.Parameters.AddWithValue("@Kaartnummer", tankkaart.Kaartnummer);

                    retrieveCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new TankkaartException($"Er ging iets mis in de persitentielaag bij het retrieven van de tankkaart met kaartnummer: {tankkaart.Kaartnummer}, {ex.Message}");
            }
        }
    }
}
