using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Interface
{
    public interface IAddNewTurf
    {
        void SaveNewTurf(TurfModel turfModel);

        List<TimeSloteModel> GetStartingTime();
        List<TimeSloteModel> GetEndingTime();
        List<TurfCategoryModel> GetTurfType();
        void AddNewTurf(TurfModel turfModel);
        List<TurfModel> GetTurfDetails(TurfModel turfModel);
        void UpdateTurf(TurfModel turfModel);

    }
}
