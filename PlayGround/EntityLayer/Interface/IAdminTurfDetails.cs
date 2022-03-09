using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Interface
{
    public interface IAdminTurfDetails
    {
        List<TurfModel> GetTurfDetails();
        List<TurfModel> SearchTurfDetails(TurfModel turfModel);
        void EnableTurf(TurfModel turfModel);
        void DisableTurf(TurfModel turfModel);
    }
}
