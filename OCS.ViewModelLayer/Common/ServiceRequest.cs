using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.ViewModelLayer.Common
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public object Data { get; set; }

        public long? UserId { get; set; }

        public long? businessId { get; set; }
    }
}
