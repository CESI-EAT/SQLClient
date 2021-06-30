using SQLClient.Database;
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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Connexion : Page
    {
        private DAO dao;
        private Cesieat parent;

        public Connexion()
        {
            InitializeComponent();
        }

        public Connexion(Cesieat father)
        {
            InitializeComponent();
            //this.dao = new DAO(this);

            parent = father;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = Database.DAO.GetConnectString(Name.Text, Password.Password);
            if (connectionString != null) {
                PFalse.Text = "";
                SQLClient.Cesieat.Instance.userType = Name.Text;
                SQLClient.Cesieat.Instance.connectionString = connectionString;
                SQLClient.Cesieat.Instance.updateFrame("UserList.xaml");
            } else
            {
                PFalse.Text = "Wrong id or password";
            }
            
        }

        public void UpdateTextBox(string text)
        {
            //txtStatus.Text = txtStatus.Text + "\n" + text;
        }
    }
}
