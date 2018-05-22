using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.SerivceLayer.Mapping
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile(new MapperProfileConfiguration()));
        }
    }
}
