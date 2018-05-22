using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.ViewModelLayer.Common
{
    public class PermissionManagerViewModel
    {
        public string RoleName { get; set; }

        public List<PermissionViewModel> PermissionsList { get; set; }
    }
}
