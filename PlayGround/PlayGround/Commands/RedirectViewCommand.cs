using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayGround.Commands
{
    public class RedirectViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel viewModel { get; set; }
        public RedirectViewCommand(MainViewModel MainviewModel)
        {
            this.viewModel = MainviewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "UserDashboard")
            {
                viewModel.SelectedViewModel = new UserDashboardViewModel();
            }
            else if (parameter.ToString() == "UserSettings")
            {
                viewModel.SelectedViewModel = new UserSettingsViewModels();
            }
        }
    }
}
