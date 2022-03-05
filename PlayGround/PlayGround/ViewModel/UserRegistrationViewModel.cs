using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround.ViewModel
{
    public class UserRegistrationViewModel : BaseViewModel
    {
        private string _username;
        private string _name;
        private string _userEmailID;
        private string _phoneNumber;
        private string _password;
        public string UserName { get => _username; set { _username = value; onPropertyChanged("User Name"); } }
        public string Name { get => _name; set { _name = value; onPropertyChanged(" Name"); } }
        public string UserEmailID { get => _userEmailID; set { _userEmailID = value; onPropertyChanged("User EmailID"); } }
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; onPropertyChanged("Phone Number"); } }
        public string Password { get => _password; set { _password = value; onPropertyChanged("Password"); } }
    }
}
