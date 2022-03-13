using BusinessLayer;
using DataAccessLibrary;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlayGround.ViewModel
{
    public class UserDashboardViewModel : BaseViewModel
    {
        public UsersModel Users = new UsersModel();
        private string _countUserTurf { get; set; }
        public string CountUserTurf { get => _countUserTurf; set { _countUserTurf = value; onPropertyChanged(nameof(CountUserTurf)); } }
        private string _countUserBooking { get; set; }
        public string CountUserBooking { get => _countUserBooking; set { _countUserBooking = value; onPropertyChanged(nameof(CountUserBooking)); } }


        public UserDashboardViewModel(UsersModel usersModel)
        {
            AdminDashboardBusinessLayer adminDashboardBusiness = new AdminDashboardBusinessLayer();
            TurfModel turfModel = new TurfModel();
            Users.UserId = usersModel.UserId;
            turfModel.UserId = usersModel.UserId;
            var query = adminDashboardBusiness.GetUserCount(turfModel);
            foreach (var user in query)
            {
                this.CountUserTurf = user.Total_turf_count;
                this.CountUserBooking = user.Total_booking_count;
            }


        }
    }
}
