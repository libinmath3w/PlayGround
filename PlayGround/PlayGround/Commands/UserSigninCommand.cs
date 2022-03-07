using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BusinessLayer;
using PlayGround.ViewModel;
using System.Windows.Controls;
using EntityLayer;
using PlayGround.View;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows;

namespace PlayGround.Commands
{
    public class UserSigninCommand : ICommand
    {
        public string Password { get; set; }
        public int RoleID { get; set; }

        public event EventHandler CanExecuteChanged;
        public string UserNames { get; set; }
        public UserLoginViewModel userLoginViewModel { get; set; }
        public UserSigninCommand(UserLoginViewModel userLoginViewModels)
        {
            userLoginViewModel = userLoginViewModels;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PasswordBox boxpass = (PasswordBox)parameter;
            Password = boxpass.Password;
            UserNames = userLoginViewModel.UserName;
            if (Password != null && UserNames != null && Password.Length > 0 && UserNames.Length > 0)
            {
                UsersModel model = new UsersModel();
                model.UserName = UserNames;
                UserSignInBusinessModel userSignInBusinessModel = new UserSignInBusinessModel();
                var query = userSignInBusinessModel.GetSignInDetails(model);
                foreach (var item in query)
                {
                    if(item.UserMatch == 1)
                    {
                        if (Password == Unprotect(item.Password))
                        {
                            if (item.Status == 1)
                            {
                                if (item.RoleID == 2) 
                                {
                                    UsersModel usersModel = new UsersModel();
                                    usersModel.UserId = item.UserId;
                                    var newForm = new MainWindow(usersModel); //create your new form.
                                    UserLoginView userLoginView = new UserLoginView();
                                    userLoginView.CloseLoginPage();
                                    newForm.Show(); //show the new form.
                                    userLoginViewModel.CloseWindow(userLoginView); //Added call to CloseWindow Method
                                } 
                                else if (item.RoleID == 1)
                                {
                                    UsersModel usersModel = new UsersModel();
                                    usersModel.UserId = item.UserId;
                                    var newForm = new AdminMainWindowView(); //create your new form.
                                    newForm.Show(); //show the new form.
                                }
                            }
                            else
                                MessageBox.Show("You are Banned :)");
                        }
                        else
                        {
                            MessageBox.Show("Invalid Password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username");
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Enter Both Fileds");
            }
            UserLoginView userLoginViews = new UserLoginView();
            userLoginViews.CloseLoginPage();
        }
        public void GetUserName(string name)
        {
            if (name != null)
                UserNames = name;
        }
        public static string Unprotect(string str)
        {
            byte[] protectedData = Convert.FromBase64String(str);
            byte[] entropy = Encoding.ASCII.GetBytes(Assembly.GetExecutingAssembly().FullName);
            string data = Encoding.ASCII.GetString(ProtectedData.Unprotect(protectedData, entropy, DataProtectionScope.CurrentUser));
            return data;
        }

        public static bool isValidUserName(string UserName)
        {
            UsersModel usersModel = new UsersModel();
            UserSignUpBusinessModel userSignUpBusinessModel = new UserSignUpBusinessModel();
            usersModel.UserName = UserName;
            bool value = userSignUpBusinessModel.GetUserNameInfo(usersModel);
            return value;
        }
    }
}
