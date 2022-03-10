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
    public class AddNewTurfCommand : ICommand
    {
      
        public event EventHandler CanExecuteChanged;
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

                AdminAddNewTurfViewModel adminAddNewTurfViewModel = new AdminAddNewTurfViewModel();
                TimeSloteModel timeSloteModel = new TimeSloteModel();
                
                MessageBox.Show(this.adminAddNewTurfViewModel.StartingTime.ToString());
                
               // startId = adminAddNewTurfViewModel.StartingTime                
                

                //foreach (var item in result)
                //{
                //    timeSloteModel.TimeID = item.TimeID;
                //    adminAddNewTurfViewModel.TurfStartingTime.Add(timeSloteModel);
                //}
                //foreach (var item in query)
                //{
                //    timeSloteModel.TimeID = item.TimeID;
                //    adminAddNewTurfViewModel.TurfEndingTime.Add(timeSloteModel);
                //}

            }
        }
       
    }
}
