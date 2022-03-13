using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Interface
{
    public interface IAdminDashboard
    {
        List<TurfModel> GetCounts(TurfModel turfModel);
        List<TurfModel> GetUserCount(TurfModel turfModel);
    }
}