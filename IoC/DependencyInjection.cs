using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using DAL.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using BLL.AutoMapperProfiles;
using BLL.Abstract;
using BLL.Concrete;
using DAL.Abstract;
using DAL.Concrete;
using Core.GenericRepositories;

namespace IoC
{
    public class DependencyInjection
    {
        private readonly IConfiguration _configuration;
        public DependencyInjection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void RegisterServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("AppDb"));
            });
            services.AddAutoMapper(typeof(Mapper));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MahammadFinalProject", Version = "v1" });
            });
        }
    }

}
