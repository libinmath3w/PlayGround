using DataAccessLibrary;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AdminDashboardBusinessLayer
    {
        public List<TurfModel> GetCounts(TurfModel turfModel)
        {
            AdminDashboardData adminDashboardData = new AdminDashboardData();
            return adminDashboardData.GetCounts(turfModel);
        }
    }
}