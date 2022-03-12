using DataAccessLibrary;
using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserTurfBookingBusinessModel : IUserTurfBooking
    {
        UserTurfBookingData userTurfBookingData = new UserTurfBookingData();
        public List<TurfModel> GetTurfDetails(TurfModel turfModel)
        {
            return userTurfBookingData.GetTurfDetails(turfModel);
        }
        public List<TimeSloteModel> GetOpeningTime(TimeSloteModel timeModel)
        {
           return userTurfBookingData.GetOpeningTime(timeModel);
        }
        public List<TimeSloteModel> GetClosingTime(TimeSloteModel timeModel)
        {
            return userTurfBookingData.GetClosingTime(timeModel);
        }
        public List<PaymentTypeModel> GetPaymentType(PaymentTypeModel paymentTypeModel)
        {
            return userTurfBookingData.GetPaymentTypes(paymentTypeModel);
        }
        public List<TimeSloteModel> GetCurrentTimeDetails(TimeSloteModel timeModel)
        {
            return userTurfBookingData.GetCurrentTimeDetails(timeModel);
        }
        public List<TimeSloteModel> GetCurrentEndTimeDetails(TimeSloteModel timeModel)
        {
            return userTurfBookingData.GetCurrentEndTimeDetails(timeModel);
        }

        public List<TimeSloteModel> GetNonCurrentTimeDetails(TimeSloteModel timeSloteModel)
        {
            return userTurfBookingData.GetNonCurrentTimeDetails(timeSloteModel);
        }

        public List<TimeSloteModel> GetNonCurrentEndTimeDetails(TimeSloteModel timeSloteModel)
        {
            return userTurfBookingData.GetNonCurrentEndTimeDetails(timeSloteModel);
        }
    }
}
