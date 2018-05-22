using JsonApiDotNetCore.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OCS.ViewModelLayer.Common;

namespace OCS.DataAccessLayer.Models
{
    public class User : PersistentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserID")]
        [Attr("UserID")]
        public override long Id { get; set; }
        [Attr("UserName")]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Attr("Password")]
        public string Password { get; set; }
        [Attr("AccessFailedCount")]
        public int AccessFailedCount { get; set; }
        [Attr("IsBlock")]
        public bool IsBlock { get; set; }
        [Attr("BlockDate")]
        public DateTime? BlockDateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string ProfilePic { get; set; }
        [Required]
        [ForeignKey("UserRoles")]
        [Attr("RoleID")]
        public long RoleID { get; set; }
        [NotMapped]
        [Attr("RoleName")]
        public string RoleName { get; set; }
        [HasOne("userroles")]
        public UserRoles UserRoles { get; set; }
    }
}
