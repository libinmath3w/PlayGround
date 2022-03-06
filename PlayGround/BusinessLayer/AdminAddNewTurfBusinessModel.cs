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

        public void SaveNewTurf(TurfModel turfModel)
        {
            AdminSettingsData adminSettingsData = new AdminSettingsData();
            adminSettingsData.SaveNewTurf(turfModel);
        }
    }
}

       
    
