using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class AdminViewUserDetailsData
    {
        public List<UsersModel> GetAdminUsersDetails(UsersModel usersModel)
        {
            List<UsersModel> AdminViewUsersResult = new List<UsersModel>();
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from userdetails in turfManagementDBEntities.Users

                            select userdetails;
                foreach (var item in query)
                {
                    UsersModel usersModels = new UsersModel();
                    usersModels.UserId = item.ID;
                    usersModels.UserName = item.UserName;
                    usersModels.Name = item.Name;
                    usersModels.UserEmailID = item.Email;
                    usersModels.PhoneNumber = item.PhoneNumber;
                    usersModels.Avatar = item.Avatar;
                    AdminViewUsersResult.Add(usersModels);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AdminViewUsersResult;
        }
    }
}
