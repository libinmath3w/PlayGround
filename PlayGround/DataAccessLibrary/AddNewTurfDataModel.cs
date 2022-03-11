using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccessLibrary
{
    public class AddNewTurfDataModel : IAddNewTurf
    {
        public void SaveNewTurf(TurfModel turfModel)
        {
            try
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
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<TimeSloteModel> GetStartingTime()
        {
            List<TimeSloteModel> TurfStartingTime = new List<TimeSloteModel>();
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var result = from startTime in turfManagementDBEntities.Time_Slote
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
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<TimeSloteModel> GetEndingTime()
        {
            try
            {
                List<TimeSloteModel> TurfEndingTime = new List<TimeSloteModel>();
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();

                var result = from endTime in turfManagementDBEntities.Time_Slote
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
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<TurfCategoryModel> GetTurfType()
        {
            try
            {
                List<TurfCategoryModel> TurfCategoryList = new List<TurfCategoryModel>();
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from turfTypes in turfManagementDBEntities.Turf_Category
                            select turfTypes;
                foreach (var item in query)
                {
                    TurfCategoryModel turfCategory = new TurfCategoryModel();
                    turfCategory.TurfID = item.TurfID;
                    turfCategory.TurfType = item.Turf_Type;
                    TurfCategoryList.Add(turfCategory);
                }
                return TurfCategoryList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
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
            try
            {
                List<TurfModel> TurfModels = new List<TurfModel>();
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var result = from Turf in turfManagementDBEntities.Turfs
                             where Turf.Turf_ID == turfModel.TurfID
                             select Turf;
                if(result.Count() > 0)
                {
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
                }
                else
                {
                    MessageBox.Show("No turf found in this ID");
                }
                
                return TurfModels;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void UpdateTurf(TurfModel turfModel)
        {
            try
            {
                SqlConnection sqlConnection = null;
                sqlConnection = new SqlConnection("Data Source =.; Database = TurfManagementDB; Integrated Security=true;");
                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE TURF SET TURF_NAME = '" + turfModel.TurfName + "', TURF_CITY = '" + turfModel.TurfCity + "', TURF_STATE = '" + turfModel.TurfState + "', TURF_ZIP = '" + turfModel.Zip + "', Opening_Time = " + turfModel.OpeningTime + ", Closing_Time = " + turfModel.ClosingTime + ", Turf_Category_ID = " + turfModel.TurfCategoryID + ", Turf_Price = " + turfModel.TurfPrice + ", Turf_Image = '" + turfModel.TurfImage + "' WHERE TURF_ID = " + turfModel.TurfID, sqlConnection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);           
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}
