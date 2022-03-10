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
    public class AdminAddNewTurfBusinessModel : IAddNewTurf
    {
        AddNewTurfDataModel addNewTurfDataModel = new AddNewTurfDataModel();
        AdminSettingsData adminSettingsData = new AdminSettingsData();
        public List<TurfModel> GetNewTurf(TurfModel turfModel)
        {
            return adminSettingsData.GetNewTurf(turfModel);
        }

        public List<TimeSloteModel> GetStartingTime(TimeSloteModel timeSloteModel)
        {
            return addNewTurfDataModel.GetStartingTime(timeSloteModel);
        }
        public List<TimeSloteModel> GetEndingTime(TimeSloteModel timeSloteModel)
        {
            return addNewTurfDataModel.GetEndingTime(timeSloteModel);
        }
        public void SaveNewTurf(TurfModel turfModel)
        {
            adminSettingsData.SaveNewTurf(turfModel);
        }

        public List<TurfCategoryModel> GetTurfType(TurfCategoryModel turfCategory)
        {
            return addNewTurfDataModel.GetTurfType(turfCategory);
        }

        public void AddNewTurf(TurfModel turfModel)
        {
            addNewTurfDataModel.AddNewTurf(turfModel);
        }
    }
}

       
    
