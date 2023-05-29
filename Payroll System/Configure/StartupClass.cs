using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Payroll_System.Auth.Identity;
using Payroll_System.Auth.Service;
using Payroll_System.Context;
using Payroll_System.Identity;
using Payroll_System.Implementation.Repositories;
using Payroll_System.Implementation.Services;
using Payroll_System.Interface.Repositories;
using Payroll_System.Interface.Services;

namespace Roqeeb_Project.Configure
{
    public static class StartupClass
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));
            return services;

        }
        public static IServiceCollection MyScoped(this IServiceCollection services)
        {
            services.AddScoped<IUserStore<User>, UserRepository>();
            services.AddScoped<IUserRoleStore<User>, UserRepository>();
            services.AddScoped<IUserEmailStore<User>, UserRepository>();
            services.AddScoped<IQueryableUserStore<User>, UserRepository>();
            services.AddScoped<IUserPhoneNumberStore<User>, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleStore<Role>, RoleRepository>();
            services.AddIdentity<User, Role>().AddDefaultTokenProviders();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRespository, EmployeeRepository>();
            services.AddScoped<ICadreLevelService, CadreLevelService>();
            services.AddScoped<ICadreLevelRepository, CadreLevelRepository>();
            services.AddScoped<IEarningsRepository, EarningsRepository>();
            services.AddScoped<IDeductionRepository, DeductionRepository>();
            return services;
        }
    }
}
