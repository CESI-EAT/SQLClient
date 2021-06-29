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
    /// Interaction logic for LogEdit.xaml
    /// </summary>
    public partial class LogEdit : Page
    {
        Database.Log log = new Database.Log();

        public LogEdit()
        {
            InitializeComponent();
            log = SQLClient.Cesieat.Instance.log;
            id.Text = log.Id.ToString();
            fName.Text = log.User.FirstName.ToString();
            lName.Text = log.User.LastName.ToString();
            tStamp.Text = log.TimeStamp.ToString();
            type.Text = log.type.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLClient.Cesieat.Instance.updateFrame("UserLog.xaml");
        }
    }
}
