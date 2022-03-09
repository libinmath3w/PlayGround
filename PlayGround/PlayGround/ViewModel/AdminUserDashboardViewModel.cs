using BusinessLayer;
using EntityLayer;
using PlayGround.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlayGround.ViewModel
{
    public class AdminUserDashboardViewModel : BaseViewModel
    {
        private int _userID;
        private string _name;
        private string _username;
        private string _emailid;
        private string _phoneNumber;
        private string _city;
        private string _state;
        private string _zip;
        private string _avatar;
        private DateTime _dateofaccountcreated = DateTime.Now;
        private string _status;
        private int _roleID;
        private string _search;
        private string _findbyid;
        public ICommand AdminUserDetailsCommands { get; set; }
        public AdminUserDashboardViewModel adminUserDashboardViewModel { get; set; }
        public int UserID { get => _userID; set { _userID = value; onPropertyChanged("User ID"); } }
        public string Name { get => _name; set { _name = value; onPropertyChanged("Name"); } }
        public string UserName { get => _username; set { _username = value; onPropertyChanged("UserName"); } }
        public string Emailid { get => _emailid; set { _emailid = value; onPropertyChanged("Email ID"); } }
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; onPropertyChanged("Phone Number"); } }
        public string City { get => _city; set { _city = value; onPropertyChanged("City"); } }
        public string State { get => _state; set { _state = value; onPropertyChanged("State"); } }
        public string Zip { get => _zip; set { _zip = value; onPropertyChanged("Zip"); } }
        public string Avatar { get => _avatar; set { _avatar = value; onPropertyChanged("Avatar"); } }
        public DateTime DateOfAccountCreated { get => _dateofaccountcreated; set { _dateofaccountcreated = value; onPropertyChanged("date of account created"); } }
        public string Status { get => _status; set { _status = value; onPropertyChanged("Status"); } }
        public int RoleID { get => _roleID; set { _roleID = value; onPropertyChanged("Role ID"); } }
        public string SearchName { get => _search; set { _search = value; onPropertyChanged("Search Name"); } }
        public string FindUserID { get => _findbyid; set { _findbyid = value; onPropertyChanged("Find User ID"); } }

        public ObservableCollection<UsersModel> _usersDetailsoc;
        public ObservableCollection<UsersModel> UsersDetailsOC
        {
            get { return _usersDetailsoc; }
            set
            {
                if (_usersDetailsoc == value) return;
                _usersDetailsoc = value;
                onPropertyChanged(nameof(UsersDetailsOC));
            }
        }

        public AdminUserDashboardViewModel()
        {
            AdminUserDetailsCommands = new AdminUserDetailsCommand(this);
            GetUsersList();
        }

        public void GetUsersList()
        {
            UsersDetailsOC = new ObservableCollection<UsersModel>();
            AdminUsersDetailsBusinessModel adminUsersDetailsBusinessModel = new AdminUsersDetailsBusinessModel();
            var query = adminUsersDetailsBusinessModel.GetAdminUsersDetails();
            foreach (var item in query)
            {
                UsersModel usersModel = new UsersModel();
                usersModel.UserId = item.UserId;
                usersModel.Name = item.Name;
                usersModel.UserName = item.UserName;
                usersModel.UserEmailID = item.UserEmailID;
                usersModel.PhoneNumber = item.PhoneNumber;
                usersModel.City = item.City;
                if (item.Status == 1)
                    usersModel.StatusName = "Active";
                else if (item.Status == 0)
                    usersModel.StatusName = "Pending";
                else
                    usersModel.StatusName = "Banned";
                usersModel.State = item.State;
                usersModel.Zip = item.Zip;
                if (item.RoleID == 1)
                    usersModel.RoleName = "Admin";
                else if (item.RoleID == 2)
                    usersModel.RoleName = "User";
                usersModel.RoleID = item.RoleID;
                usersModel.DateOfCreatedAccountTime = item.DateOfCreatedAccountTime;
                //var pathRegex = new Regex(@"\\bin(\\x86|\\x64)?\\(Debug|Release)$", RegexOptions.Compiled);
                //var directory = pathRegex.Replace(Directory.GetCurrentDirectory(), String.Empty);
                //var newstring = directory.Replace("\\", "/");
                //usersModel.Avatar = newstring + "/Uploads/" + item.Avatar;
                UsersDetailsOC.Add(usersModel);
            }
            
        }
    }
}
