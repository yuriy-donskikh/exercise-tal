using System.Threading;
using System.Threading.Tasks;

namespace ExerciseServices.Services.Interfaces
{
    public interface IHelperService
    {
        Task<ExerciseModel.Models.Room> GetRoom(int id, CancellationToken cancellationToken);
        void TransformRoom(ExerciseModel.Models.Room room);
    }
}
