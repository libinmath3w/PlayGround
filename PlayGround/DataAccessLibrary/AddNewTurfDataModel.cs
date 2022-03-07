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
    }
    
}
