using System.Threading;
using System.Threading.Tasks;

namespace ExerciseData.Seeders.Interfaces
{
    public interface ISeeder
    {
        Task SeedAsync(CancellationToken cancellationToken);
        int Order { get; }
    }
}
