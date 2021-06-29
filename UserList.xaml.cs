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

            users.Add(new Database.User
            {
                Id = 1,
                FirstName = "test1",
                LastName = "tset1",
                Address = "404 test street",
                PhoneNum = "0654321987",
                Role = "Consommateur",
            });
            
            users.Add(new Database.User
            {
                Id = 2,
                FirstName = "test2",
                LastName = "tset2",
                Address = "405 test street",
                PhoneNum = "0654321987",
                Role = "Consommateur",
            });
            
            uList.ItemsSource = Database.DAO.GetUserList(SQLClient.Cesieat.Instance.connectionString);
                        
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var user = sender as ListViewItem;
            if (user != null)
            {
                //SQLClient.Cesieat.Instance.setTargetteUser(user.Tag.);

                if (SQLClient.Cesieat.Instance.userType == "technique")
                //SQLClient.Cesieat.Instance.updateFrame("UserEdit.xaml");
                SQLClient.Cesieat.Instance.updateFrame("UserLog.xaml");
            }
        }
    }
}
