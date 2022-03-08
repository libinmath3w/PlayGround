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


        private ObservableCollection<TimeSloteModel> _timeSloteModels = new ObservableCollection<TimeSloteModel>();
        public ObservableCollection<TimeSloteModel> TimeSloteModels
        {
            get { return _timeSloteModels; }
            set
            {
                if (_timeSloteModels == value) return;
                _timeSloteModels = value;
                onPropertyChanged(nameof(TimeSloteModels));
            }
        }

        private List<TimeSloteModel> _timeSlotes;

        public List<TimeSloteModel> TimeSlotes { get { return _timeSlotes; } set { _timeSlotes = value;} }


        public UserNewTurfBookingViewModel()
        {
            TurfBookingCommands = new TurfBookingCommand(this);
            TimeSloteModel timeModel = new TimeSloteModel();
            timeModel.TimeID = 1;
            var query = userTurfBookingBusinessModel.GetOpeningTime(timeModel);
            foreach (var item in query)
            {  
                TimeSloteModel timeSloteModel = new TimeSloteModel();
                timeSloteModel.TimeID = item.TimeID;
                timeSloteModel.TimeSlots = item.TimeSlots;
                TimeSloteModels.Add(timeSloteModel);
            }

        }
        public void TurfFillData(object param)
        {

        }
    }
}
