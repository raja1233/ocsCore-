using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.DataAccessLayer.Entites
{
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
