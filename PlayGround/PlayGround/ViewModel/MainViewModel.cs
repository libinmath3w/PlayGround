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
        public UsersModel UsersModels { get; set; }
        private string _helloName;
        private string _avatar;
        public bool IsDarknLightMode { get; set; }
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel { get => _selectedViewModel; set { _selectedViewModel = value; onPropertyChanged(nameof(SelectedViewModel)); } }
        public ICommand RedirectViewCommands { get; set; }
        public string HelloName { get => _helloName; set { _helloName = value; onPropertyChanged("Hello Name"); } }
        public string Avatar { get => _avatar; set { _avatar = value; onPropertyChanged("Avatar"); } }
        public MainViewModel(UsersModel usersModel)
        {
            RedirectViewCommands = new RedirectViewCommand(this);
            UsersModels = usersModel;
            HelloName = "Hello, " + usersModel.Name;
            _selectedViewModel = new UserDashboardViewModel(UsersModels);
        }
    }
}
