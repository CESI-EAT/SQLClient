using System;
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
        private MainWindow mainWindow;
        public DAO(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.mainWindow.UpdateTextBox("NEW DAO");

        }

        public void SendInsert(string username)
        {
            string query = "INSERT INTO [CESIEAT].[dbo].[Users] ([Username])" + " Values ('" + username + "')";
            executeQuery(query);
        }

        public int executeQuery(string query)
        {
            this.mainWindow.UpdateTextBox("BEGIN EXECUTE QUERY");
            // Initialization.  
            int rowCount = 0;
            SqlConnection sqlConnection = new SqlConnection(this.GetConnectString());
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                this.mainWindow.UpdateTextBox("TRY CONNECT");
                // Settings.  
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                // Open.  
                sqlConnection.Open();

                // Result.  
                rowCount = sqlCommand.ExecuteNonQuery();

                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                this.mainWindow.UpdateTextBox("CATCH CONNECT");

                // Close.  
                sqlConnection.Close();

                throw ex;
            }

            return rowCount;
        }
        public string GetConnectString() { 
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(GetConnectionString());

            // The input connection string used the
            // Server key, but the new connection string uses
            // the well-known Data Source key instead.
            Console.WriteLine(builder.ConnectionString);

            // Pass the SqlConnectionStringBuilder an existing
            // connection string, and you can retrieve and
            // modify any of the elements.
            builder.ConnectionString = "server=25.68.148.251;user id=sa;" +
                "password=Poiuytr1234.;";

            // Now that the connection string has been parsed,
            // you can work with individual items.
            Console.WriteLine(builder.Password);
            builder.Password = "Poiuytr1234.";
            builder.AsynchronousProcessing = true;

            // You can refer to connection keys using strings,
            // as well. When you use this technique (the default
            // Item property in Visual Basic, or the indexer in C#),
            // you can specify any synonym for the connection string key
            // name.
            builder["Server"] = "25.68.148.251";
            builder["Connect Timeout"] = 1000;
            builder["Trusted_Connection"] = false;
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
