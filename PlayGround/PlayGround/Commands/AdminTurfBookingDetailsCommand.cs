using BusinessLayer;
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
                        AdminBookingHistoryBusinessModel adminBookingHistoryBusinessModel = new AdminBookingHistoryBusinessModel();
                    }
                }
            }
            else if (parameter.ToString() == "ApproveBooking")
            {

            }
            else if (parameter.ToString() == "RejectBooking")
            {

            }
            else if (parameter.ToString() == "PaymentApproved")
            {

            }
        }
    }
}
