using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround.ViewModel
{
    public class AdminTurfBookingHistoryViewModel : BaseViewModel
    {
        private List<BookingModel> _viewAdminTurfBookingsAndBookNew;
        public List<BookingModel> ViewAdminTurfBookingsAndBookNew { get => _viewAdminTurfBookingsAndBookNew; set => _viewAdminTurfBookingsAndBookNew = value; }

        public AdminBookingHistoryBusinessModel adminBookingHistoryBusinessModel = new AdminBookingHistoryBusinessModel();
        public AdminTurfBookingHistoryViewModel()
        {
            _viewAdminTurfBookingsAndBookNew = adminBookingHistoryBusinessModel.GetBookingDetails();
        }
    }
}
