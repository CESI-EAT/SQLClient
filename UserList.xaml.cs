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
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : Page
    {
        List<Database.User> users = new List<Database.User>();
        public UserList()
        {
            InitializeComponent();

            uList.ItemsSource = Database.DAO.GetUserList(SQLClient.Cesieat.Instance.connectionString);
                        
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var user = sender as ListViewItem;
            if (user != null)
            {
                SQLClient.Cesieat.Instance.user = (Database.User)user.DataContext;
                if (SQLClient.Cesieat.Instance.userType == "technique")
                {
                    SQLClient.Cesieat.Instance.updateFrame("UserLog.xaml");
                } else if(SQLClient.Cesieat.Instance.userType == "commercial")
                {
                    SQLClient.Cesieat.Instance.updateFrame("UserEdit.xaml");
                } else
                {
                    SQLClient.Cesieat.Instance.updateFrame("Connexion.xaml");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLClient.Cesieat.Instance.updateFrame("Connexion.xaml");
        }
    }
}