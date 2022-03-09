using BusinessLayer;
using EntityLayer;
using PlayGround.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayGround.ViewModel
{
    public class AdminSettingsViewModel : BaseViewModel
    {
        private int _userID;
        private string _name;
        private string _emailid;
        private string _phoneNumber;
        private string _avatar;
        public int UserID { get => _userID; set { _userID = value; onPropertyChanged("User ID"); } }
        public string Name { get => _name; set { _name = value; onPropertyChanged("Name"); } }
        public string Emailid { get => _emailid; set { _emailid = value; onPropertyChanged("Email ID"); } }
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; onPropertyChanged("Phone Number"); } }
        public string Avatar { get => _avatar; set { _avatar = value; onPropertyChanged("Avatar"); } }
        public ICommand AdminSettingsCommands { get; set; }
        public AdminSettingsViewModel adminSettingsViewModels { get; set; }
        public AdminSettingsViewModel(UsersModel usersModel)
        {
            AdminSettingsCommands = new AdminSettingsCommand(this);
            AdminSettingsBusinessModel adminSettingsBusinessModel = new AdminSettingsBusinessModel();
            UsersModel users = new UsersModel();
            users.UserId = usersModel.UserId;
            var query = adminSettingsBusinessModel.GetUserDetails(users);
            foreach (var item in query)
            {
                Name = item.Name;
                Emailid = item.UserEmailID;
                PhoneNumber = item.PhoneNumber;
                var pathRegex = new Regex(@"\\bin(\\x86|\\x64)?\\(Debug|Release)$", RegexOptions.Compiled);
                var directory = pathRegex.Replace(Directory.GetCurrentDirectory(), String.Empty);
                Avatar = directory + "/Uploads/" + item.Avatar;
            }
        }
    }
}
