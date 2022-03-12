using FontAwesome.WPF;
using MaterialDesignThemes.Wpf;
using PlayGround.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PlayGround.ViewModel
{
    public class AdminMainWindowViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel = new AdminDashboardViewModel();
        public BaseViewModel SelectedViewModel { get => _selectedViewModel; set { _selectedViewModel = value; onPropertyChanged(nameof(SelectedViewModel)); } }
        public ICommand AdminRedirectViewCommands { get; set; }
        public AdminMainWindowViewModel()
        {
            AdminRedirectViewCommands = new AdminRedirectViewCommand(this);
        }
    }
}
