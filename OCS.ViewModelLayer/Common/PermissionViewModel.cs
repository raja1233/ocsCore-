using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.ViewModelLayer.Common
{
    public class PermissionViewModel
    {
        public long? Id { get; set; }

        public long? RoleId { get; set; }

        public UserRolesViewModel Roles { get; set; }

        public long? ModuleId { get; set; }

        public ModuleViewModel Modules { get; set; }


        public bool? CanView { get; set; }
    }
}
