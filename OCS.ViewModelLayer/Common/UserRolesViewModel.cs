using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.ViewModelLayer.Common
{
    public class UserRolesViewModel : PersistentEntity
    {

        public string RoleName { get; set; }

        public string UserType { get; set; }

        public string value { get { return this.RoleName; } }

        public long? BusinessId { get; set; }
    }
}
