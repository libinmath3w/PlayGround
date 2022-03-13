using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccessLibrary
{
    public class UserTurfBookingData : IUserTurfBooking
    {
        public int TimeID;
        public int EndTimeId;
        public int TurfOpeningTime;
        public int TurfClosingTime;
        public int AlreadyBStartTime;
        public int AlreadyBEndTime;
        public List<TurfModel> GetTurfDetails(TurfModel turfModel)
        {
            List<TurfModel> BookingTurfList = new List<TurfModel>();
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from turfDetails in turfManagementDBEntities.Turfs
                            join turftypes in turfManagementDBEntities.Turf_Category on turfDetails.Turf_Category_ID equals turftypes.TurfID
                            join Startturftime in turfManagementDBEntities.Time_Slote on turfDetails.Opening_Time equals Startturftime.Time_ID
                            join Endturftime in turfManagementDBEntities.Time_Slote on turfDetails.Closing_Time equals Endturftime.Time_ID
                            select new
                            {
                                TID = turfDetails.Turf_ID,
                                TName = turfDetails.Turf_Name,
                                TStartTime = Startturftime.Time_Slots,
                                TEndTime = Endturftime.Time_Slots,
                                TCity = turfDetails.Turf_City,
                                TCategory = turftypes.Turf_Type,
                                TPrice = turfDetails.Turf_Price,
                                TImage = turfDetails.Turf_Image,
                                TState = turfDetails.Turf_State
                            };
                var result = query.Where(p => p.TCity.Contains(turfModel.TurfCity));
                foreach (var item in result)
                {
                    TurfModel turfModels = new TurfModel();
                    turfModels.TurfID = item.TID;
                    turfModels.TurfName = item.TName;
                    turfModels.TurfLocation = item.TCity;
                    turfModels.StartTime = item.TStartTime;
                    turfModels.EndTime = item.TEndTime;
                    turfModels.TurfPrice = (float)item.TPrice;
                    turfModels.TurfCity = item.TCity;
                    turfModels.TurfImage = item.TImage;
                    turfModels.TurfType = item.TCategory;
                    turfModels.TurfState = item.TState;
                    BookingTurfList.Add(turfModels);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return BookingTurfList;
        }
        public List<TimeSloteModel> GetOpeningTime(TimeSloteModel timeModel)
        {
            List<TimeSloteModel> TurfOpeningTime = new List<TimeSloteModel>();
            TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
            var result = from time in turfManagementDBEntities.Time_Slote
                         where time.Time_ID >= timeModel.TimeID
                         select time;
            foreach (var turf in result)
            {
                TimeSloteModel timeModels = new TimeSloteModel();
                timeModels.TimeSlots = turf.Time_Slots;
                TurfOpeningTime.Add(timeModels);
            }
            return TurfOpeningTime;
        }

        public List<TimeSloteModel> GetClosingTime(TimeSloteModel timeModel)
        {
            try
            {
                List<TimeSloteModel> TurfClosingTime = new List<TimeSloteModel>();
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var result = from time in turfManagementDBEntities.Time_Slote
                             where time.Time_ID > timeModel.TimeID
                             select time;
                foreach (var turf in result)
                {
                    TimeSloteModel timeModels = new TimeSloteModel();
                    timeModels.TimeSlots = turf.Time_Slots;
                    TurfClosingTime.Add(timeModels);
                }
                return TurfClosingTime;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PaymentTypeModel> GetPaymentTypes(PaymentTypeModel paymentTypeModel)
        {
            try
            {
                List<PaymentTypeModel> paymentTypes = new List<PaymentTypeModel>();

                TurfManagementDBEntities turfManagementDB = new TurfManagementDBEntities();
                var query = from type in turfManagementDB.Payment_Type
                            select type;

                foreach (var item in query)
                {
                    PaymentTypeModel paymentTypeModels = new PaymentTypeModel();
                    paymentTypeModels.PaymentID = item.Payment_ID;
                    paymentTypeModels.PaymentMethod = item.Payment_Method;
                    paymentTypes.Add(paymentTypeModels);
                }
                return paymentTypes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TimeSloteModel> GetCurrentTimeDetails(TimeSloteModel timeSloteModel)
        {
            try
            {
                List<TimeSloteModel> timeDetails = new List<TimeSloteModel>();
                TurfManagementDBEntities turfManagementDB = new TurfManagementDBEntities();
                var query = turfManagementDB.Time_Slote
                                .Where(p => p.Time_Slots.Contains(timeSloteModel.CurrentDateHour));
                foreach (var time in query)
                {
                    TimeID = time.Time_ID;
                }
                var turfTimeQuery = from TOpenTime in turfManagementDB.Turfs
                                    where TOpenTime.Turf_ID == timeSloteModel.TurfID
                                    select TOpenTime;
                foreach (var item in turfTimeQuery)
                {
                    TurfOpeningTime = item.Opening_Time;
                    TurfClosingTime = item.Closing_Time;

                }
                if (TimeID >= TurfOpeningTime)
                {
                    var TurfBookingOpeningTime = from TBOTime in turfManagementDB.Bookings
                                                 where TBOTime.Booking_Date == timeSloteModel.BookingTime
                                                 select TBOTime;
                    if (TurfBookingOpeningTime.Count() > 0)
                    {
                        var AllTurfBookingInfo = from TBOTime in turfManagementDB.Bookings
                                                      where (TBOTime.Booking_Date == timeSloteModel.BookingTime) && (TBOTime.Turf_ID == timeSloteModel.TurfID)
                                                      select TBOTime;
                        foreach (var item in AllTurfBookingInfo)
                        {
                            AlreadyBStartTime = item.Start_Time;
                            AlreadyBEndTime = item.End_Time;
                        }
                        if ((AlreadyBEndTime - AlreadyBStartTime) == 1)
                        {
                            for (int i = AlreadyBStartTime; i < AlreadyBEndTime; i++)
                            {
                                var itemToRemove = timeDetails.SingleOrDefault(r => r.TimeID == i);
                                if (itemToRemove != null)
                                    timeDetails.Remove(itemToRemove);
                            }
                        }
                        else
                        {
                            for (int i = AlreadyBStartTime; i < AlreadyBEndTime; i++)
                            {
                                var itemToRemove = timeDetails.SingleOrDefault(r => r.TimeID == i);
                                if (itemToRemove != null)
                                    timeDetails.Remove(itemToRemove);
                            }
                        }

                    }
                    else
                    {
                        var result = from time in turfManagementDB.Time_Slote
                                     where (time.Time_ID > TimeID) && (time.Time_ID < TurfClosingTime)
                                     select time;

                        foreach (var item in result)
                        {
                            TimeSloteModel timeSlote = new TimeSloteModel();
                            timeSlote.TimeID = item.Time_ID;
                            timeSlote.TimeSlots = item.Time_Slots;
                            timeDetails.Add(timeSlote);
                        }
                    }
                    
                }
                else if (TurfOpeningTime > TimeID)
                {
                    var TurfBookingOpeningTime = from TBOTime in turfManagementDB.Bookings
                                                 where TBOTime.Booking_Date == timeSloteModel.BookingTime
                                                 select TBOTime;
                    if (TurfBookingOpeningTime.Count() > 0)
                    {
                        var result = from time in turfManagementDB.Time_Slote
                                     where (time.Time_ID > TimeID) && (time.Time_ID < TurfClosingTime)
                                     select time;

                        foreach (var item in result)
                        {
                            TimeSloteModel timeSlote = new TimeSloteModel();
                            timeSlote.TimeID = item.Time_ID;
                            timeSlote.TimeSlots = item.Time_Slots;
                            timeDetails.Add(timeSlote);
                        }

                        var AllTurfBookingInfo = from TBOTime in turfManagementDB.Bookings
                                                 where (TBOTime.Booking_Date == timeSloteModel.BookingTime) && (TBOTime.Turf_ID == timeSloteModel.TurfID)
                                                 select TBOTime;
                        foreach (var item in AllTurfBookingInfo)
                        {
                            AlreadyBStartTime = item.Start_Time;
                            AlreadyBEndTime = item.End_Time;
                        }
                        if ((AlreadyBEndTime - AlreadyBStartTime) == 1)
                        {
                            for (int i = AlreadyBStartTime; i < AlreadyBEndTime; i++)
                            {
                                var itemToRemove = timeDetails.SingleOrDefault(r => r.TimeID == i);
                                if (itemToRemove != null)
                                    timeDetails.Remove(itemToRemove);
                            }
                        }
                        else
                        {
                            for (int i = AlreadyBStartTime; i < AlreadyBEndTime; i++)
                            {
                                var itemToRemove = timeDetails.SingleOrDefault(r => r.TimeID == i);
                                if (itemToRemove != null)
                                    timeDetails.Remove(itemToRemove);
                            }
                        }
                    }
                    else
                    {
                        var result = from time in turfManagementDB.Time_Slote
                                     where (time.Time_ID >= TurfOpeningTime) && (time.Time_ID < TurfClosingTime)
                                     select time;

                        foreach (var item in result)
                        {
                            TimeSloteModel timeSlote = new TimeSloteModel();
                            timeSlote.TimeID = item.Time_ID;
                            timeSlote.TimeSlots = item.Time_Slots;
                            timeDetails.Add(timeSlote);
                        }
                    }
                }

              
                return timeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TimeSloteModel> GetCurrentEndTimeDetails(TimeSloteModel timeSloteModel)
        {
            try
            {
                List<TimeSloteModel> timeDetails = new List<TimeSloteModel>();
                TurfManagementDBEntities turfManagementDB = new TurfManagementDBEntities();
                var query = turfManagementDB.Time_Slote
                                .Where(p => p.Time_Slots.Contains(timeSloteModel.CurrentDateHour));
                foreach (var time in query)
                {
                    TimeID = time.Time_ID;
                }
                var turfTimeQuery = from TOpenTime in turfManagementDB.Turfs
                                    where TOpenTime.Turf_ID == timeSloteModel.TurfID
                                    select TOpenTime;
                foreach (var item in turfTimeQuery)
                {
                    TurfOpeningTime = item.Opening_Time;
                    TurfClosingTime = item.Closing_Time;
                }
                if (TimeID >= TurfOpeningTime)
                {
                    var TurfBookingOpeningTime = from TBOTime in turfManagementDB.Bookings
                                                 where TBOTime.Booking_Date == timeSloteModel.BookingTime
                                                 select TBOTime;
                    if (TurfBookingOpeningTime.Count() > 0)
                    {
                        var AllTurfBookingInfo = from TBOTime in turfManagementDB.Bookings
                                                 where (TBOTime.Booking_Date == timeSloteModel.BookingTime) && (TBOTime.Turf_ID == timeSloteModel.TurfID)
                                                 select TBOTime;
                        foreach (var item in AllTurfBookingInfo)
                        {
                            AlreadyBStartTime = item.Start_Time;
                            AlreadyBEndTime = item.End_Time;
                        }

                    }
                    else
                    {
                        TimeID = TimeID + 1;
                        TurfClosingTime = TurfClosingTime + 1;
                        var result = from time in turfManagementDB.Time_Slote
                                     where (time.Time_ID >= TimeID) && (time.Time_ID < TurfClosingTime)
                                     select time;

                        foreach (var item in result)
                        {
                            TimeSloteModel timeSlote = new TimeSloteModel();
                            timeSlote.TimeID = item.Time_ID;
                            timeSlote.TimeSlots = item.Time_Slots;
                            timeDetails.Add(timeSlote);
                        }
                    }

                }
                else if (TurfOpeningTime > TimeID)
                {
                    var TurfBookingOpeningTime = from TBOTime in turfManagementDB.Bookings
                                                 where TBOTime.Booking_Date == timeSloteModel.BookingTime
                                                 select TBOTime;
                    if (TurfBookingOpeningTime.Count() > 0)
                    {
                        var AllTurfBookingInfo = from TBOTime in turfManagementDB.Bookings
                                                 where (TBOTime.Booking_Date == timeSloteModel.BookingTime) && (TBOTime.Turf_ID == timeSloteModel.TurfID)
                                                 select TBOTime;
                        foreach (var item in AllTurfBookingInfo)
                        {
                            AlreadyBStartTime = item.Start_Time;
                            AlreadyBEndTime = item.End_Time;
                        }

                        TimeID = TimeID + 1;
                        TurfClosingTime = TurfClosingTime + 1;
                        var result = from time in turfManagementDB.Time_Slote
                                     where (time.Time_ID > TimeID) && (time.Time_ID < TurfClosingTime)
                                     select time;

                        foreach (var item in result)
                        {
                            TimeSloteModel timeSlote = new TimeSloteModel();
                            timeSlote.TimeID = item.Time_ID;
                            timeSlote.TimeSlots = item.Time_Slots;
                            timeDetails.Add(timeSlote);
                        }
                        for (int i = AlreadyBStartTime; i < AlreadyBEndTime; i++)
                        {
                            var itemToRemove = timeDetails.SingleOrDefault(r => r.TimeID == i);
                            if (itemToRemove != null)
                                timeDetails.Remove(itemToRemove);
                        }

                    }
                    else
                    {
                        TurfClosingTime = TurfClosingTime + 1;
                        var result = from time in turfManagementDB.Time_Slote
                                     where (time.Time_ID > TurfOpeningTime) && (time.Time_ID < TurfClosingTime)
                                     select time;

                        foreach (var item in result)
                        {
                            TimeSloteModel timeSlote = new TimeSloteModel();
                            timeSlote.TimeID = item.Time_ID;
                            timeSlote.TimeSlots = item.Time_Slots;
                            timeDetails.Add(timeSlote);
                        }
                    }
                }
                return timeDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TimeSloteModel> GetNonCurrentTimeDetails(TimeSloteModel timeSloteModel)
        {

            try
            {
                List<TimeSloteModel> timeDetails = new List<TimeSloteModel>();
                TurfManagementDBEntities turfManagementDB = new TurfManagementDBEntities();
                var turfTimeQuery = from TOpenTime in turfManagementDB.Turfs
                                    where TOpenTime.Turf_ID == timeSloteModel.TurfID
                                    select TOpenTime;
                foreach (var item in turfTimeQuery)
                {
                    TurfOpeningTime = item.Opening_Time;
                    TurfClosingTime = item.Closing_Time;

                }
                    var TurfBookingOpeningTime = from TBOTime in turfManagementDB.Bookings
                                                 where TBOTime.Booking_Date == timeSloteModel.BookingTime
                                                 select TBOTime;
                    if (TurfBookingOpeningTime.Count() > 0)
                    {
                       var result = from time in turfManagementDB.Time_Slote
                                     where (time.Time_ID >= TurfOpeningTime) && (time.Time_ID < TurfClosingTime)
                                     select time;

                        foreach (var item in result)
                        {
                            TimeSloteModel timeSlote = new TimeSloteModel();
                            timeSlote.TimeID = item.Time_ID;
                            timeSlote.TimeSlots = item.Time_Slots;
                            timeDetails.Add(timeSlote);
                        }
                            var AllTurfBookingInfo = from TBOTime in turfManagementDB.Bookings
                                                 where (TBOTime.Booking_Date == timeSloteModel.BookingTime) && (TBOTime.Turf_ID == timeSloteModel.TurfID)
                                                 select TBOTime;
                            if (AllTurfBookingInfo.Count() > 0)
                            {
                            foreach (var item in AllTurfBookingInfo)
                            {
                                AlreadyBStartTime = item.Start_Time;
                                AlreadyBEndTime = item.End_Time;

                                
                            }
                            if ((AlreadyBEndTime - AlreadyBStartTime) == 1)
                                {
                                    for (int i = AlreadyBStartTime; i < AlreadyBEndTime; i++)
                                        {
                                var itemToRemove = timeDetails.SingleOrDefault(r => r.TimeID == i);
                                if (itemToRemove != null)
                                    timeDetails.Remove(itemToRemove);
                                    }
                               }
                        else
                            {
                                for (int i = AlreadyBStartTime; i < AlreadyBEndTime; i++)
                                    {
                                var itemToRemove = timeDetails.SingleOrDefault(r => r.TimeID == i);
                                if (itemToRemove != null)
                                    timeDetails.Remove(itemToRemove);
                                    }
                        }
                        }
                        else
                            {
                            MessageBox.Show("its Not Working");
                            }
                    }
                    else
                    {
                        var result = from time in turfManagementDB.Time_Slote
                                     where (time.Time_ID >= TurfOpeningTime) && (time.Time_ID < TurfClosingTime)
                                     select time;

                        foreach (var item in result)
                        {
                            TimeSloteModel timeSlote = new TimeSloteModel();
                            timeSlote.TimeID = item.Time_ID;
                            timeSlote.TimeSlots = item.Time_Slots;
                            timeDetails.Add(timeSlote);
                        }
                    }

                return timeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TimeSloteModel> GetNonCurrentEndTimeDetails(TimeSloteModel timeSloteModel)
        {
            try
            {
                List<TimeSloteModel> timeDetails = new List<TimeSloteModel>();
                TurfManagementDBEntities turfManagementDB = new TurfManagementDBEntities();
                var turfTimeQuery = from TOpenTime in turfManagementDB.Turfs
                                    where TOpenTime.Turf_ID == timeSloteModel.TurfID
                                    select TOpenTime;
                foreach (var item in turfTimeQuery)
                {
                    TurfOpeningTime = item.Opening_Time;
                    TurfClosingTime = item.Closing_Time;

                }
                var TurfBookingOpeningTime = from TBOTime in turfManagementDB.Bookings
                                             where TBOTime.Booking_Date == timeSloteModel.BookingTime
                                             select TBOTime;
                if (TurfBookingOpeningTime.Count() > 0)
                {
                    TurfOpeningTime = TurfOpeningTime + 1;
                    var result = from time in turfManagementDB.Time_Slote
                                 where (time.Time_ID > TurfOpeningTime) && (time.Time_ID <= TurfClosingTime)
                                 select time;

                    foreach (var item in result)
                    {
                        TimeSloteModel timeSlote = new TimeSloteModel();
                        timeSlote.TimeID = item.Time_ID;
                        timeSlote.TimeSlots = item.Time_Slots;
                        timeDetails.Add(timeSlote);
                    }

                    var AllTurfBookingInfo = from TBOTime in turfManagementDB.Bookings
                                             where (TBOTime.Booking_Date == timeSloteModel.BookingTime) && (TBOTime.Turf_ID == timeSloteModel.TurfID)
                                             select TBOTime;
                    if (AllTurfBookingInfo.Count() > 0)
                    {
                        foreach (var item in AllTurfBookingInfo)
                        {
                            var itemToRemove = timeDetails.SingleOrDefault(r => r.TimeID == item.End_Time);
                            if (itemToRemove != null)
                                timeDetails.Remove(itemToRemove);
                        }
                    }
                    else
                    {
                        MessageBox.Show("its Not Working");
                    }
                }
                else
                {
                    TurfOpeningTime = TurfOpeningTime + 1;
                    var result = from time in turfManagementDB.Time_Slote
                                 where (time.Time_ID >= TurfOpeningTime) && (time.Time_ID <= TurfClosingTime)
                                 select time;

                    foreach (var item in result)
                    {
                        TimeSloteModel timeSlote = new TimeSloteModel();
                        timeSlote.TimeID = item.Time_ID;
                        timeSlote.TimeSlots = item.Time_Slots;
                        timeDetails.Add(timeSlote);
                    }
                }

                return timeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BookTurf(BookingModel bookingModel)
        {
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                Booking booking = new Booking();
                booking.User_ID = bookingModel.UserID;
                booking.Turf_ID = bookingModel.TurfID;
                booking.Start_Time = bookingModel.BookingStartTime;
                booking.End_Time = bookingModel.BookingEndTime;
                booking.Amount = bookingModel.Amount;
                booking.Payment_ID = bookingModel.PaymentID;
                booking.Booking_Date = bookingModel.BookingDateTime;
                booking.Payment_Status = bookingModel.PaymentStatusInt;
                booking.Booking_Time = bookingModel.BookingTime;
                booking.Booking_Status = bookingModel.BookingStatus;
                turfManagementDBEntities.Bookings.Add(booking);
                turfManagementDBEntities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
