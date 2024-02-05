using User.Application;
using User.Infrastructure;

namespace User.API.ServiceExtensions
{
    public static class UserDependencyService
    {
        public static void AddUserDependencyService(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddScoped<IUserQueryService, UserQueryService>();
            services.AddScoped<ICreateUserCommand, CreateUserCommand>();
        }
    }
}
