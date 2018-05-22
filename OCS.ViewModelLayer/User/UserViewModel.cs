using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.ViewModelLayer.UserRole
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? AccessFailedCount { get; set; }
        public bool? IsBlock { get; set; }
        public DateTime? BlockDateTime { get; set; }
        public long? RoleID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string MobilePhone { get; set; }

        public string ProfilePic { get; set; }
        public string RoleName { get; set; }

    }
}
