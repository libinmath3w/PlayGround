using BusinessLayer;
using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayGround.Commands
{
    public class UserSignupCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public UserLoginViewModel userLoginViewModel { get; set; }
        public UserSignupCommand(UserLoginViewModel userLoginViewModel)
        {
            this.userLoginViewModel = userLoginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            UserSignUpBusinessModel userSignUpBusinessModel = new UserSignUpBusinessModel();

        }
    }
}
