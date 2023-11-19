using Microsoft.Extensions.Options;

namespace AppSettingManager
{
    public static class ConfigurationExtension
    {
        public static void AddConfiguration<T>(this IServiceCollection services, IConfiguration configuration, string configTags = null) where T : class
        {
            if (string.IsNullOrEmpty(configTags))
            {
                configTags =  typeof(T).Name;
            }

            var intance = Activator.CreateInstance<T>();
            new ConfigureFromConfigurationOptions<T>(configuration.GetSection(configTags)).Configure(intance);

            services.AddSingleton<T>(intance);
        }
    }
}
