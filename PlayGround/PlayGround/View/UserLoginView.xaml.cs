using EntityLayer;
using EntityLayer.Interface;
using FontAwesome.WPF;
using PlayGround.Commands;
using PlayGround.ViewModel;
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
using System.Windows.Shapes;

namespace PlayGround.View
{
    /// <summary>
    /// Interaction logic for UserLoginView.xaml
    /// </summary>
    public partial class UserLoginView : Window, ICloseable
    {
        public string userNames { get; set; }
        public UserSigninCommand pswCmd { get; set; }
        public UserLoginView()
        {
            InitializeComponent();
            Icon = ImageAwesome.CreateImageSource(FontAwesomeIcon.SoccerBallOutline, Brushes.Green);
            DataContext = new UserLoginViewModel();
        }
        public void CloseLoginPage()
        {
            this.Close();
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new UserRegistrationView(); //create your new form.
            newForm.Show(); //show the new form.
            this.Close();
        }
    }
}
