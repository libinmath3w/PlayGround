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
        public List<TurfModel> GetNewTurf(TurfModel turfModel)
        {
            AdminSettingsData adminSettingsData = new AdminSettingsData();
            return adminSettingsData.GetNewTurf(turfModel);

        }

        public List<TimeSloteModel> GetStartingTime(TimeSloteModel timeSloteModel)
        {
            AddNewTurfDataModel addNewTurfDataModel = new AddNewTurfDataModel();
            return addNewTurfDataModel.GetStartingTime(timeSloteModel);
        }
        public List<TimeSloteModel> GetEndingTime(TimeSloteModel timeSloteModel)
        {
            AddNewTurfDataModel addNewTurfDataModel = new AddNewTurfDataModel();
            return addNewTurfDataModel.GetEndingTime(timeSloteModel);
        }
        public void SaveNewTurf(TurfModel turfModel)
        {
            AdminSettingsData adminSettingsData = new AdminSettingsData();
            adminSettingsData.SaveNewTurf(turfModel);
        }

        public List<TurfCategoryModel> GetTurfType(TurfCategoryModel turfCategory)
        {
            AddNewTurfDataModel addNewTurfDataModel = new AddNewTurfDataModel();
            return addNewTurfDataModel.GetTurfType(turfCategory);
        }
    }
}

       
    
