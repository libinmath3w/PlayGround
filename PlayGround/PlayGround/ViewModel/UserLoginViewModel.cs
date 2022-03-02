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
        public ICommand UserLoginViewCommands { get; set; }
        public UserLoginViewModel()
        {

        }  
    }
}
