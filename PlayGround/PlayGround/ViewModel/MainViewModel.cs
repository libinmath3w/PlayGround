using EntityLayer;
using PlayGround.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayGround.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel = new UserDashboardViewModel();
        public bool IsDarknLightMode { get; set; }
        public BaseViewModel SelectedViewModel { get => _selectedViewModel; set { _selectedViewModel = value; onPropertyChanged(nameof(SelectedViewModel)); } }
        public ICommand RedirectViewCommands { get; set; }

        public MainViewModel(UsersModel usersModel)
        {
            RedirectViewCommands = new RedirectViewCommand(this);
        }
    }
}
