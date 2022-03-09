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
    public class UserSignInBusinessModel : IUserLogin
    {
        UserSignInData userSignInData = new UserSignInData();
        public List<UsersModel> GetSignInDetails(UsersModel usersModel)
        {
            return userSignInData.GetSignInDetails(usersModel);
        }

    }
}
