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
        public string Name { get; set; }
        public int TurfID { get; set; }
        public string TurfName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public float Amount { get; set; }
        public int PaymentID { get; set; }
        public string PaymentType { get; set; }
        public string BookingDate { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime BookingTime { get; set; }
        public bool BookingStatus { get; set ; }
        public string Avatar { get; set; }
    }
}
