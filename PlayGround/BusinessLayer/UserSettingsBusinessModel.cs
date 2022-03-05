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
    public class UserSettingsBusinessModel : IUserSettings
    {
        public List<UsersModel> GetUserDetails(UsersModel usersModel)
        {
            UserSettingsData usersettingsdata = new UserSettingsData();
            return usersettingsdata.GetUserDetails(usersModel);
        }
        public void SaveUserDetails(UsersModel usersModel)
        {
            UserSettingsData usersettingsdata = new UserSettingsData();
            usersettingsdata.SaveUserDetails(usersModel);
        }

    }
}
