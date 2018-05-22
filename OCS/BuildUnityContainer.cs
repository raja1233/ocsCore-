using Microsoft.Extensions.DependencyInjection;
using OCS.RepositoryLayer.Common.Interface;
using OCS.RepositoryLayer.Common.Repository;
using OCS.RepositoryLayer.Interface;
using OCS.RepositoryLayer.Repositories;
using OCS.SerivceLayer.Interface;
using OCS.SerivceLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCS
{
    public static class BuildUnityContainer
    {
        public static IServiceCollection RegisterAddTransient(IServiceCollection services)
        {
            #region--Dependencies--
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<ITokenRepository, TokenRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserCommonRepository, UserCommonRepository>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICommonService, CommonService>();
            #endregion
            return services;
        }
    }
}
