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


        public ICommand UserSettingsCommands;

        public int UserID { get => _userID; set { _userID = value; onPropertyChanged("User ID"); } }
        public string Name { get => _name; set { _name = value; onPropertyChanged("Name"); } }
        public string Emailid { get => _emailid; set { _emailid = value; onPropertyChanged("Email ID"); } }
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; onPropertyChanged("Phone Number"); } }
        public string City { get => _city; set { _city = value; onPropertyChanged("City"); } }
        public string State { get => _state; set { _state = value; onPropertyChanged("State"); } }
        public string Zip { get => _zip; set { _zip = value; onPropertyChanged("Zip"); } }

        public UserSettingsViewModels()
        {
            UserSettingsCommands = new UserSettingsCommand(this);
        }
    }
}
