using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogin
{
    class DataAccess
    {
        static string connectionString = "Server=DESKTOP-M2KNKSU;Database=Login;Trusted_Connection=True;";

        public void RegisterUser(User user)
        {
            try
            {

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO Persons(Username, UserPassword, Salt) VALUES (@Username, @UserPassword, @Salt)";

                        cmd.Parameters.AddWithValue("@Username",user.Username);
                        cmd.Parameters.AddWithValue("@UserPassword",user.Password);
                        cmd.Parameters.AddWithValue("@Salt",user.PassSalt);

                        cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine("Data posted to DB");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public User Login(string username)
        {
            try
            {

                User user = new User();
                using (var connection = new SqlConnection(connectionString))
                {
                    string commandText = @"SELECT * FROM Persons WHERE Username=@Username";
                    SqlCommand cmd = new SqlCommand(commandText, connection);
                    cmd.Parameters.AddWithValue("@Username", username);
                    connection.Open();
                    using (SqlDataReader oReader = cmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            user.Username = oReader["Username"].ToString();
                            user.Password = oReader["UserPassword"].ToString();
                            user.PassSalt = oReader["Salt"].ToString();
                        }
                    }

                    Console.WriteLine("Data collected from DB");
                    connection.Close();
                }
                
            return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
