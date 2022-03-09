using DataAccessLibrary;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserTurfBookingBusinessModel
    {
        public List<TurfModel> GetTurfDetails(TurfModel turfModel)
        {
            UserTurfBookingData userTurfBookingData = new UserTurfBookingData();
            return userTurfBookingData.GetTurfDetails(turfModel);
        }
        public List<TimeSloteModel> GetOpeningTime(TimeSloteModel timeModel)
        {
            UserTurfBookingData userTurfBookingData = new UserTurfBookingData();
            return userTurfBookingData.GetOpeningTime(timeModel);
        }
        public List<TimeSloteModel> GetClosingTime(TimeSloteModel timeModel)
        {
            UserTurfBookingData userTurfBookingData = new UserTurfBookingData();
            return userTurfBookingData.GetClosingTime(timeModel);
        }
        public List<PaymentTypeModel> GetPaymentType(PaymentTypeModel paymentTypeModel)
        {
            UserTurfBookingData userTurfBookingData = new UserTurfBookingData();
            return userTurfBookingData.GetPaymentTypes(paymentTypeModel);
        }
    }
}
