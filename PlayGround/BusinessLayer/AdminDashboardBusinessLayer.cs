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
    public class AdminDashboardBusinessLayer : IAdminDashboard
    {
        AdminDashboardData adminDashboardData = new AdminDashboardData();

        public List<TurfModel> GetCounts(TurfModel turfModel)
        {
            return adminDashboardData.GetCounts(turfModel);
        }

        public List<TurfModel> GetUserCount(TurfModel turfModel)
        {
            return adminDashboardData.GetUserCount(turfModel);
        }
    }
}