using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class AdminDashboardData : IAdminDashboard
    {
        public List<TurfModel> GetCounts(TurfModel turfModel)
        {

            try
            {
                List<TurfModel> Counts = new List<TurfModel>();
                TurfModel turf = new TurfModel();
                TurfManagementDBEntities dBEntities = new TurfManagementDBEntities();
                var turfquery = (from turfCount in dBEntities.Turfs
                                 select turfCount).Count();
                turf.Total_turf_count = turfquery.ToString();

                var userquery = (from userCount in dBEntities.Users
                                 select userCount).Count();
                turf.Total_users_count = userquery.ToString();

                var bookingquery = (from bookingCount in dBEntities.Bookings
                                    select bookingCount).Count();
                turf.Total_booking_count = bookingquery.ToString();

                Counts.Add(turf);
                return Counts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}