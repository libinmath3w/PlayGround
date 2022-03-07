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
        public UserLoginViewModel userLoginViewModel { get; set; }
        public UserSignupCommand(UserLoginViewModel userLoginViewModel)
        {
            this.userLoginViewModel = userLoginViewModel;
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
            UserSignUpBusinessModel userSignUpBusinessModel = new UserSignUpBusinessModel();
            PasswordBox boxpass = (PasswordBox)parameter;
            Password = boxpass.Password;
            
            if(Password.Length < 8)
            {
                System.Windows.MessageBox.Show("Password length too small");

            }
            else
            {
               
            }
             
        }
    }
}
