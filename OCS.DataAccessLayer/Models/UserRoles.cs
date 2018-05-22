using JsonApiDotNetCore.Models;
using OCS.ViewModelLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OCS.DataAccessLayer.Models
{
    public class UserRoles
    {
        [Attr("RoleID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RoleID")]
        public long Id { get; set; }
        [StringLength(100)]
        [Attr("RoleName")]
        public string RoleName { get; set; }
        [Attr("UserType")]
        public string UserType { get; set; }
        [NotMapped]
        [Attr("value")]
        public string value { get { return this.RoleName; } }
        public bool IsDeleted { get; set; }
        public bool? IsActive { get; set; }

    }
}
