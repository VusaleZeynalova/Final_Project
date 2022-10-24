using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using DAL.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using BLL.AutoMapperProfiles;
using BLL.Abstract;
using BLL.Concrete;
using DAL.Abstract;
using DAL.Concrete;
using DAL.UnitOfWorks;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
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

            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("AppDb"));
            });
            services.AddAutoMapper(typeof(Mapper));
            services.AddScoped<ITokenHelper, JwtHelper>();
           
            //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MahammadFinalProject", Version = "v1" });
            });
        }
    }

}
