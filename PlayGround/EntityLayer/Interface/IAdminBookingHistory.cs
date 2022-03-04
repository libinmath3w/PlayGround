using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer
{
        public interface IAdminBookingHistory
        {
            List<BookingModel> GetBookingDetails(BookingModel bookingModel);
        }
    
}
