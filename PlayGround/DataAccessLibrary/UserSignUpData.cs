using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class UserSignUpData : IUserSignUp
    {
        public bool GetUserEmailInfo(UsersModel userModel)
        {
            bool UserEmailExists;
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from UserDetails in turfManagementDBEntities.Users
                            where UserDetails.Email == userModel.UserEmailID
                            select UserDetails;
                if (query.Count() > 0)
                    UserEmailExists = true;
                else
                    UserEmailExists = false;
            }
            catch (Exception)
            {
                throw;
            }
            return UserEmailExists;
        }

        public bool GetUserNameInfo(UsersModel userModel)
        {
            bool UserExists;
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from UserDetails in turfManagementDBEntities.Users
                            where UserDetails.UserName == userModel.UserName
                            select UserDetails;
                if (query.Count() > 0)
                    UserExists = true;
                else 
                    UserExists = false;

            }
            catch (Exception)
            {

                throw;
            }
            return UserExists;
        }

        public void SaveSignUpDetails(UsersModel userModel)
        {
            try
                { 
                    TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                    User user = new User();
                    user.UserName = userModel.UserName;
                    user.Name = userModel.Name;
                    user.Email = userModel.UserEmailID;
                    user.Password = userModel.Password;
                    user.PhoneNumber = userModel.PhoneNumber;
                    user.Status = userModel.Status;
                    user.Role_ID = userModel.RoleID;
                    user.Avatar = userModel.Avatar;
                    user.Date_Of_Created_Account = userModel.DateOfCreatedAccount;
                    turfManagementDBEntities.Users.Add(user);
                    turfManagementDBEntities.SaveChanges();
                }
                catch (Exception ex)
                  {
                    throw ex;
                  }
        }
    }
}
