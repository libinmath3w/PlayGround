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
        AdminSettingsData adminsettingsdata = new AdminSettingsData();
        public List<UsersModel> GetUserDetails(UsersModel usersModel)
        {
            return adminsettingsdata.GetUserDetails(usersModel);
        }

        public void SaveAvatar(UsersModel usersModel)
        {
            adminsettingsdata.SaveAvatar(usersModel);
        }

        public void SaveUserDetails(UsersModel usersModel)
        {
            adminsettingsdata.SaveUserDetails(usersModel);
        }
    }
}
