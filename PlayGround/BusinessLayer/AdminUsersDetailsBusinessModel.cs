using DataAccessLibrary;
using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AdminUsersDetailsBusinessModel : IAdminUsersDetails
    {
        AdminViewUserDetailsData adminViewUserDetailsData = new AdminViewUserDetailsData();
        public List<UsersModel> GetAdminUsersDetails()
        {
            return adminViewUserDetailsData.GetAdminUsersDetails();
        }

        public List<UsersModel> SearchUsersDetails(UsersModel usersModel)
        {
            return adminViewUserDetailsData.SearchUsersDetails(usersModel);
        }

        public void UserApprove(UsersModel usersModel)
        {
            adminViewUserDetailsData.UserApprove(usersModel);
        }

        public void UserBan(UsersModel usersModel)
        {
            adminViewUserDetailsData.UserBan(usersModel);
        }

        public void UserMakeAsAdmin(UsersModel usersModel)
        {
            adminViewUserDetailsData.UserMakeAsAdmin(usersModel);
        }

        public void UserUnban(UsersModel usersModel)
        {
            adminViewUserDetailsData.UserUnban(usersModel);
        }
    }
}
