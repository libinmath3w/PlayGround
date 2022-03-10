using BusinessLayer;
using EntityLayer;
using PlayGround.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayGround.ViewModel
{
    public class AdminTurfBookingHistoryViewModel : BaseViewModel
    {
        private string _search;
        private string _findbyid;
        private List<BookingModel> _viewAdminTurfBookingsAndBookNew;
        public string SearchName { get => _search; set { _search = value; onPropertyChanged("Search Name"); } }
        public string FindBookingID { get => _findbyid; set { _findbyid = value; onPropertyChanged("Find Booking ID"); } }
        public ICommand AdminTurfBookingDetailsCommands { get; set; }
        public List<BookingModel> ViewAdminTurfBookingsAndBookNew { get => _viewAdminTurfBookingsAndBookNew; set => _viewAdminTurfBookingsAndBookNew = value; }

        public AdminBookingHistoryBusinessModel adminBookingHistoryBusinessModel = new AdminBookingHistoryBusinessModel();
        public AdminTurfBookingHistoryViewModel()
        {
            AdminTurfBookingDetailsCommands = new AdminTurfBookingDetailsCommand(this);
            getTurfBookingDetails();
        }

        public void getTurfBookingDetails() => _viewAdminTurfBookingsAndBookNew = adminBookingHistoryBusinessModel.GetBookingDetails();
    }
}
