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
    /// Interaction logic for UserLog.xaml
    /// </summary>
    public partial class UserLog : Page
    {

        List<Database.Log> logs = new List<Database.Log>();

        public UserLog()
        {
            InitializeComponent();
            logs = Database.DAO.GetLogList(SQLClient.Cesieat.Instance.connectionString);
            lList.ItemsSource = logs;
            
        }
    }
}
