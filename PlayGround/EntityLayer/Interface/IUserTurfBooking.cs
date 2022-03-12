using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Interface
{
    public interface IUserTurfBooking
    {
        List<TurfModel> GetTurfDetails(TurfModel turfModel);
        List<TimeSloteModel> GetCurrentTimeDetails(TimeSloteModel timeSloteModel);
        List<TimeSloteModel> GetCurrentEndTimeDetails(TimeSloteModel timeSloteModel);
        List<TimeSloteModel> GetNonCurrentTimeDetails(TimeSloteModel timeSloteModel);
        List<TimeSloteModel> GetNonCurrentEndTimeDetails(TimeSloteModel timeSloteModel);

    }
}
