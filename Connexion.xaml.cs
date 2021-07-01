using SQLClient.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            SQLClient.Cesieat.Instance.currentPage = "connexion";

            parent = father;
        }

        private void OpenWebsite(object sender, RoutedEventArgs e)
        {
            _ = System.Diagnostics.Process.Start("https://app.morse-messenger.com/");
        }

        private void OpenESXI(object sender, RoutedEventArgs e)
        {
            _ = System.Diagnostics.Process.Start("https://app.morse-messenger.com:666/");
        }

        private void OpenKubernetes(object sender, RoutedEventArgs e)
        {
            _ = System.Diagnostics.Process.Start("https://app.morse-messenger.com:667/");
        }

        private void OpenJenkins(object sender, RoutedEventArgs e)
        {
            _ = System.Diagnostics.Process.Start("http://app.morse-messenger.com:669/");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = ((ComboBoxItem) Name.SelectedValue).Content.ToString();
            string connectionString = Database.DAO.GetConnectString(name, Password.Password);
            Console.WriteLine(Name.SelectedValue.ToString() + " " + Password.Password);
            if (connectionString != null) {
                PFalse.Text = "";
                SQLClient.Cesieat.Instance.userType = name;
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
