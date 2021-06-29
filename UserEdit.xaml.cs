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
        Database.User user = new Database.User() {
            Id = 1,
            FirstName = "test1",
            LastName = "tset1",
            Address = "404 test street",
            PhoneNum = "0654321987",
            Role = "Consommateur",
        };

        public UserEdit()
        {
            InitializeComponent();
            id.Text = user.Id.ToString();
            fName.Text = user.FirstName.ToString();
            lName.Text = user.LastName.ToString();
            address.Text = user.Address.ToString();
            pNum.Text = user.PhoneNum.ToString();
            role.Text = user.Role.ToString();
        }
    }
}
