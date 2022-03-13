using FontAwesome.WPF;
using PlayGround.Commands;
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
using System.Windows.Navigation;
using System.Text.RegularExpressions;
using PlayGround.ViewModel;

namespace PlayGround.View
{
    /// <summary>
    /// Interaction logic for UserRegistrationView.xaml
    /// </summary>
    public partial class UserRegistrationView : Window
    {
        public UserSignupCommand pswCmd { get; set; }
       
        public UserRegistrationView()
        {
            InitializeComponent();
            Icon = ImageAwesome.CreateImageSource(FontAwesomeIcon.SoccerBallOutline, Brushes.Green);
            DataContext = new UserRegistrationViewModel();
           
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new UserLoginView(); //create your new form.
            newForm.Show(); //show the new form.
            this.Close();
        }
    }
}
