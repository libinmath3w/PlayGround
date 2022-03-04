using DataAccessLibrary;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserTurfBookingBusinessModel
    {
        public List<TurfModel> GetTurfDetails(TurfModel turfModel)
        {
            UserTurfBookingData userTurfBookingData = new UserTurfBookingData();
            return userTurfBookingData.GetTurfDetails(turfModel);
        }
    }
}
