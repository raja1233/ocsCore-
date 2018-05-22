using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.ViewModelLayer.Common
{
    public class ModuleViewModel
    {
        public long? Id { get; set; }

        public string ModuleName { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
