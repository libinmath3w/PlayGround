using DataAccessLibrary;
using EntityLayer;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AdminSettingsBusinessModel : IUserSettings
    {
        public List<UsersModel> GetUserDetails(UsersModel usersModel)
        {
            AdminSettingsData usersettingsdata = new AdminSettingsData();
            return usersettingsdata.GetUserDetails(usersModel);
        }

        public void SaveUserDetails(UsersModel usersModel)
        {
            AdminSettingsData usersettingsdata = new AdminSettingsData();
            usersettingsdata.SaveUserDetails(usersModel);
        }
    }
}
