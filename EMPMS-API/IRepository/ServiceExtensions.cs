using EMPMS_API.Repository;

namespace EMPMS_API.IRepository
{
    public static class ServiceExtensions
    {
       

        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Unit of work(repo list)
            services.AddTransient<IUnitOfWork, UnitOfWork>();

        }
    }
}
