using EntityLayer;
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

namespace PlayGround.View
{
    /// <summary>
    /// Interaction logic for AdminTurfDetailsView.xaml
    /// </summary>
    public partial class AdminTurfDetailsView : UserControl
    {
        public AdminTurfDetailsView()
        {
            InitializeComponent();
        }
        private void Row_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            txtID.Text = (gdShowBookings.SelectedItem as TurfModel).TurfID.ToString();
        }
    }
}
