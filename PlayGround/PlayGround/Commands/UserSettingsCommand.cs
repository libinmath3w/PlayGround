using BusinessLayer;
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
    public class UserSettingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public UserSettingsViewModels userSettingsViewModels { get; set; }

        public UserSettingsCommand(UserSettingsViewModels userSettingsViewModel)
        {
                userSettingsViewModels = userSettingsViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "SaveUserChanges")
            {
                UsersModel usersModel = new UsersModel();
                usersModel.UserId = 2;
                usersModel.Name = userSettingsViewModels.Name;
                usersModel.UserEmailID = userSettingsViewModels.Emailid;
                usersModel.PhoneNumber = userSettingsViewModels.PhoneNumber;
                usersModel.City = userSettingsViewModels.City;
                usersModel.State = userSettingsViewModels.State;
                usersModel.Zip = userSettingsViewModels.Zip;
                UserSettingsBusinessModel userSettingsBusinessModel = new UserSettingsBusinessModel();
                userSettingsBusinessModel.SaveUserDetails(usersModel);
            }
            else if (parameter.ToString() == "UpdatePassword")
            {

            }
            else if (parameter.ToString() == "UserBrowseImage")
            {

            }
        }
    }
}
