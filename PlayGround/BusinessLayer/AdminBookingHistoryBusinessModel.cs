using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Threading.Tasks;
using DataAccessLibrary;

namespace BusinessLayer
{
    public class AdminBookingHistoryBusinessModel : IAdminBookingHistory
    {
        public List<BookingModel> GetBookingDetails()
        {
           AdminBookingHistoryData adminBookingHistoryData = new AdminBookingHistoryData();
            return adminBookingHistoryData.GetBookingDetails();
        }
    }
    
}
