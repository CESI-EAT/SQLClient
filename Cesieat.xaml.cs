using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Media;


namespace SQLClient
{
    /// <summary>
    /// Interaction logic for MainWIndow.xaml
    /// </summary>
    public partial class Cesieat : Window
    {
        public string connectionString { get; set; }
        public string userType { get; set; }
        public Database.User user { get; set; }
        public Database.Log log { get; set; }
        public string currentPage { get; set; }

        public static Cesieat Instance { get; private set; }

        static Cesieat()
        {
            Instance = new Cesieat();
            Color primaryColor = (Color) System.Windows.Media.ColorConverter.ConvertFromString("#FF912B");
            Color secondaryColor = (Color) System.Windows.Media.ColorConverter.ConvertFromString("#4A4A4A");

            IBaseTheme baseTheme = Theme.Light;
            ITheme theme = Theme.Create(baseTheme, primaryColor, secondaryColor);
            var paletteHelper = new PaletteHelper();
            paletteHelper.SetTheme(theme);
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

        private void Back(object sender, RoutedEventArgs e)
        {
            if (currentPage == "userList")
            {
                ContentPage.Source = new Uri("Connexion.xaml", UriKind.Relative);
            }
            else if (currentPage == "userEdit")
            {
                ContentPage.Source = new Uri("UserList.xaml", UriKind.Relative);
            }
            else if (currentPage == "userLog")
            {
                ContentPage.Source = new Uri("UserList.xaml", UriKind.Relative);
            }
            else if (currentPage == "logEdit")
            {
                ContentPage.Source = new Uri("UserLog.xaml", UriKind.Relative);
            } else
            {
                Application.Current.Shutdown();
            }

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }   
}