using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer
{
        public interface IAdminBookingHistory
        {
            List<BookingModel> GetBookingDetails ();
            List<BookingModel> SearchBookingDetails (BookingModel bookingModel);
            void ApproveBooking (BookingModel bookingModel);
            void RejectBooking (BookingModel bookingModel);
            void ApprovePayment(BookingModel bookingModel);
        }
    
}
