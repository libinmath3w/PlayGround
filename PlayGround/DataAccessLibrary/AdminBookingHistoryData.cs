using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary;
using BusinessLayer;
using EntityLayer;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLibrary
{
    public class AdminBookingHistoryData : IAdminBookingHistory
    {
        public void ApproveBooking(BookingModel bookingModel)
        {
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from bookingInfo in turfManagementDBEntities.Bookings
                            where bookingInfo.Booking_ID == bookingModel.BookingID
                            select bookingInfo;
                if (query.Count() > 0)
                {
                    SqlConnection sqlConnection = null;
                    foreach (var item in query)
                    {
                        if (item.Booking_Status == true)
                        {
                            MessageBox.Show("Booking is Already Approved");
                        }
                        else
                        {
                            try
                            {
                                sqlConnection = new SqlConnection("Data Source =.; Database = TurfManagementDB; Integrated Security=true;");
                                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE BOOKING SET BOOKING_STATUS = 1 WHERE BOOKING_ID = " + bookingModel.BookingID, sqlConnection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                MessageBox.Show("Booking Approved");
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Booking Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ApprovePayment(BookingModel bookingModel)
        {
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from bookingInfo in turfManagementDBEntities.Bookings
                            where bookingInfo.Booking_ID == bookingModel.BookingID
                            select bookingInfo;
                if (query.Count() > 0)
                {
                    SqlConnection sqlConnection = null;
                    foreach (var item in query)
                    {
                        if (item.Payment_Status == 1)
                        {
                            MessageBox.Show("Booking is Already Approved");
                        }
                        else
                        {
                            try
                            {
                                sqlConnection = new SqlConnection("Data Source =.; Database = TurfManagementDB; Integrated Security=true;");
                                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE BOOKING SET PAYMENT_STATUS = 0 WHERE BOOKING_ID = " + bookingModel.BookingID, sqlConnection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                MessageBox.Show("Payment Approved");
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Booking Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from bookingInfo in turfManagementDBEntities.Bookings
                            where bookingInfo.Booking_ID == bookingModel.BookingID
                            select bookingInfo;
                if (query.Count() > 0)
                {
                    SqlConnection sqlConnection = null;
                    foreach (var item in query)
                    {
                        if (item.Booking_Status == false)
                        {
                            MessageBox.Show("Booking is Already Cancelled");
                        }
                        else
                        {
                            try
                            {
                                sqlConnection = new SqlConnection("Data Source =.; Database = TurfManagementDB; Integrated Security=true;");
                                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE BOOKING SET BOOKING_STATUS = 0 WHERE BOOKING_ID = " + bookingModel.BookingID, sqlConnection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                MessageBox.Show("Booking Cancelled");
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Booking Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BookingModel> SearchBookingDetails(BookingModel bookingModel)
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
                var result = query.Where(p => p.BName.Contains(bookingModel.Name));
                if (result.Count() > 0)
                {
                    foreach (var item in result)
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
                else
                {
                    MessageBox.Show("No User Found");
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
