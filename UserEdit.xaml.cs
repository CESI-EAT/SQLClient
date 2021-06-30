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
    /// Interaction logic for UserEdit.xaml
    /// </summary>
    public partial class UserEdit : Page
    {
        Database.User user = new Database.User();

        public UserEdit()
        {
            InitializeComponent();
            user = SQLClient.Cesieat.Instance.user;
            id.Text = user.Id.ToString();
            fName.Text = user.FirstName.ToString();
            lName.Text = user.LastName.ToString();
            address.Text = user.Address.ToString();
            pNum.Text = user.PhoneNum.ToString();
            role.Text = user.Role.Name.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLClient.Cesieat.Instance.updateFrame("UserList.xaml");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Database.User userSaved = user;
            userSaved.FirstName = fName.Text;
            userSaved.LastName = lName.Text;
            userSaved.Address = address.Text;
            userSaved.PhoneNum = pNum.Text;
            userSaved.Role = Database.DAO.GetRoleByName(SQLClient.Cesieat.Instance.connectionString, role.Text);

            Database.DAO.updateUser(user, SQLClient.Cesieat.Instance.connectionString);

            user = userSaved;

            id.Text = user.Id.ToString();
            fName.Text = user.FirstName.ToString();
            lName.Text = user.LastName.ToString();
            address.Text = user.Address.ToString();
            pNum.Text = user.PhoneNum.ToString();
            role.Text = user.Role.Name.ToString();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            /*Database.User userSaved = user;
            userSaved.FirstName = fName.Text;
            userSaved.LastName = lName.Text;
            userSaved.Address = address.Text;
            userSaved.PhoneNum = pNum.Text;
            userSaved.Role = Database.DAO.GetRoleByName(SQLClient.Cesieat.Instance.connectionString, role.Text);*/

            Database.DAO.deleteUser(user, SQLClient.Cesieat.Instance.connectionString);

            SQLClient.Cesieat.Instance.updateFrame("UserList.xaml");
        }
    }
}
