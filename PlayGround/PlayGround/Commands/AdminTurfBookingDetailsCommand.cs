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
    public class AdminTurfBookingDetailsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public AdminTurfBookingHistoryViewModel adminTurfBookingHistoryViewModel { get; set; }
        public AdminTurfBookingDetailsCommand(AdminTurfBookingHistoryViewModel adminTurfBookingHistoryViewModels)
        {
           adminTurfBookingHistoryViewModel = adminTurfBookingHistoryViewModels;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "BookingSearch")
            {
                    string SearchValue = adminTurfBookingHistoryViewModel.SearchName;
                    if (string.IsNullOrEmpty(SearchValue))
                    {
                        MessageBox.Show("Enter a search keyword");
                        adminTurfBookingHistoryViewModel.getTurfBookingDetails();
                    }
                    else
                    {
                        BookingModel bookingModel = new BookingModel();
                        AdminBookingHistoryBusinessModel adminBookingHistoryBusinessModel = new AdminBookingHistoryBusinessModel();
                        bookingModel.Name = SearchValue;
                        adminTurfBookingHistoryViewModel.ViewAdminTurfBookingsAndBookNew = new List<BookingModel>();
                        adminTurfBookingHistoryViewModel.ViewAdminTurfBookingsAndBookNew = adminBookingHistoryBusinessModel.SearchBookingDetails(bookingModel);
                    }
            }
            else if (parameter.ToString() == "ApproveBooking")
            {
                 string BookingIDInfo = adminTurfBookingHistoryViewModel.FindBookingID;
                if (string.IsNullOrEmpty(BookingIDInfo))
                {
                    MessageBox.Show("Enter a Booking ID");
                    adminTurfBookingHistoryViewModel.getTurfBookingDetails();
                }
                else
                {
                    BookingModel bookingModel = new BookingModel();
                    AdminBookingHistoryBusinessModel adminBookingHistoryBusinessModel = new AdminBookingHistoryBusinessModel();
                    bookingModel.BookingID = Convert.ToInt32(BookingIDInfo);
                    adminBookingHistoryBusinessModel.ApproveBooking(bookingModel);
                    adminTurfBookingHistoryViewModel.getTurfBookingDetails();
                }
            }
            else if (parameter.ToString() == "RejectBooking")
            {
                string BookingIDInfo = adminTurfBookingHistoryViewModel.FindBookingID;
                if (string.IsNullOrEmpty(BookingIDInfo))
                {
                    MessageBox.Show("Enter a Booking ID");
                    adminTurfBookingHistoryViewModel.getTurfBookingDetails();
                }
                else
                {
                    BookingModel bookingModel = new BookingModel();
                    AdminBookingHistoryBusinessModel adminBookingHistoryBusinessModel = new AdminBookingHistoryBusinessModel();
                    bookingModel.BookingID = Convert.ToInt32(BookingIDInfo);
                    adminBookingHistoryBusinessModel.RejectBooking(bookingModel);
                    adminTurfBookingHistoryViewModel.getTurfBookingDetails();
                }
            }
            else if (parameter.ToString() == "PaymentApproved")
            {
                string BookingIDInfo = adminTurfBookingHistoryViewModel.FindBookingID;
                if (string.IsNullOrEmpty(BookingIDInfo))
                {
                    MessageBox.Show("Enter a Booking ID");
                    adminTurfBookingHistoryViewModel.getTurfBookingDetails();
                }
                else
                {
                    BookingModel bookingModel = new BookingModel();
                    AdminBookingHistoryBusinessModel adminBookingHistoryBusinessModel = new AdminBookingHistoryBusinessModel();
                    bookingModel.BookingID = Convert.ToInt32(BookingIDInfo);
                    adminBookingHistoryBusinessModel.ApprovePayment(bookingModel);
                    adminTurfBookingHistoryViewModel.getTurfBookingDetails();
                }
            }
        }
    }
}
