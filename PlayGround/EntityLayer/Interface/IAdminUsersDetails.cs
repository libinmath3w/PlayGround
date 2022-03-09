using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Interface
{
    public interface IAdminUsersDetails
    {
        List<UsersModel> GetAdminUsersDetails();
        void UserBan(UsersModel usersModel);
        void UserApprove(UsersModel usersModel);
        void UserUnban(UsersModel usersModel);
        void UserMakeAsAdmin(UsersModel usersModel);
        List<UsersModel> SearchUsersDetails(UsersModel usersModel);
    }
}
