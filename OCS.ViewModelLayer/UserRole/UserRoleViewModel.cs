using OCS.ViewModelLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.ViewModelLayer.UserRole
{
    public class UserRoleViewModel : PersistentEntity
    {
        public string RoleName { get; set; }

        public string UserType { get; set; }

        public string value { get { return this.RoleName; } }

    }
}
