using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround.ViewModel
{
    public class AdminDashboardViewModel : BaseViewModel
    {
        private string _countTurf { get; set; }
        public string CountTurf { get => _countTurf; set { _countTurf = value; onPropertyChanged(nameof(CountTurf)); } }
        private string _countuser { get; set; }
        public string CountUser { get => _countuser; set { _countuser = value; onPropertyChanged(nameof(CountUser)); } }
        private string _countBooking { get; set; }
        public string CountBooking { get => _countBooking; set { _countBooking = value; onPropertyChanged(nameof(CountBooking)); } }

        public AdminDashboardViewModel()
        {
            GetAllCountData();
        }

        private void GetAllCountData()
        {
            AdminDashboardBusinessLayer adminDashboardBusiness = new AdminDashboardBusinessLayer();
            TurfModel turfModel = new TurfModel();
            var query = adminDashboardBusiness.GetCounts(turfModel);
            foreach (var item in query)
            {
                this.CountTurf = item.Total_turf_count;
                this.CountBooking = item.Total_booking_count;
                this.CountUser = item.Total_users_count;
            }

        }
    }
}