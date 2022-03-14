using EntityLayer;
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
        private string _helloName;
        private string _avatar;
        public UsersModel UsersModels = new UsersModel();
        private BaseViewModel _selectedViewModel = new AdminDashboardViewModel();
        public BaseViewModel SelectedViewModel { get => _selectedViewModel; set { _selectedViewModel = value; onPropertyChanged(nameof(SelectedViewModel)); } }
        public ICommand AdminRedirectViewCommands { get; set; }
        public string HelloName { get => _helloName; set { _helloName = value; onPropertyChanged("Hello Name"); } }
        public string Avatar { get => _avatar; set { _avatar = value; onPropertyChanged("Avatar"); } }
        public AdminMainWindowViewModel(UsersModel usersModel)
        {
            UsersModels = usersModel;
            AdminRedirectViewCommands = new AdminRedirectViewCommand(this);
            HelloName = "Hello, " + usersModel.Name;
        }
    }
}
