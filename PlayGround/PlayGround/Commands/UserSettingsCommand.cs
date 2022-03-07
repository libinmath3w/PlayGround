using BusinessLayer;
using EntityLayer;
using Microsoft.Win32;
using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PlayGround.Commands
{
    public class UserSettingsCommand : ICommand
    {
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
                UsersModel usersModel = new UsersModel();
                usersModel.UserId = 2;
                usersModel.Name = userSettingsViewModels.Name;
                usersModel.UserEmailID = userSettingsViewModels.Emailid;
                usersModel.PhoneNumber = userSettingsViewModels.PhoneNumber;
                usersModel.City = userSettingsViewModels.City;
                usersModel.State = userSettingsViewModels.State;
                usersModel.Zip = userSettingsViewModels.Zip;
                UserSettingsBusinessModel userSettingsBusinessModel = new UserSettingsBusinessModel();
                userSettingsBusinessModel.SaveUserDetails(usersModel);
                System.Windows.MessageBox.Show("Data Updated");
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
                            usersModel.UserId = 2;
                            UserSettingsBusinessModel userSettingsBusinessModel = new UserSettingsBusinessModel();
                            userSettingsBusinessModel.SaveAvatar(usersModel);
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
    }
}
