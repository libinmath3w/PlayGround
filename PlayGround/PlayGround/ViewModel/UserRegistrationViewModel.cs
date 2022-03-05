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
        public string UserName { get => _username; set { _username = value; onPropertyChanged("User Name"); } }
        public string Name { get; set; }
        public string UserEmailID { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
