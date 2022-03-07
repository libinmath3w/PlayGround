using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// to store user data
    /// </summary>
    public class UsersModel : BaseEntity
    {
        public int UserId { get; set;}
        public string UserName { get; set;}
        public string Name { get; set;}
        public string UserEmailID { get; set;}
        public string PhoneNumber { get; set;}
        public string Password { get; set;}
        public string ConfirmPassword { get; set;}
        public int Status { get; set;}
        public DateTime DateOfCreatedAccount { get; set;}
        public  int RoleID { get; set;}
        public string City { get; set;}
        public string State { get; set;}
        public string Zip { get; set;}
        public string Avatar { get; set;}
        public int UserMatch { get; set;}

    }
}
