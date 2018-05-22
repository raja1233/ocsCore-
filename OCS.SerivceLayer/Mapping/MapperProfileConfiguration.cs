using AutoMapper;
using OCS.DataAccessLayer.Models;
using OCS.ViewModelLayer.UserRole;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.SerivceLayer.Mapping
{
    class MapperProfileConfiguration : Profile
    {
        public MapperProfileConfiguration()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<UserRoles, UserRoleViewModel>();
            CreateMap<UserRoleViewModel, UserRoles>();
        }
    }
}
