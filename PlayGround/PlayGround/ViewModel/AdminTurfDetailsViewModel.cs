using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BusinessLayer;
using EntityLayer;
using PlayGround.Commands;

namespace PlayGround.ViewModel
{
    public class AdminTurfDetailsViewModel : BaseViewModel
    {
        private string _findturfID;
        private string _turfsearch;
        public ObservableCollection<TurfModel> _turfDetailsoc;
        public ObservableCollection<TurfModel> TurfDetailsOC
        {
            get { return _turfDetailsoc; }
            set
            {
                if (_turfDetailsoc == value) return;
                _turfDetailsoc = value;
                onPropertyChanged(nameof(TurfDetailsOC));
            }
        }
        public ICommand AdminTurfDetailsCommands { get; set; }
        public string FindTurfID { get => _findturfID; set { _findturfID = value; onPropertyChanged("Find Turf ID"); } }
        public string TurfSearch { get => _turfsearch; set { _turfsearch = value; onPropertyChanged("Turf Search"); } }

        public AdminTurfDetailsViewModel()
        {
            AdminTurfDetailsCommands = new AdminTurfDetailsCommand(this);
            GetTurfDetails();
        }

        public void GetTurfDetails()
        {
            TurfDetailsOC = new ObservableCollection<TurfModel>();
            AdminTurfDetailsBusinessModel adminTurfDetailsBusinessModel = new AdminTurfDetailsBusinessModel();
            var query = adminTurfDetailsBusinessModel.GetTurfDetails();
            foreach (var item in query)
            {
                TurfModel turfModels = new TurfModel();
                turfModels.TurfID = item.TurfID;
                turfModels.TurfName = item.TurfName;
                turfModels.TurfCity = item.TurfCity;
                turfModels.TurfType = item.TurfType;
                turfModels.TurfPrice = item.TurfPrice;
                turfModels.EndTime = item.EndTime;
                turfModels.StartTime = item.StartTime;
                turfModels.TurfState = item.TurfState;
                if (item.TurfStatus == 1)
                    turfModels.TurfStatusName = "Active";
                else
                    turfModels.TurfStatusName = "Cancelled";
                TurfDetailsOC.Add(turfModels);
            }
        }
    }
}
