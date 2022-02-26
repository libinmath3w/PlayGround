using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// to store datas of Booking
    /// </summary>
    public class BookingModel
    {

        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int TurfID { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public float Amount { get; set; }
        public int PaymentID { get; set; }
        public DateTime BookingDate { get; set; }
        public int PaymentStatus { get; set; }
        public DateTime BookingTime { get; set; }
        public bool BookingStatus { get; set ; }
    }
}
