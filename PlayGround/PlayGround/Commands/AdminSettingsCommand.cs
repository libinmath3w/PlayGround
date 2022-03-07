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
using System.Windows.Input;

namespace PlayGround.Commands
{
    public class AdminSettingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public AdminSettingsViewModel adminSettingsViewModel { get; set; }
        public AdminSettingsCommand(AdminSettingsViewModel adminSettingsViewModels)
        {
            adminSettingsViewModel = adminSettingsViewModels;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "SaveUserChanges")
            {
                string name = adminSettingsViewModel.Name;
                string email = adminSettingsViewModel.Emailid;
                string phone = adminSettingsViewModel.PhoneNumber;
                if (name != null && email != null && phone != null)
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
                                usersModel.UserId = 1;
                                usersModel.Name = name;
                                usersModel.UserEmailID = email;
                                usersModel.PhoneNumber = phone;
                                AdminSettingsBusinessModel adminSettingsBusinessModel = new AdminSettingsBusinessModel();
                                adminSettingsBusinessModel.SaveUserDetails(usersModel);
                                MessageBox.Show("Profile Updated");
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
            else if (parameter.ToString() == "UpdatePassword")
            {

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
                            usersModel.UserId = 1;
                            AdminSettingsBusinessModel adminSettingsBusinessModel = new AdminSettingsBusinessModel();
                            adminSettingsBusinessModel.SaveAvatar(usersModel);
                            System.Windows.MessageBox.Show("Avatar Updated");
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
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
