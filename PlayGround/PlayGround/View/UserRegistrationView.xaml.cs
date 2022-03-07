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
            pswCmd = new UserSignupCommand();
           
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("^[0-9]{10}");
            bool isValid = regex.IsMatch(txtPhoneNumber.Text);
            if (!isValid)
            {
                MessageBox.Show("Please Enter Valid Phone Number");
            }
            else
            {
               
            }
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail.Text.Length > 0)
            {
                if (!rEmail.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("Invalid Email ID");
                    txtEmail.SelectAll();
                }
                else
                {
                    

                }
            }
        }

       
    }
}
