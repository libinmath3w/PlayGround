using EntityLayer;
using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayGround.Commands
{
    public class AdminRedirectViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public AdminMainWindowViewModel viewModel { get; set; }
        public AdminRedirectViewCommand(AdminMainWindowViewModel adminMainWindowViewModel)
        {
            this.viewModel = adminMainWindowViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if (parameter.ToString() == "AdminDashboard")
            {
                viewModel.SelectedViewModel = new AdminUserDashboardViewModel();
            }
            else if (parameter.ToString() == "AdminSettings")
            {
                viewModel.SelectedViewModel = new AdminSettingsViewModel();
            }
            else if (parameter.ToString() == "AdminTurfBookingDetails")
            {
                viewModel.SelectedViewModel = new AdminTurfBookingHistoryViewModel();
            }
        }
    }
}
