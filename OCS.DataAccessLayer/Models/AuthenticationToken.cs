using JsonApiDotNetCore.Models;
using OCS.ViewModelLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OCS.DataAccessLayer.Models
{
    public class AuthenticationToken : PersistentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AuthenticationTokenID")]
        [Attr("AuthenticationTokenID")]
        public override long Id { get; set; }
        [Required]
        [ForeignKey("User1")]
        [Attr("UserID")]
        public long UserID { get; set; }
        [Attr("Token")]
        [StringLength(500)]
        public string Token { get; set; }
        [Attr("ResetPasswordToken")]
        [StringLength(500)]
        public string ResetPasswordToken { get; set; }
    }
}
