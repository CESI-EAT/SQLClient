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

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }   
}