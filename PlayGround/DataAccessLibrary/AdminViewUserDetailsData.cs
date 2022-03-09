using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class AdminViewUserDetailsData : IAdminUsersDetails
    {
        public List<UsersModel> GetAdminUsersDetails()
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
                    usersModels.State = item.State;
                    usersModels.RoleID = item.Role_ID;
                    var TempDate = (DateTime)item.Date_Of_Created_Account;
                    usersModels.DateOfCreatedAccountTime = TempDate.ToShortDateString();
                    usersModels.City = item.City;
                    usersModels.PhoneNumber = item.PhoneNumber;
                    usersModels.Status = item.Status;
                    usersModels.Zip = item.Zip;
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
