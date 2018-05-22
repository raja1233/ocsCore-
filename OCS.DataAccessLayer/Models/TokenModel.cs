using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.DataAccessLayer.Models
{
    public class TokenModel
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public long RoleID { get; set; }
        public int OrganizationID { get; set; }
        public int LocationID { get; set; }
        public int StaffID { get; set; }
        public string Timezone { get; set; }
        public string IPAddress { get; set; }
        public string DomainName { get; set; }
        public string MacAddress { get; set; }
        public int PateintID { get; set; }
        public HttpContext Request { get; set; }
    }
    public class DomainToken
    {
        public string BusinessToken { get; set; }
        public string HostName { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
