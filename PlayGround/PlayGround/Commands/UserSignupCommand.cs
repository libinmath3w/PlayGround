using BusinessLayer;
using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;

namespace PlayGround.Commands
{
    public class UserSignupCommand : ICommand
    {
        public string Password { get; set; }
       

        public event EventHandler CanExecuteChanged;
        private UserRegistrationViewModel _userRegistrationViewModel { get; set; }
        public UserSignupCommand(UserRegistrationViewModel userRegistrationViewModel)
        {
            _userRegistrationViewModel = userRegistrationViewModel;
        }

        public UserSignupCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "userSignUp")
            {
                UserSignUpBusinessModel userSignUpBusinessModel = new UserSignUpBusinessModel();
                PasswordBox boxpass = (PasswordBox)parameter;
                Password = boxpass.Password;

                if (Password.Length < 8)
                {
                    System.Windows.MessageBox.Show("Password length short");

                }
                else
                {
                    System.Windows.MessageBox.Show("Password length correct");
                }
            }
            else if (parameter.ToString() == "signin")
            {
                System.Windows.MessageBox.Show("Login page");
            }
        }
    }
}
