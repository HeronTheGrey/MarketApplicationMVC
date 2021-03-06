using FluentValidation;
using MarketApplicationMVC.Application.Interfaces;
using MarketApplicationMVC.Application.Services;
using MarketApplicationMVC.Application.ViewModel.Forum;
using MarketApplicationMVC.Application.ViewModel.Market;
using MarketApplicationMVC.Application.ViewModel.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static MarketApplicationMVC.Application.ViewModel.Market.NewThreadVm;

namespace MarketApplicationMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IForumService, ForumService>();
            services.AddTransient<IMarketService, MarketService>();
            services.AddTransient <IUserService, UserService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //FluentValidation dependencies
            services.AddTransient<IValidator<NewThreadVm>, NewThreadValidator>();
            services.AddTransient<IValidator<NewOfferVm>, NewOfferValidator>();
            services.AddTransient<IValidator<NewPostVm>, NewPostValidator>(); 
            services.AddTransient<IValidator<OfferForEditVm>, OfferForEditValidator>();
            return services;
        }
    }
}
