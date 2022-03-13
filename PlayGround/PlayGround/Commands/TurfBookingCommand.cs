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
                userNewTurfBookingViewModel.TurfSearchDetails = new System.Collections.ObjectModel.ObservableCollection<TurfModel>();
                string SearchTerm = userNewTurfBookingViewModel.SearchTerm;
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                    turfModel.TurfCity = SearchTerm;
                    var query = userTurfBookingBusinessModel.GetTurfDetails(turfModel);
                    foreach (var item in query)
                    {
                        TurfModel turfModels = new TurfModel();
                        turfModels.TurfName = item.TurfName;
                        turfModels.StartTime = item.StartTime;
                        turfModels.EndTime = item.EndTime;
                        turfModels.TurfLocation = item.TurfCity;
                        turfModels.TurfPrice = item.TurfPrice;
                        turfModels.TurfID = item.TurfID;
                        turfModels.TurfState = item.TurfState;
                        turfModels.TurfType = item.TurfType;
                        userNewTurfBookingViewModel.TurfSearchDetails.Add(turfModels);
                    }
                }
                else
                {
                    MessageBox.Show("Enter a Location");
                }
                
            }
            else if (parameter.ToString() =="BookNow")
            {
                UserTurfBookingBusinessModel userTurfBookingBusinessModel = new UserTurfBookingBusinessModel();
                BookingModel bookingModel = new BookingModel();
                bookingModel.UserID = userNewTurfBookingViewModel.UserID;
                bookingModel.BookingDateTime = userNewTurfBookingViewModel.BookingDate;
                bookingModel.BookingTime = DateTime.Now;
                bookingModel.TurfID = userNewTurfBookingViewModel.SelectedTurf.TurfID;
                bookingModel.BookingStartTime = userNewTurfBookingViewModel.OpeningTime.TimeID;
                bookingModel.BookingEndTime = userNewTurfBookingViewModel.ClosingTime.TimeID;
                bookingModel.BookingStatus = 2;
                int bookingamountdiff = userNewTurfBookingViewModel.ClosingTime.TimeID - userNewTurfBookingViewModel.OpeningTime.TimeID;
                bookingModel.Amount = bookingamountdiff * userNewTurfBookingViewModel.SelectedTurf.TurfPrice;
                bookingModel.PaymentID = userNewTurfBookingViewModel.TypeOfPayment.PaymentID;
                bookingModel.PaymentStatusInt = 0;
                userTurfBookingBusinessModel.BookTurf(bookingModel);
                MessageBox.Show("Booking is Completed. Please Wait for Admin Approval");
            }
            else if (parameter.ToString() == "TurfID")
            {
                
            }
            
        }
    }
}
