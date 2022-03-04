using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary;
using BusinessLayer;
using EntityLayer;

namespace DataAccessLibrary
{
    public class AdminBookingHistoryData : IAdminBookingHistory
    {
        public List<BookingModel> GetBookingDetails(BookingModel bookingModel)
        {
            List<BookingModel> BookingResultList = new List<BookingModel>();
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from bookings in turfManagementDBEntities.Bookings
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
                    bookingModels.PaymentID = item.Payment_ID;
                    bookingModels.BookingTime = (DateTime)item.Booking_Time;
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
