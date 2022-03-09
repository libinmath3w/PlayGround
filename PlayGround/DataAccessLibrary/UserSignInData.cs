using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using EntityLayer.Interface;

namespace DataAccessLibrary
{
    public class UserSignInData : IUserLogin
    {
        public List<UsersModel> GetSignInDetails(UsersModel userModel)
        {
            List<UsersModel> UserLoginResultList = new List<UsersModel>();
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from UserDetails in turfManagementDBEntities.Users
                            where UserDetails.UserName == userModel.UserName
                            select UserDetails;
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        UsersModel user = new UsersModel();
                        user.UserId = item.ID;
                        user.Password = item.Password;
                        user.RoleID = item.Role_ID;
                        user.Status = item.Status;
                        user.UserMatch = 1;
                        UserLoginResultList.Add(user);
                    }
                }
                else
                {
                    UsersModel user = new UsersModel();
                    user.UserMatch = 0;
                    UserLoginResultList.Add(user);

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
