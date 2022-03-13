using BusinessLayer;
using EntityLayer;
using Microsoft.Win32;
using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PlayGround.Commands
{
    public class UserSettingsCommand : ICommand
    {
        public string CurrentPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstPassword { get; set; }
        public string DecryptedPassword { get; set; }

        public event EventHandler CanExecuteChanged;
        public System.IO.Stream StreamSource { get; set; }
        public UserSettingsViewModels userSettingsViewModels { get; set; }
        public UserSettingsCommand(UserSettingsViewModels userSettingsViewModel)
        {
                userSettingsViewModels = userSettingsViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "SaveUserChanges")
            {
                string name = userSettingsViewModels.Name;
                string email = userSettingsViewModels.Emailid;
                string phone = userSettingsViewModels.PhoneNumber;
                string City = userSettingsViewModels.City;
                string State = userSettingsViewModels.State;
                string Zip = userSettingsViewModels.Zip;
                if (name != null && email != null && phone != null && City != null && State != null && Zip != null)
                {
                    if (!isValidEmail(email))
                    {
                        MessageBox.Show("Invalid Email ID");
                    }
                    else
                    {
                        if (!isValidPhoneNumber(phone))
                        {
                            MessageBox.Show("Invalid Phone Number");
                        }
                        else
                        {
                            if (phone.Length == 10)
                            {
                                UsersModel usersModel = new UsersModel();
                                usersModel.UserId = userSettingsViewModels.UserID;
                                usersModel.Name = userSettingsViewModels.Name;
                                usersModel.UserEmailID = userSettingsViewModels.Emailid;
                                usersModel.PhoneNumber = userSettingsViewModels.PhoneNumber;
                                usersModel.City = userSettingsViewModels.City;
                                usersModel.State = userSettingsViewModels.State;
                                usersModel.Zip = userSettingsViewModels.Zip;
                                UserSettingsBusinessModel userSettingsBusinessModel = new UserSettingsBusinessModel();
                                userSettingsBusinessModel.SaveUserDetails(usersModel);
                                MessageBox.Show("Profile Details Updated");
                            }
                            else
                            {
                                MessageBox.Show("Phone Number should be 10 digits");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter all fields");
                }
            }
            else if (parameter.ToString() == "UserBrowseImage")
            {
                try
                {
                    OpenFileDialog fd = new OpenFileDialog();
                    fd.Multiselect = false;
                    fd.Filter = "Image files (*.bmp, *.jpg, *.png)|*.bmp;*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
                    if (fd.ShowDialog() == true)
                    {
                        if (fd.CheckFileExists)
                        {
                            var fileNameToSave = GetTimestamp(DateTime.Now) + Path.GetExtension(fd.FileName);
                            var pathRegex = new Regex(@"\\bin(\\x86|\\x64)?\\(Debug|Release)$", RegexOptions.Compiled);
                            var directory = pathRegex.Replace(Directory.GetCurrentDirectory(), String.Empty);
                            var imagePath = Path.Combine(directory + @"\Uploads\" + fileNameToSave);
                            File.Copy(fd.FileName, imagePath);
                            UsersModel usersModel = new UsersModel();
                            usersModel.Avatar = fileNameToSave;
                            usersModel.UserId = userSettingsViewModels.UserID;
                            UserSettingsBusinessModel userSettingsBusinessModel = new UserSettingsBusinessModel();
                            userSettingsBusinessModel.SaveAvatar(usersModel);
                            MessageBox.Show("Avatar Updated");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var values = (object[])parameter;
                if (values != null)
                {
                    var passvalueOne = values[0];
                    var passvalueTwo = values[1];
                    var passvalueThree = values[2];
                    PasswordBox boxpass = (PasswordBox)passvalueOne;
                    CurrentPassword = boxpass.Password;
                    PasswordBox boxpasses = (PasswordBox)passvalueTwo;
                    FirstPassword = boxpasses.Password;
                    PasswordBox boxpasseses = (PasswordBox)passvalueThree;
                    ConfirmPassword = boxpasseses.Password;
                    UsersModel usersModel = new UsersModel();
                    usersModel.UserId = userSettingsViewModels.UserID;
                    UserSettingsBusinessModel userSettingsBusinessModel = new UserSettingsBusinessModel();
                    if (!string.IsNullOrEmpty(CurrentPassword) && !string.IsNullOrEmpty(FirstPassword) && !string.IsNullOrEmpty(ConfirmPassword))
                    {
                        if (FirstPassword == ConfirmPassword)
                        {
                            var query = userSettingsBusinessModel.GetUserPasswordDetails(usersModel);
                                foreach (var item in query)
                                {
                                    DecryptedPassword = Unprotect(item.Password);
                                }
                            if (DecryptedPassword == CurrentPassword)
                            {
                                if (DecryptedPassword == FirstPassword)
                                    MessageBox.Show("Old Password and new Password are Match. Try with New Password");
                                else
                                {
                                    usersModel.Password = Protect(FirstPassword);
                                    userSettingsBusinessModel.UpdatePassword(usersModel);
                                    MessageBox.Show("Password Updated");
                                }
                            }
                                
                            else
                                MessageBox.Show("Current Password is not match");
                        }
                        else
                            MessageBox.Show("Both Password Not Match");
                    }
                    else
                        MessageBox.Show("Enter All Password Fields");
                }
                else
                    MessageBox.Show("Enter Password");
            }
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
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
