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
    public class UserNewTurfBookingViewModel : BaseViewModel
    {
        private string _searchTerm;
        
        public ObservableCollection<TurfModel> _turfDetails = new ObservableCollection<TurfModel>();
        public ObservableCollection<TurfModel> TurfSearchDetails { get { return _turfDetails; } 
            set 
            {
                if (_turfDetails == value) return;
                _turfDetails = value;
                onPropertyChanged(nameof(TurfSearchDetails));
            }
        }
        private List<TurfModel> _viewUserNewTurfBooking;
        public List<TurfModel> ViewUserNewTurfBooking { get => _viewUserNewTurfBooking; set => _viewUserNewTurfBooking = value; }
        
        public UserTurfBookingBusinessModel userTurfBookingBusinessModel = new UserTurfBookingBusinessModel();
        public ICommand TurfBookingCommands { get; set; }
        public string SearchTerm { get => _searchTerm; set {  _searchTerm = value; onPropertyChanged("Search box"); } }


        private ObservableCollection<TimeSloteModel> _turfOpeningTime = new ObservableCollection<TimeSloteModel>();
        public ObservableCollection<TimeSloteModel> TurfOpeningTime
        {
            get { return _turfOpeningTime; }
            set
            {
                if (_turfOpeningTime == value) return;
                _turfOpeningTime = value;
                onPropertyChanged(nameof(TurfOpeningTime));
            }
        }

        private ObservableCollection<TimeSloteModel> _turfClosingTime = new ObservableCollection<TimeSloteModel>();
        public ObservableCollection<TimeSloteModel> TurfClosingTime
        {
            get { return _turfClosingTime; }
            set
            {
                if (_turfClosingTime == value) return;
                _turfClosingTime = value;
                onPropertyChanged(nameof(TurfClosingTime));
            }
        }



        private ObservableCollection<PaymentTypeModel> _paymentType = new ObservableCollection<PaymentTypeModel>();
        public ObservableCollection<PaymentTypeModel> PaymentType
        {
            get { return _paymentType; }
            set
            {
                if (_paymentType == value) return;
                _paymentType = value;
                onPropertyChanged(nameof(PaymentType));
            }
        }

        public UserNewTurfBookingViewModel()
        {
            TurfBookingCommands = new TurfBookingCommand(this);
            TimeSloteModel timeModel = new TimeSloteModel();
            PaymentTypeModel payment = new PaymentTypeModel();
            
            var query1 = userTurfBookingBusinessModel.GetOpeningTime(timeModel);
            var query2 = userTurfBookingBusinessModel.GetClosingTime(timeModel);
            var query3 = userTurfBookingBusinessModel.GetPaymentType(payment);

            foreach (var item in query1)
            {
                TimeSloteModel timeModels = new TimeSloteModel();
                timeModels.TimeSlots = item.TimeSlots;
                TurfOpeningTime.Add(timeModels);   
            }
            
            foreach (var item in query2)
            {
                TimeSloteModel timeModels = new TimeSloteModel();
                timeModels.TimeSlots = item.TimeSlots;
                TurfClosingTime.Add(timeModels);
            }

            foreach (var item in query3)
            {
                PaymentTypeModel payments = new PaymentTypeModel();
                payments.PaymentMethod = item.PaymentMethod;
                PaymentType.Add(payments);
            }

        }
        public void TurfFillData(object param)
        {

        }
    }
}
