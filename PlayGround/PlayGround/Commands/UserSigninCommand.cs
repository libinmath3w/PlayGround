using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BusinessLayer;
using PlayGround.ViewModel;
using System.Windows.Controls;


namespace PlayGround.Commands
{
    public class UserSigninCommand : ICommand
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public event EventHandler CanExecuteChanged;
       
        private UserLoginViewModel _userLoginViewModel { get; set; }
        public UserSigninCommand(UserLoginViewModel userLoginViewModel)
        {
            _userLoginViewModel = userLoginViewModel;
        }
        public UserSigninCommand()
        { }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PasswordBox boxpass = (PasswordBox)parameter;
            Password = boxpass.Password;

            
            if (Password == "saranya")
            //{
            //    UserSignInBusinessModel userSignInBusinessModel = new UserSignInBusinessModel();
            //    if (userSignInBusinessModel != null)
            {
                System.Windows.MessageBox.Show("username and passeord ok");
                }
            
            else
            {
                System.Windows.MessageBox.Show("error ok");
            }

        }
    }
}
