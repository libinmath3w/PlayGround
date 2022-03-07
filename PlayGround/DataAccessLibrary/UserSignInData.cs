using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLibrary
{
    public class UserSignInData
    {
        public List<UsersModel> SaveSignInData(UsersModel userModel)
        {
            List<UsersModel> UserLoginResultList = new List<UsersModel>();
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                User user = new User();
                var query = from UserDetails in turfManagementDBEntities.Users
                            where UserDetails.UserName == userModel.UserName && UserDetails.Password == userModel.Password
                            select UserDetails;
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        userModel.RoleID = item.Role_ID;
                        userModel.Status = item.Status;
                        userModel.UserMatch = 1;
                        UserLoginResultList.Add(userModel);
                    }
                }
                else
                {
                    userModel.UserMatch = 0;
                    UserLoginResultList.Add(userModel);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserLoginResultList;
        }  
    }
}
