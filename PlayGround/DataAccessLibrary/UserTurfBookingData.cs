using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class UserTurfBookingData : IUserTurfBooking
    {
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
                            where turfDetails.Turf_City.Equals(turfModel.TurfCity) 
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
                foreach (var item in query)
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

        //public List<PaymentTypeModel> GetPaymentType(PaymentTypeModel paymentTypeModel)
        //{
        //    List<PaymentTypeModel> paymentTypes = new List<PaymentTypeModel>();

        //    TurfManagementDBEntities turfManagementDB = new TurfManagementDBEntities();
        //    var query = from type in turfManagementDB.Payment_Type
                        
        //                select type;

        //}
       

    }
}
