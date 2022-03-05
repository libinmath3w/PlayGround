using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class UserSettingsData : IUserSettings
    {
        public List<UsersModel> GetUserDetails(UsersModel usersModel)
        {
            List<UsersModel> UserSettingsResult = new List<UsersModel>();

            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from userdetails in turfManagementDBEntities.Users
                            where userdetails.ID.Equals(usersModel.UserId)
                            select userdetails;
                foreach (var item in query)
                {
                    UsersModel usersModels = new UsersModel();
                    usersModels.UserId = item.ID;
                    usersModels.UserName = item.UserName;
                    usersModels.Name = item.Name;
                    usersModels.UserEmailID = item.Email;
                    usersModels.PhoneNumber = item.PhoneNumber;
                    usersModels.Password = item.Password;
                    usersModels.Status = item.Status;
                    usersModels.DateOfCreatedAccount = (DateTime)item.Date_Of_Created_Account;
                    usersModels.RoleID = item.Role_ID;
                    usersModels.City = item.City;
                    usersModels.State = item.State;
                    // usersModels.Zip = item.Zip;
                    usersModels.Avatar = item.Avatar;
                    UserSettingsResult.Add(usersModels);
                }
            }
            catch (Exception ex)
            { 


                throw ex;
            }
            return UserSettingsResult;
        }
           public void SaveUserDetails(UsersModel usersModel)
           {
               TurfManagementDBEntities entities = new TurfManagementDBEntities();
               User users = new User();
               users.UserName = usersModel.UserName;
               users.Name = usersModel.Name;
               users.Email = usersModel.UserEmailID;
               users.PhoneNumber = usersModel.PhoneNumber;
               users.Password = usersModel.Password;
               users.Status = usersModel.Status;
               users.Date_Of_Created_Account = usersModel.DateOfCreatedAccount;
               users.Role_ID = usersModel.RoleID;
               users.City = usersModel.City;
               users.State = usersModel.State;
               users.Zip = usersModel.Zip;
               users.Avatar = usersModel.Avatar;
               entities.Users.Add(users);
               entities.SaveChanges();
           }
    }
}

