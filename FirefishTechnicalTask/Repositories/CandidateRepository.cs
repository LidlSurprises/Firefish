using FirefishTechnicalTaskAPI.Entities;
using FirefishTechnicalTaskAPI.Interfaces.Repositories;
using Microsoft.AspNetCore.Routing.Matching;
using System.Data;
using System.Data.SqlClient;

namespace FirefishTechnicalTaskAPI.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly string _sqlConnection;

        public CandidateRepository(string sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public Candidate AddCandidateAsync(Candidate candidate)
        {
            using (SqlConnection connection = new SqlConnection(_sqlConnection))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("AddCandidate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = GetCandidateID();
                        command.Parameters.Add(new SqlParameter("@Forename", SqlDbType.VarChar)).Value = candidate.Forename;
                        command.Parameters.Add(new SqlParameter("@Surname", SqlDbType.VarChar)).Value = candidate.Surname;
                        command.Parameters.Add(new SqlParameter("@DOB", SqlDbType.Date)).Value = candidate.DateOfBirth;
                        command.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar)).Value = candidate.Address1;
                        command.Parameters.Add(new SqlParameter("@Town", SqlDbType.VarChar)).Value = candidate.Town;
                        command.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar)).Value = candidate.Country;
                        command.Parameters.Add(new SqlParameter("@PostCode", SqlDbType.VarChar)).Value = candidate.PostCode;
                        command.Parameters.Add(new SqlParameter("@PHome", SqlDbType.VarChar)).Value = candidate.PhoneHome;
                        command.Parameters.Add(new SqlParameter("@PMobile", SqlDbType.VarChar)).Value = candidate.PhoneMobile;
                        command.Parameters.Add(new SqlParameter("@PWork", SqlDbType.VarChar)).Value = candidate.PhoneWork;

                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                return new Candidate();
            }
        }

        public void DeleteCandidateAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_sqlConnection))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteCandidate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;

                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public Candidate GetCandidateAsync(int id)
        {
            Candidate candidate = new Candidate();
            using (SqlConnection connection = new SqlConnection(_sqlConnection))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetCandidate", connection))
                    {
                        command.Parameters.Add(new SqlParameter("ID", SqlDbType.Int)).Value = id;

                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                candidate = new Candidate()
                                {
                                    Id = reader.GetInt32("ID"),
                                    Forename = reader.GetString("FirstName"),
                                    Surname = reader.GetString("Surname"),
                                    DateOfBirth = reader.GetDateTime("DateOfBirth"),
                                    Address1 = reader.GetString("Address1"),
                                    Town = reader.GetString("Town"),
                                    Country = reader.GetString("Country"),
                                    PostCode = reader.GetString("PostCode"),
                                    PhoneHome = reader.GetString("PhoneHome"),
                                    PhoneMobile = reader.GetString("PhoneMobile"),
                                    PhoneWork = reader.GetString("PhoneWork")
                                };
                            }
                        }
                    }
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return candidate;
        }

        public List<Candidate> GetCandidatesAsync()
        {
            List<Candidate> candidates = new List<Candidate>();

            using (SqlConnection connection = new SqlConnection(_sqlConnection))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetAllCandidates", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Candidate candidate = new Candidate()
                                {
                                    Id = reader.GetInt32("ID"),
                                    Forename = reader.GetString("FirstName"),
                                    Surname = reader.GetString("Surname"),
                                    DateOfBirth = reader.GetDateTime("DateOfBirth"),
                                    Address1 = reader.GetString("Address1"),
                                    Town = reader.GetString("Town"),
                                    Country = reader.GetString("Country"),
                                    PostCode = reader.GetString("PostCode"),
                                    PhoneHome = reader.GetString("PhoneHome"),
                                    PhoneMobile = reader.GetString("PhoneMobile"),
                                    PhoneWork = reader.GetString("PhoneWork")
                                };
                                candidates.Add(candidate);
                            }
                        }
                    }
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return candidates;

        }

        public Candidate UpdateCandidateAsync(int id, Candidate candidate)
        {
            using (SqlConnection connection = new SqlConnection(_sqlConnection))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateCandidate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar)).Value = candidate.Id;
                        command.Parameters.Add(new SqlParameter("@Forename", SqlDbType.VarChar)).Value = candidate.Forename;
                        command.Parameters.Add(new SqlParameter("@Surname", SqlDbType.VarChar)).Value = candidate.Surname;
                        command.Parameters.Add(new SqlParameter("@DOB", SqlDbType.Date)).Value = candidate.DateOfBirth;
                        command.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar)).Value = candidate.Address1;
                        command.Parameters.Add(new SqlParameter("@Town", SqlDbType.VarChar)).Value = candidate.Town;
                        command.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar)).Value = candidate.Country;
                        command.Parameters.Add(new SqlParameter("@PostCode", SqlDbType.VarChar)).Value = candidate.PostCode;
                        command.Parameters.Add(new SqlParameter("@PHome", SqlDbType.VarChar)).Value = candidate.PhoneHome;
                        command.Parameters.Add(new SqlParameter("@PMobile", SqlDbType.VarChar)).Value = candidate.PhoneMobile;
                        command.Parameters.Add(new SqlParameter("@PWork", SqlDbType.VarChar)).Value = candidate.PhoneWork;

                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                return new Candidate();
            }
        }

        private int GetCandidateID()
        {
            int nextID = 0;

            using (SqlConnection connection = new SqlConnection(_sqlConnection))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetCandidateId", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                nextID = reader.GetInt32("ID") + 1;
                            }
                        }
                    }
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return nextID;
        }
    }
}