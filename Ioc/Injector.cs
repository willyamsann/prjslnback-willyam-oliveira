using Data.Repository;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using System;

namespace Ioc
{
    public static class Injector
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        }
    }
}
