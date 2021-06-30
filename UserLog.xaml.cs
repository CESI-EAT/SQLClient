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
    /// Interaction logic for UserLog.xaml
    /// </summary>
    public partial class UserLog : Page
    {

        List<Database.Log> logs = new List<Database.Log>();

        public UserLog()
        {
            InitializeComponent();
            
            foreach (Database.Log log in Database.DAO.GetLogList(SQLClient.Cesieat.Instance.connectionString)){
                if (log.User.Id == SQLClient.Cesieat.Instance.user.Id)
                {
                    logs.Add(log);
                }
            }
            lList.ItemsSource = logs;

        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var log = sender as ListViewItem;
            if (log != null)
            {
                SQLClient.Cesieat.Instance.log = (Database.Log)log.DataContext;

                SQLClient.Cesieat.Instance.updateFrame("LogEdit.xaml");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLClient.Cesieat.Instance.updateFrame("UserList.xaml");
        }
    }
}
