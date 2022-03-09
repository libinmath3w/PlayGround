using BusinessLayer;
using EntityLayer;
using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlayGround.Commands
{
    public class AdminTurfDetailsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public AdminTurfDetailsViewModel adminTurfDetailsViewModel { get; set; }
        public AdminTurfDetailsCommand(AdminTurfDetailsViewModel viewModel)
        {
            adminTurfDetailsViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "AddNewTurfAdmin")
            {
                
            }
            else if (parameter.ToString() == "TurfSearch")
            {
                string SearchValue = adminTurfDetailsViewModel.TurfSearch;
                if (string.IsNullOrEmpty(SearchValue))
                {
                    MessageBox.Show("Enter a search keyword");
                    adminTurfDetailsViewModel.GetTurfDetails();
                }
                else
                {
                    TurfModel turfModel = new TurfModel();
                    AdminTurfDetailsBusinessModel adminTurfDetailsBusinessModel = new AdminTurfDetailsBusinessModel();
                    turfModel.TurfName = SearchValue;
                    var query = adminTurfDetailsBusinessModel.SearchTurfDetails(turfModel);
                    adminTurfDetailsViewModel.TurfDetailsOC = new System.Collections.ObjectModel.ObservableCollection<TurfModel>();
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
                        adminTurfDetailsViewModel.TurfDetailsOC.Add(turfModels);
                    }
                }
            }
            else if (parameter.ToString() == "DisableTurf")
            {
                string TurfIDInfo = adminTurfDetailsViewModel.FindTurfID;
                if (string.IsNullOrEmpty(TurfIDInfo))
                {
                    MessageBox.Show("Enter a Turf ID");
                    adminTurfDetailsViewModel.GetTurfDetails();
                }
                else
                {
                    TurfModel turfModel = new TurfModel();
                    AdminTurfDetailsBusinessModel adminTurfDetailsBusinessModel = new AdminTurfDetailsBusinessModel();
                    turfModel.TurfID = Convert.ToInt32(TurfIDInfo);
                    adminTurfDetailsBusinessModel.DisableTurf(turfModel);
                    adminTurfDetailsViewModel.GetTurfDetails();
                }
            }
            else if (parameter.ToString() == "EnableTurf")
            {
                string TurfIDInfo = adminTurfDetailsViewModel.FindTurfID;
                if (string.IsNullOrEmpty(TurfIDInfo))
                {
                    MessageBox.Show("Enter a Turf ID");
                    adminTurfDetailsViewModel.GetTurfDetails();
                }
                else
                {
                    TurfModel turfModel = new TurfModel();
                    AdminTurfDetailsBusinessModel adminTurfDetailsBusinessModel = new AdminTurfDetailsBusinessModel();
                    turfModel.TurfID = Convert.ToInt32(TurfIDInfo);
                    adminTurfDetailsBusinessModel.EnableTurf(turfModel);
                    adminTurfDetailsViewModel.GetTurfDetails();
                }
            }
        }
    }
}
