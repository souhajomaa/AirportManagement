using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AM.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static string GetJsonConnectionString(this DbContext context, string configFileName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFileName, optional: false);

            var config = builder.Build();

            return config.GetConnectionString("Default");
        }
    }
}
