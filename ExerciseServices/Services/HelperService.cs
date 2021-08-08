using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseServices.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Oxygen.Core.Database.Interfaces;
using Oxygen.Core.Database.Providers;

namespace ExerciseServices.Services
{
    public class HelperService : IHelperService
    {
        private readonly IMapper _mapper;
        private readonly IOxygenDbContext _context;

        public HelperService(IMapper mapper, DbContextResolver resolver)
        {
            _mapper = mapper;
            _context = resolver("ExerciseConnection");
        }

        public async Task<ExerciseModel.Models.Room> GetRoom(int id, CancellationToken cancellationToken)
        {
            var rooms = await _context.Get<ExerciseData.Entities.Room>()
                .Where(i => i.RoomId == id)
                .Include(i => i.Times)
                .FirstOrDefaultAsync(cancellationToken);
            var result = _mapper.Map<ExerciseModel.Models.Room>(rooms);
            TransformRoom(result);
            return result;
        }

        public void TransformRoom(ExerciseModel.Models.Room room)
        {
            var time = room.Start;
            while (time < room.End)
            {
                if (!room.Times.Exists(i => i.Time == time))
                {
                    room.Times.Add(new ExerciseModel.Models.RoomTime { Time = time, Available = true });
                }
                time = time.Add(new TimeSpan(0, 30, 0));
            }

            room.Times = room.Times.OrderBy(i => i.Time).ToList();
        }

    }
}
