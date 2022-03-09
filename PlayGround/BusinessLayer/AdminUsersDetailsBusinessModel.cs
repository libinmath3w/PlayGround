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
    }
}
