using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround.ViewModel
{
    public class UserTurfBookingViewModel : BaseViewModel
    {
        private List<BookingModel> _viewUserTurfBookingsAndBookNew;
        public List<BookingModel> ViewUserTurfBokkingsAndBookNew { get => _viewUserTurfBookingsAndBookNew; set => _viewUserTurfBookingsAndBookNew = value; }
        public UserBookingHistoryBusinessModel userBookingHistoryBusinessModel = new UserBookingHistoryBusinessModel();
        public UserTurfBookingViewModel(BookingModel bookingModel)
        {
            bookingModel.UserID = 2;
            _viewUserTurfBookingsAndBookNew = userBookingHistoryBusinessModel.GetBookingDetails(bookingModel);
        }
    }
}
