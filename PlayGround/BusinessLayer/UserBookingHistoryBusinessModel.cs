using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class UserBookingHistoryBusinessModel : IUserBookingHistory
    {
        public List<BookingModel> GetBookingDetails(BookingModel bookingModel)
        {
            UserBookingHistoryData userBookingHistoryData = new UserBookingHistoryData();
            return userBookingHistoryData.GetBookingDetails(bookingModel);
        }
    }
}
