using EntityLayer;
using EntityLayer.Interface;
using PlayGround.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayGround.ViewModel
{
    public class UserLoginViewModel : BaseViewModel
    {
        private string _username;
        public string UserName { get => _username; set { _username = value; onPropertyChanged("User Name"); } }
        public ICommand UserLoginViewCommands { get; set; }
        public UserLoginViewModel()
        {
            UserLoginViewCommands = new UserSigninCommand(this);
        }
        public void CloseWindow(ICloseable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
