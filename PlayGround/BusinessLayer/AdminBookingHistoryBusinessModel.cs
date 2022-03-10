using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Threading.Tasks;
using DataAccessLibrary;

namespace BusinessLayer
{
    public class AdminBookingHistoryBusinessModel : IAdminBookingHistory
    {
        AdminBookingHistoryData adminBookingHistoryData = new AdminBookingHistoryData();
        public void ApproveBooking(BookingModel bookingModel)
        {
            adminBookingHistoryData.ApproveBooking(bookingModel);
        }

        public void ApprovePayment(BookingModel bookingModel)
        {
            adminBookingHistoryData.ApprovePayment(bookingModel);
        }

        public List<BookingModel> GetBookingDetails()
        {
            return adminBookingHistoryData.GetBookingDetails();
        }

        public void RejectBooking(BookingModel bookingModel)
        {
            adminBookingHistoryData.RejectBooking(bookingModel);
        }

        public List<BookingModel> SearchBookingDetails(BookingModel bookingModel)
        {
            return adminBookingHistoryData.SearchBookingDetails(bookingModel);
        }
    }
    
}
