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
        UserSettingsData usersettingsdata = new UserSettingsData();
        public List<UsersModel> GetUserDetails(UsersModel usersModel)
        {
            return usersettingsdata.GetUserDetails(usersModel);
        }

        public void SaveAvatar(UsersModel usersModel)
        {
            usersettingsdata.SaveAvatar(usersModel);
        }

        public void SaveUserDetails(UsersModel usersModel)
        {
            usersettingsdata.SaveUserDetails(usersModel);
        }

    }
}
