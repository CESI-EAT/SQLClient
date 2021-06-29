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
    /// Interaction logic for MainWIndow.xaml
    /// </summary>
    public partial class Cesieat : Window
    {
        public string connectionString { get; set; }
        public string userType { get; set; }

        public static Cesieat Instance { get; private set; }

        static Cesieat()
        {
            Instance = new Cesieat();
        }

        private Cesieat()
        {
            InitializeComponent();
            ContentPage.Source = new Uri("Connexion.xaml", UriKind.Relative);
        }

        public void updateFrame(String newFrame)
        {
            ContentPage.Source = new Uri(newFrame, UriKind.Relative);
        }
    }



    
}
