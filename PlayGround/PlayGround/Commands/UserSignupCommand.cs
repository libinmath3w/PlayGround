using BusinessLayer;
using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using EntityLayer;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Security.Cryptography;

namespace PlayGround.Commands
{
    public class UserSignupCommand : ICommand
    {
        public string Password { get; set; }
       

        public event EventHandler CanExecuteChanged;
        public UserRegistrationViewModel UserRegistrationViewModel { get; set; }
        public UserSignupCommand(UserRegistrationViewModel userRegistrationViewModel)
        {
            UserRegistrationViewModel = userRegistrationViewModel;
        }

        public UserSignupCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "userSignUp")
            {
                string Name = UserRegistrationViewModel.Name;
                string UserName = UserRegistrationViewModel.UserName;
                string UserEmailID = UserRegistrationViewModel.UserEmailID;
                string PhoneNumber = UserRegistrationViewModel.PhoneNumber;
                if (string.IsNullOrEmpty(Name) && UserName != null && UserEmailID != null && PhoneNumber != null)
                {
                        if (!isValidEmail(UserEmailID))
                        {
                            MessageBox.Show("Invalid Email ID");
                        }
                        else
                        {
                            if (isEmailIDExists(UserEmailID) == true)
                            {
                                MessageBox.Show("Email ID Already Exists");
                            }
                            else
                            {
                                if (!isValidPhoneNumber(PhoneNumber))
                                {
                                    MessageBox.Show("Invalid Phone Number");
                                }
                                else
                                {
                                    if (PhoneNumber.Length == 10)
                                    {
                                        if (!isValidUserName(UserName))
                                        {
                                         if (!string.IsNullOrEmpty(UserName))
                                         {
                                            UsersModel usersModels = new UsersModel();
                                            UserSignUpBusinessModel userSignUpBusinessModels = new UserSignUpBusinessModel();
                                            usersModels.UserName = UserName;
                                            usersModels.Name = Name;
                                            usersModels.UserEmailID = UserEmailID;
                                            usersModels.PhoneNumber = PhoneNumber;
                                            usersModels.RoleID = 2;
                                            usersModels.Status = 0;
                                            string encrypass = Protect(PhoneNumber);
                                            usersModels.Password = encrypass;
                                            usersModels.DateOfCreatedAccount = DateTime.Now;
                                            usersModels.Avatar = "avatar.jpg";
                                            userSignUpBusinessModels.SaveSignUpDetails(usersModels);
                                            MessageBox.Show("Registration Successfull");
                                         }
                                         else
                                         {
                                            MessageBox.Show("Username is blank");
                                         }
                                        
                                        }
                                        else
                                        {
                                            MessageBox.Show("Username Already Exists");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Phone Number should be 10 digits");
                                    }
                                    
                                }
                            }
                        }

                }
                else
                {
                    System.Windows.MessageBox.Show("Enter all fields");
                }
                //PasswordBox boxpass = (PasswordBox)parameter;
                //Password = boxpass.Password;

                //if (Password.Length > 8)
                //{
                //    if (UserRegistrationViewModel.UserEmailID.Length > 0)
                //    {
                //        System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                //        if (!rEmail.IsMatch(UserRegistrationViewModel.UserEmailID))
                //        {
                //            MessageBox.Show("Invalid Email ID");

                //        }
                //    }
                //    System.Windows.MessageBox.Show("Password length too small");

                //}
                //else
                //{

                //}


            }
        }

        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        public static bool isValidPhoneNumber(string PhoneNumber)
        {
            string strRegex = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(PhoneNumber))
                return (true);
            else
                return (false);
        }
   
        public static bool isValidUserName(string UserName)
        {
            UsersModel usersModel = new UsersModel();
            UserSignUpBusinessModel userSignUpBusinessModel = new UserSignUpBusinessModel();
            usersModel.UserName = UserName;
            bool value = userSignUpBusinessModel.GetUserNameInfo(usersModel);
            return value;
        }

        public static bool isEmailIDExists(string inputEmail)
        {
            UsersModel usersModel = new UsersModel();
            UserSignUpBusinessModel userSignUpBusinessModel = new UserSignUpBusinessModel();
            usersModel.UserEmailID = inputEmail;
            return userSignUpBusinessModel.GetUserEmailInfo(usersModel);
        }
        public static string Protect(string str)
        {
            byte[] entropy = Encoding.ASCII.GetBytes(Assembly.GetExecutingAssembly().FullName);
            byte[] data = Encoding.ASCII.GetBytes(str);
            string protectedData = Convert.ToBase64String(ProtectedData.Protect(data, entropy, DataProtectionScope.CurrentUser));
            return protectedData;
        }
        public static string Unprotect(string str)
        {
            byte[] protectedData = Convert.FromBase64String(str);
            byte[] entropy = Encoding.ASCII.GetBytes(Assembly.GetExecutingAssembly().FullName);
            string data = Encoding.ASCII.GetString(ProtectedData.Unprotect(protectedData, entropy, DataProtectionScope.CurrentUser));
            return data;
        }
    }
}
