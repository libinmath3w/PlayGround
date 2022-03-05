using BusinessLayer;
using EntityLayer;
using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayGround.Commands
{
    public class TurfBookingCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public UserNewTurfBookingViewModel userNewTurfBookingViewModel { get; set; }

        public TurfBookingCommand(UserNewTurfBookingViewModel usernewTurfBookingViewModel)
        {
            userNewTurfBookingViewModel = usernewTurfBookingViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Search")
            {
                UserTurfBookingBusinessModel userTurfBookingBusinessModel = new UserTurfBookingBusinessModel();
                TurfModel turfModel = new TurfModel();
                turfModel.TurfCity = userNewTurfBookingViewModel.SearchTerm;
                userNewTurfBookingViewModel.ViewUserNewTurfBooking = userTurfBookingBusinessModel.GetTurfDetails(turfModel);
            }
        }
    }
}
