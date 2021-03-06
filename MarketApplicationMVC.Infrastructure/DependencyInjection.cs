using MarketApplicationMVC.Domain.Interface;
using MarketApplicationMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IMarketRepository, MarketRepository>();
            services.AddTransient<IForumRepository, ForumRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
