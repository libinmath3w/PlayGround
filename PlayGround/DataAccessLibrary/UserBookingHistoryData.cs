using BusinessLayer;
using DataAccessLibrary;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserBookingHistoryData : IUserBookingHistory
    {
        public List<BookingModel> GetBookingDetails(BookingModel bookingModel)
        {
            List<BookingModel> BookingResultList = new List<BookingModel>();
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from bookings in turfManagementDBEntities.Bookings
                            where bookings.User_ID.Equals(bookingModel.UserID)
                            select bookings;
                foreach (var item in query)
                {
                    BookingModel bookingModels = new BookingModel();
                    bookingModels.UserID = item.User_ID;
                    bookingModels.BookingID = item.Booking_ID;
                    bookingModels.BookingDate = (DateTime)item.Booking_Date;
                    bookingModels.TurfID = item.Turf_ID;
                    bookingModels.StartTime = item.Start_Time;
                    bookingModels.EndTime = item.End_Time;
                    bookingModels.Amount = (float)item.Amount;
                    bookingModels.BookingStatus = (bool)item.Booking_Status;
                    bookingModels.PaymentStatus = item.Payment_Status;
                    BookingResultList.Add(bookingModels);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return BookingResultList;
        }
    }
}
