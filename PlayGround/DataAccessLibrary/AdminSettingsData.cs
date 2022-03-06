using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class AdminSettingsData : IUserSettings
    {
        public List<UsersModel> GetUserDetails(UsersModel usersModel)
        {
            List<UsersModel> AdminSettingsResult = new List<UsersModel>();

            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from admindetails in turfManagementDBEntities.Users
                            
                            select admindetails;
                foreach (var item in query)
                {
                    UsersModel usersModels = new UsersModel();
                    usersModels.UserId = item.ID;
                    usersModels.Name = item.Name;
                    usersModels.UserEmailID = item.Email;
                    usersModels.PhoneNumber = item.PhoneNumber;
                    usersModels.Password = item.Password;
                    usersModels.Avatar = item.Avatar;
                    AdminSettingsResult.Add(usersModels);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AdminSettingsResult;
        }

        public void SaveNewTurf(TurfModel turfModel)
        {
            throw new NotImplementedException();
        }

        public List<TurfModel> GetNewTurf(TurfModel turfModel)
        {
            throw new NotImplementedException();
        }

        public void SaveUserDetails(UsersModel usersModel)
        {
            TurfManagementDBEntities entities = new TurfManagementDBEntities();
            User users = new User();
            users.Name = usersModel.Name;
            users.Email = usersModel.UserEmailID;
            users.PhoneNumber = usersModel.PhoneNumber;
            users.Password = usersModel.Password;
            users.Avatar = usersModel.Avatar;
            entities.Users.Add(users);
            entities.SaveChanges();
        }
    }
}
