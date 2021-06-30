using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClient.Database
{
    public class DAO
    {
        private Cesieat mainWindow;
        public DAO(Cesieat mainWindow)
        {
            this.mainWindow = mainWindow;
            //this.mainWindow.UpdateTextBox("NEW DAO");

        }

        /*public void SendInsert(string username)
        {
            string query = "INSERT INTO [CESIEAT].[dbo].[Users] ([Username])" + " Values ('" + username + "')";
            executeQuery(query);
        }*/

        /*public List<User> GetUserList()
        {
            List<User> userList;
            string query = "SELECT [Id],[Firstname],[Lastname],[Address],[PhoneNum],[Role],[Password],[Email] FROM [CESIEAT].[dbo].['Users']";
            userList = JsonSerializer.Deserialize<User>(executeUserQuery(query));
            return userList;
        }*/

        public static List<User> GetUserList(string connectionString)
        {
            //this.mainWindow.UpdateTextBox("BEGIN EXECUTE QUERY");
            // Initialization. 
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            List<User> users = new List<User>();

            try
            {
                //this.mainWindow.UpdateTextBox("TRY CONNECT");
                // Settings.  
                sqlCommand.CommandText = "SELECT [Id],[Firstname],[Lastname],[Address],[PhoneNum],[Role_id],[Password],[Email]FROM[CESIEAT].[dbo].[Users]";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //rowCount = sqlCommand.ExecuteNonQuery();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.Id = (int)reader["Id"];
                        user.FirstName = reader["FirstName"].ToString();
                        user.LastName = reader["LastName"].ToString();
                        user.Address = reader["Address"].ToString();
                        user.PhoneNum = reader["PhoneNum"].ToString();
                        user.Role = GetRoleById(connectionString,(int)reader["Role_id"]);
                        user.Password = reader["Password"].ToString();
                        user.Email = reader["Email"].ToString();
                        users.Add(user);
                    }
                }

                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //this.mainWindow.UpdateTextBox("CATCH CONNECT");

                // Close.  
                sqlConnection.Close();

                throw ex;
            }

            return users;
        }

        public static Role GetRoleById(string connectionString, int id)
        {
            //this.mainWindow.UpdateTextBox("BEGIN EXECUTE QUERY");
            // Initialization. 
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            Role role = new Role();

            try
            {
                //this.mainWindow.UpdateTextBox("TRY CONNECT");
                // Settings.  
                sqlCommand.CommandText = "SELECT [Name] FROM [CESIEAT].[dbo].[Roles] WHERE [Id] = '" + id + "'";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //rowCount = sqlCommand.ExecuteNonQuery();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        role.Id = id;
                        role.Name = reader["Name"].ToString();
                    }
                }

                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //this.mainWindow.UpdateTextBox("CATCH CONNECT");

                // Close.  
                sqlConnection.Close();

                throw ex;
            }

            return role;
        }

        public static Role GetRoleByName(string connectionString, string name)
        {
            //this.mainWindow.UpdateTextBox("BEGIN EXECUTE QUERY");
            // Initialization. 
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            Role role = new Role();

            try
            {
                //this.mainWindow.UpdateTextBox("TRY CONNECT");
                // Settings.  
                sqlCommand.CommandText = "SELECT [Id] FROM [CESIEAT].[dbo].[Roles] WHERE [Name] = '" + name + "'";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //rowCount = sqlCommand.ExecuteNonQuery();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        role.Name = name;
                        role.Id = (int)reader["Id"];
                    }
                }

                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //this.mainWindow.UpdateTextBox("CATCH CONNECT");

                // Close.  
                sqlConnection.Close();

                throw ex;
            }

            return role;
        }

        public static List<Log> GetLogList(string connectionString)
        {
            //this.mainWindow.UpdateTextBox("BEGIN EXECUTE QUERY");
            // Initialization. 
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            List<Log> logs = new List<Log>();

            try
            {
                //this.mainWindow.UpdateTextBox("TRY CONNECT");
                // Settings.  
                sqlCommand.CommandText = "SELECT [Logs].[Id],[Logs].[User_id],[Users].[Firstname],[Users].[Lastname],[Logs].[Created_at],[Logs].[Type] FROM [CESIEAT].[dbo].[Logs] LEFT JOIN[CESIEAT].[dbo].[Users] ON [Logs].[User_id] = [Users].[Id]";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //rowCount = sqlCommand.ExecuteNonQuery();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Log log = new Log();
                        log.Id = (int)reader["Id"];
                        log.User = new User();
                        log.User.Id = (int)reader["User_id"];
                        log.User.LastName = reader["FirstName"].ToString();
                        log.User.FirstName = reader["LastName"].ToString();
                        log.TimeStamp = (DateTime)reader["Created_at"];
                        log.type = reader["Type"].ToString();
                        logs.Add(log);
                    }
                }

                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //this.mainWindow.UpdateTextBox("CATCH CONNECT");

                // Close.  
                sqlConnection.Close();

                throw ex;
            }

            return logs;
        }

        public static void updateUser(User user, string connectionString)
        {
            //this.mainWindow.UpdateTextBox("BEGIN EXECUTE QUERY");
            // Initialization. 
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                //this.mainWindow.UpdateTextBox("TRY CONNECT");
                // Settings.  
                sqlCommand.CommandText = "UPDATE [CESIEAT].[dbo].[Users] SET [Firstname] = '" + user.FirstName + "',[Lastname] = '" + user.LastName + "',[Address] = '" + user.Address + "',[PhoneNum] = '" + user.PhoneNum + "',[Role_id] = '" + user.Role.Id + "',[Email] = '" + user.Email + "' WHERE Id = '" + user.Id + "'";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                // Open.  
                sqlConnection.Open();

                // Result.  
                sqlCommand.ExecuteReader();
                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //this.mainWindow.UpdateTextBox("CATCH CONNECT");

                // Close.  
                sqlConnection.Close();

                throw ex;
            }
        }

        public static void updateLog(Log log, string connectionString)
        {
            //this.mainWindow.UpdateTextBox("BEGIN EXECUTE QUERY");
            // Initialization. 
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                //this.mainWindow.UpdateTextBox("TRY CONNECT");
                // Settings.  
                sqlCommand.CommandText = "UPDATE [CESIEAT].[dbo].[Logs] SET [User_id] = '" + log.User.Id + "',[Created_at] = '" + log.TimeStamp + "',[Type] = '" + log.type + "' WHERE Id = '" + log.Id + "'";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                // Open.  
                sqlConnection.Open();

                // Result.  
                sqlCommand.ExecuteReader();
                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //this.mainWindow.UpdateTextBox("CATCH CONNECT");

                // Close.  
                sqlConnection.Close();

                throw ex;
            }
        }
        

        public static void deleteUser(User user, string connectionString)
        {
            //this.mainWindow.UpdateTextBox("BEGIN EXECUTE QUERY");
            // Initialization. 
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                //this.mainWindow.UpdateTextBox("TRY CONNECT");
                // Settings.  
                sqlCommand.CommandText = "DELETE FROM [CESIEAT].[dbo].[Users] WHERE Id = '" + user.Id + "'";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                // Open.  
                sqlConnection.Open();

                // Result.  
                sqlCommand.ExecuteReader();
                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //this.mainWindow.UpdateTextBox("CATCH CONNECT");

                // Close.  
                sqlConnection.Close();

                throw ex;
            }
        }

        public static void deleteLog(Log log, string connectionString)
        {
            //this.mainWindow.UpdateTextBox("BEGIN EXECUTE QUERY");
            // Initialization. 
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                //this.mainWindow.UpdateTextBox("TRY CONNECT");
                // Settings.  
                sqlCommand.CommandText = "DELETE FROM [CESIEAT].[dbo].[Logs] WHERE Id = '" + log.Id + "'";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                // Open.  
                sqlConnection.Open();

                // Result.  
                sqlCommand.ExecuteReader();
                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //this.mainWindow.UpdateTextBox("CATCH CONNECT");

                // Close.  
                sqlConnection.Close();

                throw ex;
            }
        }

        public static string GetConnectString(string userId, string password) { 
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(GetConnectionString());

            // The input connection string used the
            // Server key, but the new connection string uses
            // the well-known Data Source key instead.
            Console.WriteLine(builder.ConnectionString);

            // Pass the SqlConnectionStringBuilder an existing
            // connection string, and you can retrieve and
            // modify any of the elements.
            builder.ConnectionString = "server=sql.morse-messenger.com;user id=" + userId + ";" +
                "password=" + password + ";";

            // Now that the connection string has been parsed,
            // you can work with individual items.
            Console.WriteLine(builder.Password);
            builder.Password = password;
            builder.AsynchronousProcessing = true;

            // You can refer to connection keys using strings,
            // as well. When you use this technique (the default
            // Item property in Visual Basic, or the indexer in C#),
            // you can specify any synonym for the connection string key
            // name.
            builder["Server"] = "sql.morse-messenger.com";
            builder["Connect Timeout"] = 1000;
            builder["Trusted_Connection"] = false;

            SqlConnection sqlConnection = new SqlConnection(builder.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = "SELECT 1 FROM Users WHERE 1=0";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            try
            {
                sqlConnection.Open();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

            Console.WriteLine(builder.ConnectionString);
            return builder.ConnectionString;
        }

        private static string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.
            return "Server=25.68.148.251;Integrated Security=SSPI;";
        }
    }
}
