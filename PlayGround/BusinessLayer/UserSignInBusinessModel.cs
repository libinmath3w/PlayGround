using DataAccessLibrary;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserSignInBusinessModel
    {
        public void SignInDetails(UsersModel userModel)
        {
            UserSignInData userSignInData = new UserSignInData();
            userSignInData.SaveSignInData(userModel);
        }
    }
}
