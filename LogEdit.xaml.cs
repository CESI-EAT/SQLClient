using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQLClient
{
    /// <summary>
    /// Interaction logic for LogEdit.xaml
    /// </summary>
    public partial class LogEdit : Page
    {
        Database.Log log = new Database.Log();

        public LogEdit()
        {
            InitializeComponent();
            SQLClient.Cesieat.Instance.currentPage = "logEdit";

            log = SQLClient.Cesieat.Instance.log;
            id.Text = log.Id.ToString();
            fName.Text = log.User.FirstName.ToString();
            lName.Text = log.User.LastName.ToString();
            tStamp.Text = log.TimeStamp.ToString();
            type.Text = log.type.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLClient.Cesieat.Instance.updateFrame("UserLog.xaml");
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Database.Log logSaved = log;
            logSaved.User.FirstName = fName.Text;
            logSaved.User.LastName = lName.Text;
            try
            {
                logSaved.TimeStamp = DateTime.Parse(tStamp.Text);
            } catch
            {
                return;
            }
            
            logSaved.type = type.Text;

            Database.DAO.updateLog(log, SQLClient.Cesieat.Instance.connectionString);

            id.Text = log.Id.ToString();
            fName.Text = log.User.FirstName.ToString();
            lName.Text = log.User.LastName.ToString();
            tStamp.Text = log.TimeStamp.ToString();
            type.Text = log.type.ToString();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            /*Database.User userSaved = user;
            userSaved.FirstName = fName.Text;
            userSaved.LastName = lName.Text;
            userSaved.Address = address.Text;
            userSaved.PhoneNum = pNum.Text;
            userSaved.Role = Database.DAO.GetRoleByName(SQLClient.Cesieat.Instance.connectionString, role.Text);*/

            Database.DAO.deleteLog(log, SQLClient.Cesieat.Instance.connectionString);

            SQLClient.Cesieat.Instance.updateFrame("UserLog.xaml");
        }
    }
}
