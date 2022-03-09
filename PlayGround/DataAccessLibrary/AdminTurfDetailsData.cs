using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class AdminTurfDetailsData : IAdminTurfDetails
    {

        public List<TurfModel> GetAdminTurfDetails(TurfModel turfModel)
        {
            List<TurfModel> AdminTurfDetailsList = new List<TurfModel>();
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from adminTurfDetails in turfManagementDBEntities.Turfs
                            select adminTurfDetails;
                foreach (var item in query)
                {
                    TurfModel Models = new TurfModel();
                    Models.TurfID = item.Turf_ID;
                    Models.TurfName = item.Turf_Name;
                    Models.TurfLocation = item.Turf_Location;
                    Models.OpeningTime = item.Opening_Time;
                    Models.ClosingTime = item.Closing_Time;
                    Models.TurfCategoryID = item.Turf_Category_ID;
                    Models.TurfPrice = (float)item.Turf_Price;
                    Models.TurfCity = item.Turf_City;
                    Models.TurfState = item.Turf_State;
                    Models.Zip = item.Turf_Zip;
                    Models.TurfImage = item.Turf_Image;
                    AdminTurfDetailsList.Add(Models);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AdminTurfDetailsList;
        }

        public List<TurfModel> GetTurfDetails()
        {
            throw new NotImplementedException();
        }
    }
}




