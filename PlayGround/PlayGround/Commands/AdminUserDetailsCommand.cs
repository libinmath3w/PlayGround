using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayGround.Commands
{
    public class AdminUserDetailsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public AdminUserDetailsCommand()
        {

        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Ban")
            {

            }
            else if (parameter.ToString() == "Approve")
            {

            }
            else if (parameter.ToString() == "Delete")
            {

            }
        }
    }
}
