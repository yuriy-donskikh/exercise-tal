using System;
using System.Linq;
using ExerciseData.Seeders.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExerciseApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Oxygen.Core.Runtime.Application.OxygenCoreProgram<Startup>.Main(args, InitDataBase);
        }

        private static void InitDataBase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var provider = scope.ServiceProvider;
            try
            {
                var seeders = provider.GetServices<ISeeder>().ToList();
                foreach (var seeder in seeders.OrderBy(i=>i.Order))
                {
                    seeder.SeedAsync(default).GetAwaiter().GetResult();
                }
            }
            catch (Exception e)
            {
                var logger = provider.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "An error occurred during Creating or Seeding DB!");
            }
        }
    }
}
