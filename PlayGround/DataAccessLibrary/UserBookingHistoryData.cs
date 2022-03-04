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
                            join customer in turfManagementDBEntities.Users on bookings.User_ID equals customer.ID
                            join turfdetails in turfManagementDBEntities.Turfs on bookings.Turf_ID equals turfdetails.Turf_ID
                            join startTimeDetails in turfManagementDBEntities.Time_Slote on bookings.Start_Time equals startTimeDetails.Time_ID
                            where bookings.User_ID.Equals(bookingModel.UserID)
                            select bookings;
                foreach (var item in query)
                {
                    BookingModel bookingModels = new BookingModel();
                    bookingModels.UserID = item.User_ID;
                    bookingModels.Name = item.User.Name;
                    bookingModels.Avatar = item.User.Avatar;
                    bookingModels.BookingID = item.Booking_ID;
                    var TempDate = (DateTime)item.Booking_Date;
                    bookingModels.BookingDate = TempDate.ToShortDateString();
                    bookingModels.TurfID = item.Turf_ID;
                    bookingModels.TurfName = item.Turf.Turf_Name;
                    bookingModels.StartTime = item.Time_Slote.Time_Slots;
                    bookingModels.EndTime = item.Time_Slote.Time_Slots;
                    bookingModels.Amount = (float)item.Amount;
                    bookingModels.BookingStatus = (bool)item.Booking_Status;
                    bookingModels.PaymentType = item.Payment_Type.Payment_Method;
                    if (item.Payment_Status == 1)
                        bookingModels.PaymentStatus = "Paid";
                    else
                        bookingModels.PaymentStatus = "Not Paid";
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
