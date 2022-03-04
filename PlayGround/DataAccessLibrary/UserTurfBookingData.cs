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
                            where turfDetails.Turf_City.Equals(turfModel.TurfCity)
                            select turfDetails;
                foreach (var item in query)
                {
                    TurfModel turfModels = new TurfModel();
                    turfModels.TurfID = item.Turf_ID;
                    turfModels.TurfName = item.Turf_Name;
                    turfModels.TurfLocation = item.Turf_Location;
                    turfModels.OpeningTime = Convert.ToDateTime(item.Opening_Time);
                    turfModels.ClosingTime = Convert.ToDateTime(item.Closing_Time);
                    turfModels.TurfCategoryID = item.Turf_Category_ID;
                    turfModels.TurfPrice = (float)item.Turf_Price;
                    turfModels.TurfCity = item.Turf_City;
                    turfModels.TurfState = item.Turf_State;
                    turfModels.Zip = item.Turf_Zip;
                    turfModels.TurfImage = item.Turf_Image;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return BookingTurfList;
        }
            
    }
}
