using MaterialDesignThemes.Wpf;
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
            else if (parameter.ToString() == "UserTurfBooking")
            {
                viewModel.SelectedViewModel = new UserTurfBookingViewModel();
            }
            else if (parameter.ToString() == "IsDarkMode")
            {
                 PaletteHelper paletteHelper = new PaletteHelper();
                 ITheme theme = paletteHelper.GetTheme();
                if (viewModel.IsDarknLightMode = theme.GetBaseTheme() == BaseTheme.Dark)
                {
                    viewModel.IsDarknLightMode = false;
                    theme.SetBaseTheme(Theme.Light);
                }
                else
                {
                    viewModel.IsDarknLightMode = true;
                    theme.SetBaseTheme(Theme.Dark);
                }
                paletteHelper.SetTheme(theme);
            }
        }
    }
}
