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
    public class BookingModel : BaseEntity
    {
        private int _bookingID;
        private int _userID;
        private string _name;
        private int _turfID;
        private string _turfName;
        private string _startTime;
        private string _endTime;
        private float _amount;
        private int _paymentID;
        private string _paymentType;
        private string _bookingDate;
        private string _paymentStatus;
        private DateTime _bookingTime;
        private bool _bookingStatus;
        private string _bStatus;
        private string _avatar;

        public int BookingID { get => _bookingID; set { _bookingID = value; onPropertyChanged("Booking ID"); } }
        public int UserID { get => _userID; set { _userID = value; onPropertyChanged("User ID"); } }
        public string Name { get => _name; set { _name = value; onPropertyChanged("Name"); } }
        public int TurfID { get => _turfID; set { _turfID = value; onPropertyChanged("Turf ID"); } }
        public string TurfName { get => _turfName; set { _turfName = value; onPropertyChanged("Turf Name"); } }
        public string StartTime { get => _startTime; set { _startTime = value; onPropertyChanged("Start Time"); } }
        public string EndTime { get => _endTime; set { _endTime = value; onPropertyChanged("End Time"); } }
        public float Amount { get => _amount; set { _amount = value; onPropertyChanged("Amount"); } }
        public int PaymentID { get => _paymentID; set { _paymentID = value; onPropertyChanged("Payment ID"); } }
        public string PaymentType { get => _paymentType; set { _paymentType = value; onPropertyChanged("Payment Type"); } }
        public string BookingDate { get => _bookingDate; set { _bookingDate = value; onPropertyChanged("Booking Date"); } }
        public string PaymentStatus { get => _paymentStatus; set { _paymentStatus = value; onPropertyChanged("Payment Status"); } }
        public DateTime BookingTime { get => _bookingTime; set { _bookingTime = value; onPropertyChanged("Booking Time"); } }
        public bool BookingStatus { get => _bookingStatus; set { _bookingStatus = value; onPropertyChanged("Booking Status"); } }
        public string BStatus { get => _bStatus; set { _bStatus = value; onPropertyChanged("B Status"); } }
        public string Avatar { get => _avatar; set { _avatar = value; onPropertyChanged("Avatar"); } }
    }
}
