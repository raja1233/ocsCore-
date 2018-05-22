using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.DataAccessLayer.Entites
{
    public class JsonModel
    {
        public string access_token;
        public int expires_in;
        public object data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object UserPermission { get; set; }
        public object AppConfigurations { get; set; }
        public object UserLocations { get; set; }
        public Meta meta { get; set; }
        public string AppError { get; set; }
        public bool firstTimeLogin { get; set; }
        public bool isSuccess { get; set; }
    }
}
