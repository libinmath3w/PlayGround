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
        SaveUserDetails(UsersModel usersModel);
    }
}
