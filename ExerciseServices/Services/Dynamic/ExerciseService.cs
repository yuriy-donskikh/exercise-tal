using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseServices.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Oxygen.Core.Common.Attributes;
using Oxygen.Core.Database.Interfaces;
using Oxygen.Core.Database.Providers;
using Data = ExerciseData.Entities;
using Models = ExerciseModel.Models;

namespace ExerciseServices.Services.Dynamic
{
    [DynamicService]
    public class ExerciseService
    {
        private readonly IMapper _mapper;
        private readonly IHelperService _helperService;
        private readonly IOxygenDbContext _context;

        public ExerciseService(IMapper mapper, DbContextResolver resolver, IHelperService helperService)
        {
            _mapper = mapper;
            _helperService = helperService;
            _context = resolver("ExerciseConnection");
        }

        public async Task<List<Models.Room>> GetRooms(CancellationToken cancellationToken)
        {
            var rooms = await _context.Get<Data.Room>().
                Include(i => i.Times).
                ToListAsync(cancellationToken);
            var result = _mapper.Map<List<Models.Room>>(rooms);
            result.ForEach(_helperService.TransformRoom);
            return result;
        }

        public async Task<Models.Room> AddRoom(Models.Room room, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Data.Room>(room);
            await _context.SaveEntitiesAsync<Data.Room>(cancellationToken, item);
            return await _helperService.GetRoom(item.RoomId, cancellationToken);
        }

        public async Task DeleteRoom(int id, CancellationToken cancellationToken)
        {
            var room = await _context.Get<Data.Room>().FirstOrDefaultAsync(i => i.RoomId == id, cancellationToken);
            await _context.DeleteEntitiesAsync(cancellationToken, room);
        }

        public async Task AddTime(int id, string time, CancellationToken cancellationToken)
        {
            await DeleteTime(id, time, cancellationToken);
            var item = new Data.RoomTime
            {
                RoomId = id,
                Time = TimeSpan.Parse(time)
            };
            await _context.SaveEntitiesAsync<Data.RoomTime>(cancellationToken, item);
        }

        public async Task DeleteTime(int id, string time, CancellationToken cancellationToken)
        {
            var item = await _context.Get<Data.RoomTime>()
                .FirstOrDefaultAsync(i => i.RoomId == id && i.Time == TimeSpan.Parse(time), cancellationToken);
            if (item != null)
            {
                await _context.DeleteEntitiesAsync(cancellationToken, item);
            }
        }
    }
}
