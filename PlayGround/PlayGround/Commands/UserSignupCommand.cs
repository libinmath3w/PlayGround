using BusinessLayer;
using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;

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

                if (Password.Length > 8)
                {
                  
                    if (_userRegistrationViewModel.UserEmailID.Length > 0)
                    {
                        System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                        if (!rEmail.IsMatch(_userRegistrationViewModel.UserEmailID))
                        {
                            MessageBox.Show("Invalid Email ID");

                        }
                    
                    System.Windows.MessageBox.Show("Password length too small");
}
                }
                else
                {

                }


            }
        }
    }
}
