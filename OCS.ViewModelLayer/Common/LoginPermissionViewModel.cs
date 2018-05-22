using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.ViewModelLayer.Common
{
    public class LoginPermissionViewModel
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public long BusinessId { get; set; }
        public long UserId { get; set; }

        public string RoleName { get; set; }

        public List<PermissionLoginViewModel> Permissions { get; set; }
    }
}
