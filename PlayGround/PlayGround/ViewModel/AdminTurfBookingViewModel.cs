using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using EntityLayer;

namespace PlayGround.ViewModel
{
    public class AdminTurfBookingViewModel : BaseViewModel
    {
        private List<BookingModel> _viewAdminTurfBookingsAndBookNew;
        public List<BookingModel> ViewUserTurfBokkingsAndBookNew { get => _viewAdminTurfBookingsAndBookNew; set => _viewAdminTurfBookingsAndBookNew = value; }
        public AdminBookingHistoryBusinessModel adminBookingHistoryBusinessModel = new AdminBookingHistoryBusinessModel();
        public AdminTurfBookingViewModel(BookingModel bookingModel)
        {
            bookingModel.UserID = 2;
            _viewAdminTurfBookingsAndBookNew = adminBookingHistoryBusinessModel.GetBookingDetails(bookingModel);
        }
    }
}
