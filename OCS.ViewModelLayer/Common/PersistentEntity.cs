using JsonApiDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.ViewModelLayer.Common
{
    public class PersistentEntity : Identifiable<long>
    {
        [Attr("IsActive")]
        public bool IsActive { get; set; }

        [Attr("IsDeleted")]
        public bool IsDeleted { get; set; }

        [Attr("DeletedBy")]
        public long? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        [Attr("CreatedBy")]
        public long? CreatedBy { get; set; }

        [Attr("CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public long? UpdatedBy { get; set; }
    }
}
