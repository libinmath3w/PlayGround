using BusinessLayer;
using EntityLayer;
using PlayGround.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayGround.ViewModel
{
    public class AdminTurfBookingHistoryViewModel : BaseViewModel
    {
        private string _search;
        private string _findbyid;
        public string SearchName { get => _search; set { _search = value; onPropertyChanged("Search Name"); } }
        public string FindBookingID { get => _findbyid; set { _findbyid = value; onPropertyChanged("Find Booking ID"); } }
        public ICommand AdminTurfBookingDetailsCommands { get; set; }
        public ObservableCollection<BookingModel> _bookingDetailsoc;
        public ObservableCollection<BookingModel> BookingDetailsOC
        {
            get { return _bookingDetailsoc; }
            set
            {
                if (_bookingDetailsoc == value) return;
                _bookingDetailsoc = value;
                onPropertyChanged(nameof(BookingDetailsOC));
            }
        }
        public AdminBookingHistoryBusinessModel adminBookingHistoryBusinessModel = new AdminBookingHistoryBusinessModel();
        public AdminTurfBookingHistoryViewModel()
        {
            AdminTurfBookingDetailsCommands = new AdminTurfBookingDetailsCommand(this);
            getTurfBookingDetails();
        }

        public void getTurfBookingDetails()
        {
            BookingDetailsOC = new ObservableCollection<BookingModel>();
            var query = adminBookingHistoryBusinessModel.GetBookingDetails();
            foreach (var item in query)
            {
                BookingModel bookingModel = new BookingModel();
                bookingModel.BookingID = item.BookingID;
                bookingModel.TurfName = item.TurfName;
                bookingModel.Name = item.Name;
                bookingModel.PaymentStatus = item.PaymentStatus;
                bookingModel.PaymentType = item.PaymentType;
                bookingModel.StartTime = item.StartTime;
                bookingModel.EndTime = item.EndTime;
                bookingModel.BookingStatus = item.BookingStatus;
                bookingModel.Amount = item.Amount;
                bookingModel.BookingDate = item.BookingDate;
                bookingModel.BStatus = item.BStatus;
                BookingDetailsOC.Add(bookingModel);
            }

        }
        
    }
}
