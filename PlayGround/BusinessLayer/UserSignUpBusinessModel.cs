using DataAccessLibrary;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserSignUpBusinessModel
    {
        public void SignUpDetails(UsersModel userModel)
        {
            UserSignUpData userSignUpData = new UserSignUpData();
            userSignUpData.SaveSignUpData(userModel);
        }
    }
}
