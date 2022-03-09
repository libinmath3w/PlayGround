using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Interface
{
    public interface IUserSignUp
    {
        void SaveSignUpDetails(UsersModel userModel);
        bool GetUserNameInfo(UsersModel userModel);
        bool GetUserEmailInfo(UsersModel userModel);

    }
}
