using BusinessLayer;
using EntityLayer;
using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlayGround.Commands
{
    public class AdminUserDetailsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public AdminUserDashboardViewModel adminUserDashboardViewModel { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public AdminUserDetailsCommand(AdminUserDashboardViewModel adminUserDashboardViewModels)
        {
            adminUserDashboardViewModel = adminUserDashboardViewModels;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Search")
            {
                string SearchValue = adminUserDashboardViewModel.SearchName;
                if (string.IsNullOrEmpty(SearchValue))
                {
                    MessageBox.Show("Enter a search keyword");
                    adminUserDashboardViewModel.GetUsersList();
                }
                else
                {
                    UsersModel usersModels = new UsersModel();
                    AdminUsersDetailsBusinessModel adminUsersDetailsBusinessModel = new AdminUsersDetailsBusinessModel();
                    usersModels.Name = SearchValue;
                    var query = adminUsersDetailsBusinessModel.SearchUsersDetails(usersModels);
                    adminUserDashboardViewModel.UsersDetailsOC = new System.Collections.ObjectModel.ObservableCollection<UsersModel>();
                    foreach (var item in query)
                    {
                        UsersModel usersModel = new UsersModel();
                        usersModel.UserId = item.UserId;
                        usersModel.Name = item.Name;
                        usersModel.UserName = item.UserName;
                        usersModel.UserEmailID = item.UserEmailID;
                        usersModel.PhoneNumber = item.PhoneNumber;
                        usersModel.City = item.City;
                        if (item.Status == 1)
                            usersModel.StatusName = "Active";
                        else if (item.Status == 0)
                            usersModel.StatusName = "Pending";
                        else
                            usersModel.StatusName = "Banned";
                        usersModel.State = item.State;
                        usersModel.Zip = item.Zip;
                        if (item.RoleID == 1)
                            usersModel.RoleName = "Admin";
                        else if (item.RoleID == 2)
                            usersModel.RoleName = "User";
                        usersModel.RoleID = item.RoleID;
                        usersModel.DateOfCreatedAccountTime = item.DateOfCreatedAccountTime;
                        adminUserDashboardViewModel.UsersDetailsOC.Add(usersModel);
                    }
                }
            }
            else if (parameter.ToString() == "UserBan")
            {
                string UserIDInfo = adminUserDashboardViewModel.FindUserID;
                if (string.IsNullOrEmpty(UserIDInfo))
                {
                    MessageBox.Show("Enter a User ID");
                    adminUserDashboardViewModel.GetUsersList();
                }
                else
                {
                    UsersModel usersModels = new UsersModel();
                    AdminUsersDetailsBusinessModel adminUsersDetailsBusinessModel = new AdminUsersDetailsBusinessModel();
                    usersModels.UserId = Convert.ToInt32(UserIDInfo);
                    adminUsersDetailsBusinessModel.UserBan(usersModels);
                    adminUserDashboardViewModel.GetUsersList();
                }
            }
            else if (parameter.ToString() == "UserUnBan")
            {
                string UserIDInfo = adminUserDashboardViewModel.FindUserID;
                if (string.IsNullOrEmpty(UserIDInfo))
                {
                    MessageBox.Show("Enter a User ID");
                    adminUserDashboardViewModel.GetUsersList();
                }
                else
                {
                    UsersModel usersModels = new UsersModel();
                    AdminUsersDetailsBusinessModel adminUsersDetailsBusinessModel = new AdminUsersDetailsBusinessModel();
                    usersModels.UserId = Convert.ToInt32(UserIDInfo);
                    adminUsersDetailsBusinessModel.UserUnban(usersModels);
                    adminUserDashboardViewModel.GetUsersList();
                }
            }
            else if (parameter.ToString() == "MakeUserAsAdmin")
            {
                string UserIDInfo = adminUserDashboardViewModel.FindUserID;
                if (string.IsNullOrEmpty(UserIDInfo))
                {
                    MessageBox.Show("Enter a User ID");
                    adminUserDashboardViewModel.GetUsersList();
                }
                else
                {
                    UsersModel usersModels = new UsersModel();
                    AdminUsersDetailsBusinessModel adminUsersDetailsBusinessModel = new AdminUsersDetailsBusinessModel();
                    usersModels.UserId = Convert.ToInt32(UserIDInfo);
                    adminUsersDetailsBusinessModel.UserMakeAsAdmin(usersModels);
                    adminUserDashboardViewModel.GetUsersList();
                }
            }
            else if (parameter.ToString() == "Approve")
            {
                string UserIDInfo = adminUserDashboardViewModel.FindUserID;
                if (string.IsNullOrEmpty(UserIDInfo))
                {
                    MessageBox.Show("Enter a User ID");
                    adminUserDashboardViewModel.GetUsersList();
                }
                else
                {
                    UsersModel usersModels = new UsersModel();
                    AdminUsersDetailsBusinessModel adminUsersDetailsBusinessModel = new AdminUsersDetailsBusinessModel();
                    usersModels.UserId = Convert.ToInt32(UserIDInfo);
                    adminUsersDetailsBusinessModel.UserApprove(usersModels);
                    adminUserDashboardViewModel.GetUsersList();
                }
            }
        }
    }
}
