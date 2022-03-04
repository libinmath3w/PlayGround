using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class UserSignUpData
    {
        public void SaveSignUpData(UsersModel userModel)
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
            user.Role_ID = 2;
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
