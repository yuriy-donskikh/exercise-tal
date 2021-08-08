using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExerciseData.Seeders.Interfaces;
using Microsoft.EntityFrameworkCore;
using Oxygen.Core.Database.Interfaces;
using Oxygen.Core.Database.Providers;

namespace ExerciseData.Seeders
{
    public abstract class BaseSeeder<T>:ISeeder where T : class, IEntityTypeConfiguration<T>
    {
        private readonly List<T> _seedingList = new();

        protected readonly IOxygenDbContext Context;
        protected BaseSeeder(DbContextResolver resolver)
        {
            Context = resolver("ExerciseConnection");
            Context.Database.EnsureCreated();
        }

        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            if (await Context.Get<T>().AnyAsync(cancellationToken))
            {
                return;
            }

            Seed();

            await Context.SaveEntitiesAsync<T>(cancellationToken, _seedingList);
        }

        public int Order => GetOrder();

        protected abstract int GetOrder();

        protected abstract void Seed(); 

        protected void Add(T instance)
        {
            _seedingList.Add(instance);
        }
    }
}
