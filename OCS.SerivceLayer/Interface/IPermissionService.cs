using OCS.DataAccessLayer.Entites;
using OCS.ViewModelLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.SerivceLayer.Interface
{
    public interface IPermissionService
    {
        JsonModel getPermissions(ServiceRequest serviceRequest);

        JsonModel getAllModules(ServiceRequest serviceRequest);

        JsonModel savePermissions(List<PermissionViewModel> permissionViewModels);
    }
}
