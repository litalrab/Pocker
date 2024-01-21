using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PokerDataAcess
{
    public class TaskDataAcess
    {

        public static List<PokerDataAcess.Models.Task> Get()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);
            try
            {

                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * from tasks", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();

                List<PokerDataAcess.Models.Task> tasks = new List<PokerDataAcess.Models.Task>();
                if (dt.Rows.Count > 0)
                {
                    PokerDataAcess.Models.Task t = new PokerDataAcess.Models.Task();
                    foreach (DataRow row in dt.Rows)
                    {
                        t = new PokerDataAcess.Models.Task();
                        t.Description = Convert.ToString(row["description"]);
                        t.CompletionCriteria = Convert.ToInt32(row["completion_criteria"]);
                        t.BundleId = Convert.ToInt32(row["bundle_id"]);
                        t.DifficultyLevel = Convert.ToInt32(row["completion_criteria"]);
                        t.Completed = Convert.ToBoolean(row["is_completed"]);
                        t.Id = Convert.ToInt32(row["Id"]);
                        tasks.Add(t);

                    }
                }
                return tasks;
            }
            catch (Exception ex)
            {
                conn.Close();

                return null;
            }
        }

        public static PokerDataAcess.Models.Task Get(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * from tasks where Id = " + id, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            List<PokerDataAcess.Models.Task> tasks = new List<PokerDataAcess.Models.Task>();
            if (dt.Rows.Count > 0)
            {
                PokerDataAcess.Models.Task t = new PokerDataAcess.Models.Task();
                foreach (DataRow row in dt.Rows)
                {
                    t = new PokerDataAcess.Models.Task();
                    t.Description = Convert.ToString(row["description"]);
                    t.CompletionCriteria = Convert.ToInt32(row["completion_criteria"]);
                    t.BundleId = Convert.ToInt32(row["bundle_id"]);
                    t.DifficultyLevel = Convert.ToInt32(row["completion_criteria"]);
                    t.Completed = Convert.ToBoolean(row["is_completed"]);
                    t.Id = Convert.ToInt32(row["Id"]);
                    return t;
                }

            }
            return null;

        }

        public static List<PokerDataAcess.Models.Task> Get(string criteria)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from tasks where completion_criteria = " + criteria, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                List<PokerDataAcess.Models.Task> tasks = new List<PokerDataAcess.Models.Task>();
                if (dt.Rows.Count > 0)
                {
                    PokerDataAcess.Models.Task t = new PokerDataAcess.Models.Task();
                    foreach (DataRow row in dt.Rows)
                    {
                        t = new PokerDataAcess.Models.Task();
                        t.Description = Convert.ToString(row["description"]);
                        t.CompletionCriteria = Convert.ToInt32(row["completion_criteria"]);
                        t.BundleId = Convert.ToInt32(row["bundle_id"]);
                        t.DifficultyLevel = Convert.ToInt32(row["difficulty_level"]);
                        t.Completed = Convert.ToBoolean(row["Completed"]);
                        t.Id = Convert.ToInt32(row["Id"]);
                    }
                }
                return tasks;
            }
            catch (Exception ex)
            {
                conn.Close();

                return null;
            }
        }

        public static bool Add(PokerDataAcess.Models.Task task)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
            // string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=C:\\USERS\\LITAL\\SOURCE\\REPOS\\POKER\\POKER\\DATABASE.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter();

                SqlCommand command = new SqlCommand(
                  "INSERT INTO tasks ( description, completion_criteria, difficulty_level, is_completed, bundle_id) " +
                  "VALUES ( @Description, @CompletionCriteria ,@DifficultyLevel ,@Completed , @Bundle_id  )", conn);

                command.Parameters.AddWithValue("@Description", task.Description);
                command.Parameters.AddWithValue("@CompletionCriteria", task.CompletionCriteria);
                command.Parameters.AddWithValue("@DifficultyLevel", task.DifficultyLevel);
                command.Parameters.AddWithValue("@Completed", task.Completed);
                command.Parameters.AddWithValue("@Bundle_id", task.BundleId);

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

        public static bool Update(PokerDataAcess.Models.Task task)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter();

                string strUpdateCommand =
                 "Update tasks set Id = @Id, description = @Description, completion_criteria = @CompletionCriteria ,is_completed = @is_completed ,bundle_id = @bundle_id where Id = @Id";
                SqlCommand command = new SqlCommand(strUpdateCommand, conn);

                command.Parameters.AddWithValue("@Id", task.Id);
                command.Parameters.AddWithValue("@Description", task.Description);
                command.Parameters.AddWithValue("@CompletionCriteria", task.CompletionCriteria);
                command.Parameters.AddWithValue("@DifficultyLevel", task.DifficultyLevel);
                command.Parameters.AddWithValue("@is_completed", task.Completed);
                command.Parameters.AddWithValue("@bundle_id", task.BundleId);

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
                    "DELETE FROM tasks where Id = @Id", conn);

                command.Parameters.AddWithValue("@Id", id);

                da.DeleteCommand = command;
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
