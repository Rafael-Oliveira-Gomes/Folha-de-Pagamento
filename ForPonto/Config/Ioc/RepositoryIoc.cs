using ForPonto.Interface.Repository;
using ForPonto.Repository;

namespace ForPonto.Config.Ioc
{
    public static class RepositoryIoc
    {
        public static void ConfigRepositoryIoc(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPontoRepository, PontoRepository>();
            //services.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}