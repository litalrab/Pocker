using PokerDataAcess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PokerDataAcess
{
    public class BundlesDataAcess
    {

        public static List<Bundle> Get()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {

                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * from bundles", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                List<Bundle> bundles = new List<Bundle>();
                if (dt.Rows.Count > 0)
                {
                    Bundle b = new Bundle();
                    foreach (DataRow row in dt.Rows)
                    {
                        b = new Bundle();
                        b.Description = Convert.ToString(row["description"]);
                        b.Name = Convert.ToString(row["name"]);
                        b.CompletionCriteria = Convert.ToInt32(row["completion_criteria"]);
                        bundles.Add(b);
                    }
                }
                return bundles;

            }
            catch (Exception e)
            {
                conn.Close();

                return null;
            }


        }

        public static Bundle Get(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {

                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * from bundles where Id = " + id, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                if (dt.Rows.Count > 0)
                {
                    Bundle b = new Bundle();
                    foreach (DataRow row in dt.Rows)
                    {
                        b = new Bundle();
                        b.Description = Convert.ToString(row["description"]);
                        b.Name = Convert.ToString(row["name"]);
                        b.CompletionCriteria = Convert.ToInt32(row["completion_criteria"]);
                        return b;

                    }
                }
                return null;

            }
            catch (Exception e)
            {
                conn.Close();

                return null;
            }
        }

        public static List<Bundle> Get(string criteria)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from bundles where completion_criteria = " + criteria, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                List<Bundle> bundles = new List<Bundle>();
                if (dt.Rows.Count > 0)
                {
                    Bundle b = new Bundle();
                    foreach (DataRow row in dt.Rows)
                    {
                        b = new Bundle();
                        b.Description = Convert.ToString(row["description"]);
                        b.Name = Convert.ToString(row["name"]);
                        b.CompletionCriteria = Convert.ToInt32(row["completion_criteria"]);
                        bundles.Add(b);
                    }
                }
                return bundles;
            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
            }

        }

        public static bool Add(Bundle bundles)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=C:\\USERS\\LITAL\\SOURCE\\REPOS\\POKER\\POKER\\DATABASE.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter();

                SqlCommand command = new SqlCommand(
                    "INSERT INTO bundles ( description, completion_criteria) " +
          "VALUES ( @Description, @CompletionCriteria )", conn);

                command.Parameters.AddWithValue("@Description", bundles.Description);
                command.Parameters.AddWithValue("@CompletionCriteria", bundles.CompletionCriteria);


                da.InsertCommand = command;
                int result = command.ExecuteNonQuery();

                return true;

            }

            catch (Exception e)
            {
                conn.Close();

                return false;
            }

        }

        public static bool Update(Bundle bundle)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter();
                string strUpdateCommand =
                      "Update bundles set Id = @Id, description = @Description, completion_criteria = @CompletionCriteria ,is_completed = @is_completed where Id = @ID";

                SqlCommand command = new SqlCommand(strUpdateCommand, conn);

                command.Parameters.AddWithValue("@Description", bundle.Description);
                command.Parameters.AddWithValue("@CompletionCriteria", bundle.CompletionCriteria);
                command.Parameters.AddWithValue("@is_completed", bundle.Completed);


                da.UpdateCommand = command;
                int result = command.ExecuteNonQuery();

                return true;

            }

            catch (Exception e)
            {
                conn.Close();

                return false;
            }

        }

        public static bool Delete(int id)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter();

                SqlCommand command = new SqlCommand(
                    "DELETE FROM bundles where Id = @Id", conn);

                command.Parameters.AddWithValue("@Id", id);

                da.DeleteCommand = command;
                int result = da.DeleteCommand.ExecuteNonQuery();

                return true;

            }

            catch
            {
                conn.Close();

                return false;
            }


        }


    }
}
