using Microsoft.Extensions.DependencyInjection;

namespace Application.Service
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
           // services.AddScoped<IEmployeeService, EmployeeService>();
            //services.AddAutoMapper(typeof(EmployeeService));
        }
    }
}
