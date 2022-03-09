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
    public class AdminTurfDetailsBusinessModel : IAdminTurfDetails
    {
        AdminTurfDetailsData adminTurfDetailsData = new AdminTurfDetailsData();

        public void DisableTurf(TurfModel turfModel)
        {
            adminTurfDetailsData.DisableTurf(turfModel);
        }

        public void EnableTurf(TurfModel turfModel)
        {
            adminTurfDetailsData.EnableTurf(turfModel);
        }

        public List<TurfModel> GetTurfDetails()
        {
            return adminTurfDetailsData.GetTurfDetails();
        }

        public List<TurfModel> SearchTurfDetails(TurfModel turfModel)
        {
            return adminTurfDetailsData.SearchTurfDetails(turfModel);
        }
    }
}
