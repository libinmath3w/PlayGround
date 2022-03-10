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
        public void ApproveBooking(BookingModel bookingModel)
        {
            throw new NotImplementedException();
        }

        public void ApprovePayment(BookingModel bookingModel)
        {
            throw new NotImplementedException();
        }

        public List<BookingModel> GetBookingDetails()
        {
            List<BookingModel> BookingResultList = new List<BookingModel>();
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from bookings in turfManagementDBEntities.Bookings
                            join customer in turfManagementDBEntities.Users on bookings.User_ID equals customer.ID
                            join turfdetails in turfManagementDBEntities.Turfs on bookings.Turf_ID equals turfdetails.Turf_ID
                            join startTimeDetails in turfManagementDBEntities.Time_Slote on bookings.Start_Time equals startTimeDetails.Time_ID
                            join EndTimeDetails in turfManagementDBEntities.Time_Slote on bookings.End_Time equals EndTimeDetails.Time_ID
                            join Paymenttype in turfManagementDBEntities.Payment_Type on bookings.Payment_ID equals Paymenttype.Payment_ID
                            select new
                            {
                                BID = bookings.Booking_ID,
                                BUserID = bookings.User_ID,
                                BName = customer.Name,
                                BTurfID = bookings.Turf_ID,
                                BTurfName = turfdetails.Turf_Name,
                                BStartTime = startTimeDetails.Time_Slots,
                                BEndTime = EndTimeDetails.Time_Slots,
                                BAmount = bookings.Amount,
                                BPaymentType = Paymenttype.Payment_Method,
                                BBookingDate = bookings.Booking_Date,
                                Bpaymentstatus = bookings.Payment_Status,
                                BBStatus = bookings.Booking_Status,
                                BAvatar = customer.Avatar
                            };

                foreach (var item in query)
                {
                    BookingModel bookingModels = new BookingModel();
                    bookingModels.UserID = item.BUserID;
                    bookingModels.Name = item.BName;
                    bookingModels.Avatar = item.BAvatar;
                    bookingModels.BookingID = item.BID;
                    var TempDate = (DateTime)item.BBookingDate;
                    bookingModels.BookingDate = TempDate.ToShortDateString();
                    bookingModels.TurfID = item.BTurfID;
                    bookingModels.TurfName = item.BTurfName;
                    bookingModels.StartTime = item.BStartTime;
                    bookingModels.EndTime = item.BEndTime;
                    bookingModels.Amount = (float)item.BAmount;
                    bookingModels.BookingStatus = (bool)item.BBStatus;
                    if ((bool)item.BBStatus == true)
                        bookingModels.BStatus = "Approved";
                    else
                        bookingModels.BStatus = "Pending";
                    bookingModels.PaymentType = item.BPaymentType;
                    if (item.Bpaymentstatus == 1)
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

        public void RejectBooking(BookingModel bookingModel)
        {
            throw new NotImplementedException();
        }

        public List<BookingModel> SearchBookingDetails(BookingModel bookingModel)
        {
            throw new NotImplementedException();
        }
    }

}
