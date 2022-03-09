using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Interface
{
    public interface IUserLogin
    {
        List<UsersModel> GetSignInDetails(UsersModel usersModel);
    }
}
