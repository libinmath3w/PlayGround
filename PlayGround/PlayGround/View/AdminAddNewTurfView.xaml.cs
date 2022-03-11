using BusinessLayer;
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
    /// Interaction logic for AdminAddNewTurfView.xaml
    /// </summary>
    public partial class AdminAddNewTurfView : UserControl
    {
        public AdminAddNewTurfView()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            string turfid = txtId.Text;
            if (!string.IsNullOrEmpty(turfid))
            {
                lblnewturf.Content = "Edit Turf Details";
                AdminAddNewTurfBusinessModel adminAddNewTurfBusinessModels = new AdminAddNewTurfBusinessModel();
                TurfModel turf = new TurfModel();
                turf.TurfID = Convert.ToInt32(turfid);
                var query = adminAddNewTurfBusinessModels.GetTurfDetails(turf);
                foreach (var item in query)
                {
                    txtTurfName.Text = item.TurfName;
                    txtTurfCity.Text = item.TurfCity;
                    txtTurfState.Text = item.TurfState;
                    txtTurfPost.Text = item.Zip;
                    txtTurfAmount.Text = item.TurfPrice.ToString();
                }
            }
            else
            {
                MessageBox.Show("Enter a Turf ID");
            }
        }
    }
}
