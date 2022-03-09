using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

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

        public List<UsersModel> SearchUsersDetails(UsersModel usersModel)
        {
            List<UsersModel> AdminSearchViewUsersResult = new List<UsersModel>();
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = turfManagementDBEntities.Users
                            .Where(p => p.Name.Contains(usersModel.Name));
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
                    AdminSearchViewUsersResult.Add(usersModels);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AdminSearchViewUsersResult;
        }

        public void UserApprove(UsersModel usersModel)
        {
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from UsersInfo in turfManagementDBEntities.Users
                            where UsersInfo.ID == usersModel.UserId
                            select UsersInfo;
                if (query.Count() > 0)
                {
                    SqlConnection sqlConnection = null;
                    foreach (var item in query)
                    {
                        if (item.Status == 1)
                        {
                            MessageBox.Show("User is Already Approved");
                        } 
                        else if (item.Status == 0)
                        {
                            try
                            {
                                sqlConnection = new SqlConnection("Data Source =.; Database = TurfManagementDB; Integrated Security=true;");
                                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE USERS SET STATUS = 1 WHERE ID = " + usersModel.UserId, sqlConnection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                MessageBox.Show("User Approved");
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else
                        {
                            MessageBox.Show("User is Banned :)");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("No User Found");
                }

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UserBan(UsersModel usersModel)
        {
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from UsersInfo in turfManagementDBEntities.Users
                            where UsersInfo.ID == usersModel.UserId
                            select UsersInfo;
                if (query.Count() > 0)
                {
                    SqlConnection sqlConnection = null;
                    foreach (var item in query)
                    {
                        if (item.Status == 3)
                        {
                            MessageBox.Show("User is Already Banned");
                        }
                        else if (item.Status == 1 || item.Status == 0)
                        {
                            try
                            {
                                sqlConnection = new SqlConnection("Data Source =.; Database = TurfManagementDB; Integrated Security=true;");
                                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE USERS SET STATUS = 3 WHERE ID = " + usersModel.UserId, sqlConnection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                MessageBox.Show("User Banned");
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else
                        {
                            MessageBox.Show("User is not Banned :)");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("No User Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UserMakeAsAdmin(UsersModel usersModel)
        {
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from UsersInfo in turfManagementDBEntities.Users
                            where UsersInfo.ID == usersModel.UserId
                            select UsersInfo;
                if (query.Count() > 0)
                {
                    SqlConnection sqlConnection = null;
                    foreach (var item in query)
                    {
                        if (item.Role_ID == 1)
                        {
                            MessageBox.Show("User is Already Admin");
                        }
                        else if (item.Role_ID == 2 && item.Status == 1)
                        {
                            try
                            {
                                sqlConnection = new SqlConnection("Data Source =.; Database = TurfManagementDB; Integrated Security=true;");
                                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE USERS SET ROLE_ID = 1 WHERE ID = " + usersModel.UserId, sqlConnection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                MessageBox.Show("User is now Admin");
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else
                        {
                            MessageBox.Show("User is Banned and you can't make as admin:)");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("No User Found");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UserUnban(UsersModel usersModel)
        {
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from UsersInfo in turfManagementDBEntities.Users
                            where UsersInfo.ID == usersModel.UserId
                            select UsersInfo;
                if (query.Count() > 0)
                {
                    SqlConnection sqlConnection = null;
                    foreach (var item in query)
                    {
                        if (item.Status == 1 || item.Status == 0)
                        {
                            MessageBox.Show("User is not Banned");
                        }
                        else if (item.Status == 3)
                        {
                            try
                            {
                                sqlConnection = new SqlConnection("Data Source =.; Database = TurfManagementDB; Integrated Security=true;");
                                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE USERS SET STATUS = 1 WHERE ID = " + usersModel.UserId, sqlConnection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                MessageBox.Show("User unbanned");
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else
                        {
                            MessageBox.Show("User is not Banned :)");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("No User Found");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
