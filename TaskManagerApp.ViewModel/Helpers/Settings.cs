using Microsoft.Extensions.Configuration;

namespace TaskManager.ViewModel.Helpers
{
    public static class Settings
    {
        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }
    }
}
