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
    public class TurfBookingCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public UserNewTurfBookingViewModel userNewTurfBookingViewModel { get; set; }

        public TurfBookingCommand(UserNewTurfBookingViewModel usernewTurfBookingViewModel)
        {
            userNewTurfBookingViewModel = usernewTurfBookingViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Search")
            {
                UserTurfBookingBusinessModel userTurfBookingBusinessModel = new UserTurfBookingBusinessModel();
                TurfModel turfModel = new TurfModel();
                turfModel.TurfCity = userNewTurfBookingViewModel.SearchTerm;
                var query = userTurfBookingBusinessModel.GetTurfDetails(turfModel);
                foreach (var item in query)
                {
                    turfModel.TurfName = item.TurfName;
                    turfModel.StartTime = item.StartTime;
                    turfModel.EndTime = item.EndTime;
                    turfModel.TurfLocation = item.TurfCity;
                    turfModel.TurfPrice = item.TurfPrice;
                    turfModel.TurfID = item.TurfID;
                    turfModel.TurfState = item.TurfState;
                    turfModel.TurfType = item.TurfType;
                    userNewTurfBookingViewModel.TurfSearchDetails.Add(turfModel);
                }
            }
            else if (parameter.ToString() =="BookNow")
            {
                int UserID = userNewTurfBookingViewModel.UserID;
                MessageBox.Show(UserID.ToString());
                //MessageBox.Show(userNewTurfBookingViewModel.ClosingTime.TimeSlots.ToString());
                //MessageBox.Show(userNewTurfBookingViewModel.TypeOfPayment.PaymentMethod.ToString());
            }
            
        }
    }
}
