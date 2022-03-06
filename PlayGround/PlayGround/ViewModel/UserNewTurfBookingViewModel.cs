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
        private List<TurfModel> _viewUserNewTurfBooking;
        public ObservableCollection<TurfModel> _turfDetails = new ObservableCollection<TurfModel>();
        public ObservableCollection<TurfModel> TurfSearchDetails { get { return _turfDetails; } 
            set 
            {
                if (_turfDetails == value) return;
                _turfDetails = value;
                onPropertyChanged(nameof(TurfSearchDetails));
            }
        }
        public List<TurfModel> ViewUserNewTurfBooking { get => _viewUserNewTurfBooking; set => _viewUserNewTurfBooking = value; }

        public UserTurfBookingBusinessModel userTurfBookingBusinessModel = new UserTurfBookingBusinessModel();
        public ICommand TurfBookingCommands { get; set; }
        public string SearchTerm { get => _searchTerm; set {  _searchTerm = value; onPropertyChanged("Search box"); } }

        public UserNewTurfBookingViewModel()
        {
            TurfBookingCommands = new TurfBookingCommand(this);
        }
        public void TurfFillData(object param)
        {

        }
    }
}
