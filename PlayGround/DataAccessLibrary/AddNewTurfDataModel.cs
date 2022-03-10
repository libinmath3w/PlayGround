using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class AddNewTurfDataModel : IAddNewTurf
    {
        public void SaveNewTurf(TurfModel turfModel)
        {
            TurfManagementDBEntities entities = new TurfManagementDBEntities();
            Turf turf = new Turf();
            turf.Turf_Name = turfModel.TurfName;
            turf.Turf_Location = turfModel.TurfLocation;
            turf.Opening_Time = turfModel.OpeningTime;
            turf.Closing_Time = turfModel.ClosingTime;
            turf.Turf_Category_ID = turfModel.TurfCategoryID;
            turf.Turf_Price = turfModel.TurfPrice;
            turf.Turf_City = turfModel.TurfCity;
            turf.Turf_State = turfModel.TurfState;
            turf.Turf_Zip = turfModel.Zip; 
            turf.Turf_Image = turfModel.TurfImage;
            entities.Turfs.Add(turf);
            entities.SaveChanges();
        }
        public List<TimeSloteModel> GetStartingTime(TimeSloteModel timeModel)
        {
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString = "Data source = . ; database = PlaygroundDB; integrated security = SSPI ";
            //sqlConnection.Open();
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlConnection;
            //int id = timeModel.TimeID;
            //sqlCommand.CommandText = "select * from Time_Slote where Time_ID != (select max(Time_ID) from Time_Slote)";
            //int rows = sqlCommand.ExecuteNonQuery();


            List<TimeSloteModel> TurfStartingTime = new List<TimeSloteModel>();

            TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
            var result = from startTime in turfManagementDBEntities.Time_Slote
                         where startTime.Time_ID >= timeModel.TimeID
                         select startTime;
            foreach (var turf in result)
            {
                TimeSloteModel timeModels = new TimeSloteModel();
                timeModels.TimeSlots = turf.Time_Slots;
                TurfStartingTime.Add(timeModels);
            }
            return TurfStartingTime;
        }

        public List<TimeSloteModel> GetEndingTime(TimeSloteModel timeModel)
        {
            List<TimeSloteModel> TurfEndingTime = new List<TimeSloteModel>();
           

            TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
            
            var result = from endTime in turfManagementDBEntities.Time_Slote
                         where endTime.Time_ID >= timeModel.TimeID
                         select endTime;
            foreach (var turf in result)
            {
                TimeSloteModel timeModels = new TimeSloteModel();
                timeModels.TimeSlots = turf.Time_Slots;
                TurfEndingTime.Add(timeModels);
            }
            return TurfEndingTime;
        }

        public List<TurfCategoryModel> GetTurfType(TurfCategoryModel turfModel)
        {

            List<TurfCategoryModel> TurfCategory = new List<TurfCategoryModel>();

            TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
            var result = from Type in turfManagementDBEntities.Turf_Category
                         select Type.Turf_Type;
            foreach (var turf in result)
            {
                TurfCategoryModel turfCategory = new TurfCategoryModel();
                turfCategory.TurfType = turf.ToString();
                TurfCategory.Add(turfCategory);
            }
            return TurfCategory;
        }
    }
    
}
