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
    public class AdminSettingsData : IUserSettings
    {
        public List<UsersModel> GetUserDetails(UsersModel usersModel)
        {
            List<UsersModel> AdminSettingsResult = new List<UsersModel>();

            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                //var query = from admindetails in turfManagementDBEntities.Users
                //            where admindetails.ID == usersModel.UserId
                //            select admindetails;

                var result = turfManagementDBEntities.Users.Where(x => x.ID == usersModel.UserId);
                foreach (var item in result)
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
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                //var query = from userinfo in turfManagementDBEntities.Users
                //            where userinfo.ID == usersModel.UserId
                //            select userinfo;
                
                /** Linq in lambda **/

                var query = turfManagementDBEntities.Users.Where(i => i.ID == usersModel.UserId);

                foreach (var item in query)
                {
                    item.Email = usersModel.UserEmailID;
                    item.Name = usersModel.Name;
                    item.PhoneNumber = usersModel.PhoneNumber;
                }
                turfManagementDBEntities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public void SaveAvatar(UsersModel usersModel)
        {
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                //var query = from userinfo in turfManagementDBEntities.Users
                //            where userinfo.ID == usersModel.UserId
                //            select userinfo;
                /** moved to lambda **/

                var result = turfManagementDBEntities.Users.Where(x => x.ID == usersModel.UserId);
                foreach (var item in result)
                {
                    item.Avatar = usersModel.Avatar;
                }
                turfManagementDBEntities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UsersModel> GetUserPasswordDetails(UsersModel usersModel)
        {
            List<UsersModel> adminSettingsResultList = new List<UsersModel>();
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                //var query = from userdetails in turfManagementDBEntities.Users
                //            where userdetails.ID.Equals(usersModel.UserId)
                //            select userdetails;

                var query = turfManagementDBEntities.Users.Where(x => x.ID.Equals(usersModel.UserId));
                foreach (var item in query)
                {
                    UsersModel users = new UsersModel();
                    users.Password = item.Password;
                    adminSettingsResultList.Add(users);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return adminSettingsResultList;
        }

        public void UpdatePassword(UsersModel usersModel)
        {
            try
            {
                SqlConnection sqlConnection = null;
                sqlConnection = new SqlConnection("Data Source =.; Database = TurfManagementDB; Integrated Security=true;");
                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE USERS SET PASSWORD = '" + usersModel.Password + "' WHERE ID = " + usersModel.UserId, sqlConnection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
