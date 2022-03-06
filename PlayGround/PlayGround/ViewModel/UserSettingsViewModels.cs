using BusinessLayer;
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
    public class UserSettingsViewModels : BaseViewModel
    {
        private int _userID;
        private string _name;
        private string _emailid;
        private string _phoneNumber;
        private string _city;
        private string _state;
        private string _zip;
        private string _avatar;


        public ICommand UserSettingsCommands { get; set; }
        public UserSettingsViewModels userSettingsViewModels { get; set; }
        public int UserID { get => _userID; set { _userID = value; onPropertyChanged("User ID"); } }
        public string Name { get => _name; set { _name = value; onPropertyChanged("Name"); } }
        public string Emailid { get => _emailid; set { _emailid = value; onPropertyChanged("Email ID"); } }
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; onPropertyChanged("Phone Number"); } }
        public string City { get => _city; set { _city = value; onPropertyChanged("City"); } }
        public string State { get => _state; set { _state = value; onPropertyChanged("State"); } }
        public string Zip { get => _zip; set { _zip = value; onPropertyChanged("Zip"); } }
        public string Avatar { get => _avatar; set { _avatar = value; onPropertyChanged("Avatar"); } }
        public UserSettingsViewModels(UsersModel usersModel)
        {
            UserSettingsBusinessModel userSettingsBusinessModel = new UserSettingsBusinessModel();
            UserSettingsCommands = new UserSettingsCommand(this);
            UsersModel users = new UsersModel();
            users.UserId = usersModel.UserId;
            var query = userSettingsBusinessModel.GetUserDetails(users);
            foreach (var item in query)
            {
                Name = item.Name;
                Emailid = item.UserEmailID;
                PhoneNumber = item.PhoneNumber;
                City = item.City;
                State = item.State;
                Zip = item.Zip;
                Avatar = item.Avatar;
            }
        }
    }
}
