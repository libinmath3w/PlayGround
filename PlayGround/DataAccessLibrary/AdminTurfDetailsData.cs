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
    public class AdminTurfDetailsData : IAdminTurfDetails
    {
        public void DisableTurf(TurfModel turfModel)
        {
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from TurfInfo in turfManagementDBEntities.Turfs
                            where TurfInfo.Turf_ID == turfModel.TurfID
                            select TurfInfo;
                if (query.Count() > 0)
                {
                    SqlConnection sqlConnection = null;
                    foreach (var item in query)
                    {
                        if (item.Turf_Status == 0)
                        {
                            MessageBox.Show("Turf is Already Disabled");
                        }
                        else
                        {
                            try
                            {
                                sqlConnection = new SqlConnection("Data Source =.; Database = TurfManagementDB; Integrated Security=true;");
                                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE TURF SET TURF_STATUS = 0 WHERE TURF_ID = " + turfModel.TurfID, sqlConnection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                MessageBox.Show("Turf Disabled");
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
                    MessageBox.Show("Turf Not Found");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnableTurf(TurfModel turfModel)
        {
            try
            {
                TurfManagementDBEntities turfManagementDBEntities = new TurfManagementDBEntities();
                var query = from TurfInfo in turfManagementDBEntities.Turfs
                            where TurfInfo.Turf_ID == turfModel.TurfID
                            select TurfInfo;
                if (query.Count() > 0)
                {
                    SqlConnection sqlConnection = null;
                    foreach (var item in query)
                    {
                        if (item.Turf_Status == 1)
                        {
                            MessageBox.Show("Turf is Already Enabled");
                        }
                        else
                        {
                            try
                            {
                                sqlConnection = new SqlConnection("Data Source =.; Database = TurfManagementDB; Integrated Security=true;");
                                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE TURF SET TURF_STATUS = 1 WHERE TURF_ID = " + turfModel.TurfID, sqlConnection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                MessageBox.Show("Turf Enabled");
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
                    MessageBox.Show("Turf Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TurfModel> GetTurfDetails()
        {
            List<TurfModel> TurfDetailsList = new List<TurfModel>();
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
                                TState = turfDetails.Turf_State,
                                TStatus = turfDetails.Turf_Status
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
                    turfModels.TurfStatus = item.TStatus;
                    TurfDetailsList.Add(turfModels);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TurfDetailsList;
        }


        public List<TurfModel> SearchTurfDetails(TurfModel turfModel)
        {
            List<TurfModel> TurfDetailsList = new List<TurfModel>();
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
                                TState = turfDetails.Turf_State,
                                TStatus = turfDetails.Turf_Status
                            };
                var result = query.Where(p => p.TName.Contains(turfModel.TurfName));
                if (result.Count() > 0)
                {
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
                        turfModels.TurfStatus = item.TStatus;
                        turfModels.TurfState = item.TState;
                        TurfDetailsList.Add(turfModels);
                    }
                }
                else
                {
                    MessageBox.Show("No turf Found");
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TurfDetailsList;
        }
    }
}




