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

            List<TimeSloteModel> TurfStartingTime = new List<TimeSloteModel>();

            TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
            var result = from startTime in turfManagementDBEntities.Time_Slote
                         where startTime.Time_ID >= timeModel.TimeID
                         select startTime;
            foreach (var turf in result)
            {
                TimeSloteModel timeModels = new TimeSloteModel();
                timeModels.TimeID = turf.Time_ID;
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
                timeModels.TimeID = turf.Time_ID;
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

        public void AddNewTurf(TurfModel turfModel)
        {
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                Turf turfModels = new Turf();
                turfModels.Turf_Name = turfModel.TurfName;
                turfModels.Turf_Location = turfModel.TurfCity;
                turfModels.Opening_Time = turfModel.OpeningTime;
                turfModels.Closing_Time = turfModel.ClosingTime;
                turfModels.Turf_Category_ID = turfModel.TurfCategoryID;
                turfModels.Turf_Price = turfModel.TurfPrice;
                turfModels.Turf_City = turfModel.TurfCity;
                turfModels.Turf_State = turfModel.TurfState;
                turfModels.Turf_Zip = turfModel.Zip;
                turfModels.Turf_Status = turfModel.TurfStatus;
                turfModels.Turf_Image = turfModel.TurfImage;
                turfManagementDBEntities.Turfs.Add(turfModels);
                turfManagementDBEntities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<TurfModel> GetTurfDetails(TurfModel turfModel)
        {
            List<TurfModel> TurfModels = new List<TurfModel>();

            TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
          
            var result = from Turf in turfManagementDBEntities.Turfs
                         where Turf.Turf_ID == turfModel.TurfID
                         select Turf;
            foreach (var turf in result)
            {
                TurfModel turfs = new TurfModel();
                turfs.TurfID = turf.Turf_ID;
                turfs.TurfName = turf.Turf_Name;
                turfs.OpeningTime = turf.Opening_Time;
                turfs.ClosingTime = turf.Closing_Time;
                turfs.TurfCity = turf.Turf_City;
                turfs.TurfState = turf.Turf_State;
                turfs.Zip = turf.Turf_Zip;
                turfs.TurfCategoryID = turf.Turf_Category_ID;
                turfs.TurfPrice = (float)turf.Turf_Price;
                TurfModels.Add(turfs);
            }
            return TurfModels;
        }

        public void UpdateTurf(TurfModel turfModel)
        {
            throw new NotImplementedException();
        }
    }
    
}
