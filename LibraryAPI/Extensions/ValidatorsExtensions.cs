using Application.Validation;

namespace LibraryAPI.Extensions
{
    public static class ValidatorsExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddSingleton<BookValidator>();
            services.AddSingleton<IdValidator>();
            services.AddSingleton<IsbnValidator>();
            services.AddSingleton<AccountValidator>();
            services.AddSingleton<AuthorValidator>();

            return services;
        }
    }
}
