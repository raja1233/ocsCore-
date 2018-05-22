using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.DataAccessLayer.Entites
{
    public class Meta
    {
        public decimal TotalPages { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int DefaultPageSize { get; set; }
        public decimal TotalRecords { get; set; }
    }
}
