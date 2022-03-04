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
        private List<BookingModel> _viewUserTurfBokkingsAndBookNew;
        public List<BookingModel> ViewUserTurfBokkingsAndBookNew { get => _viewUserTurfBokkingsAndBookNew; set => _viewUserTurfBokkingsAndBookNew = value; }
        public UserBookingHistoryBusinessModel userBookingHistoryBusinessModel = new UserBookingHistoryBusinessModel();
        public UserTurfBookingViewModel(BookingModel bookingModel)
        {
            bookingModel.UserID = 2;
            _viewUserTurfBokkingsAndBookNew = userBookingHistoryBusinessModel.GetBookingDetails(bookingModel);
        }
    }
}
