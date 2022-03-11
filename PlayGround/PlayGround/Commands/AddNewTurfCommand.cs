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
using System.Windows;
using System.Windows.Input;

namespace PlayGround.Commands
{
    public class AddNewTurfCommand : ICommand
    {
      
        public event EventHandler CanExecuteChanged;
        public string ImagePath { get; set; }
        public AdminAddNewTurfViewModel adminAddNewTurfViewModel { get; set; }
        public AddNewTurfCommand(AdminAddNewTurfViewModel adminAddNewTurfViewModels)
        {
            adminAddNewTurfViewModel = adminAddNewTurfViewModels;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "AddNewTurf")
            {
                string Name = adminAddNewTurfViewModel.TurfName;
                string City = adminAddNewTurfViewModel.TurfCity;
                string State = adminAddNewTurfViewModel.TurfState;
                string Zip = adminAddNewTurfViewModel.TurfZip;
                string price = adminAddNewTurfViewModel.TurfPrice;
                if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(State) && !string.IsNullOrEmpty(Zip) && !string.IsNullOrEmpty(price))
                {
                    if (!int.TryParse(price, out _))
                    {
                        MessageBox.Show("Price should be a number");
                    }
                    else
                    {
                        TurfModel model = new TurfModel();
                        model.TurfName = Name;
                        model.TurfCity = City;
                        model.TurfState = State;
                        model.Zip = Zip;
                        model.TurfPrice = float.Parse(price);
                        model.OpeningTime = adminAddNewTurfViewModel.TimeSlotStartTime.TimeID;
                        model.ClosingTime = adminAddNewTurfViewModel.TimeSlotEndTime.TimeID;
                        model.TurfCategoryID = adminAddNewTurfViewModel.TurfCategoryValue.TurfID;
                        if (!string.IsNullOrEmpty(ImagePath))
                            model.TurfImage = ImagePath;
                        else
                            model.TurfImage = "turf.jpg";

                    }
                }
                else
                {
                    MessageBox.Show("Enter value in all fields");
                }
            }
            else if (parameter.ToString() =="NewTurfImage")
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
                            ImagePath = fileNameToSave;
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
