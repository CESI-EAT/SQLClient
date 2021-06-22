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
            string query = "INSERT INTO [CESIEAT.Users] ([Username])" + " Values ('" + username + "')";
            executeQuery(query);
        }

        public int executeQuery(string query)
        {
            this.mainWindow.UpdateTextBox("BEGIN EXECUTE QUERY");
            // Initialization.  
            int rowCount = 0;
            string strConn = "Data Source=172.20.6.104;Database=CESIEAT;User Id=developper;Password=Poiuytr1234.;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                this.mainWindow.UpdateTextBox("TRY CONNECT");
                // Settings.  
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                //sqlCommand.CommandTimeout = 10; //// Setting timeeout for longer queries to 10 seconds.  

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
    }
}
