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

        public List<TimeSloteModel> GetStartingTime()
        {
            return addNewTurfDataModel.GetStartingTime();
        }
        public List<TimeSloteModel> GetEndingTime()
        {
            return addNewTurfDataModel.GetEndingTime();
        }
        public void SaveNewTurf(TurfModel turfModel)
        {
            adminSettingsData.SaveNewTurf(turfModel);
        }

        public List<TurfCategoryModel> GetTurfType()
        {
            return addNewTurfDataModel.GetTurfType();
        }

        public void AddNewTurf(TurfModel turfModel)
        {
            addNewTurfDataModel.AddNewTurf(turfModel);
        }
        public List<TurfModel> GetTurfDetails(TurfModel turfModel)
        {
            return addNewTurfDataModel.GetTurfDetails(turfModel);
        }
        public void UpdateTurf(TurfModel turfModel)
        {
            addNewTurfDataModel.UpdateTurf(turfModel);
        }
    }
}

       
    
