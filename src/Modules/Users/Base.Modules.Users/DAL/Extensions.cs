using AutoMapper;
using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.DAL.Services;
using Base.Modules.Users.Domain.DTO.User;
using Base.Modules.Users.Domain.IServices;
using Base.Modules.Users.Domain.Mapping;
using Base.Shared.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL
{
    public static class Extensions
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services)
        {

            services.AddSingleton(new MapperConfiguration(config => config.AddProfile(new CustomPowerProfile())).CreateMapper());
            services.AddSingleton(new MapperConfiguration(config => config.AddProfile(new TreePowerProfile())).CreateMapper());
            services.AddSingleton(new MapperConfiguration(config => config.AddProfile(new UserProfile())).CreateMapper());

            services.AddPostgres<UsersDbContext>();
            services.AddTransient<ITreePowesService, TreePowesService>();
            services.AddTransient<ICustomPowersService, CustomPowerService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IUserSettingsService, UserSettingsService>();

            return services;
        }

    }
}
