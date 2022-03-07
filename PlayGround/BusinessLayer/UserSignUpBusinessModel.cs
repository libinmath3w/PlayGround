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
    public class UserSignUpBusinessModel : IUserSignUp
    {
        UserSignUpData userSignUpData = new UserSignUpData();

        public bool GetUserEmailInfo(UsersModel userModel)
        {
            return userSignUpData.GetUserEmailInfo(userModel);
        }

        public bool GetUserNameInfo(UsersModel userModel)
        {
            return userSignUpData.GetUserNameInfo(userModel);
        }

        public void SaveSignUpDetails(UsersModel userModel)
        {
            userSignUpData.SaveSignUpDetails(userModel);
        }
    }
}
