using ForPonto.Interface.Service;
using ForPonto.Service;

namespace ForPonto.Config.Ioc
{
    public static class ServiceIoc
    {
        public static void ConfigServiceIoc(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPontoService, PontoService>();
            services.AddHttpContextAccessor();

        }
    }
}