using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlayGround.ViewModel
{
    public class UserDashboardViewModel : BaseViewModel
    {
        public UsersModel Users { get; set; }
        public UserDashboardViewModel(UsersModel usersModel)
        {
            Users.UserId = usersModel.UserId;
        }
    }
}
