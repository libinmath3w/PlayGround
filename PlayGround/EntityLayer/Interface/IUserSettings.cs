using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Interface
{
    public interface IUserSettings
    {
        List<UsersModel> GetUserDetails(UsersModel usersModel);
        void SaveUserDetails(UsersModel usersModel);
        void SaveAvatar(UsersModel usersModel);
        List<UsersModel> GetUserPasswordDetails(UsersModel usersModel);
        void UpdatePassword(UsersModel usersModel);
    }
}
