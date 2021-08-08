using System;
using System.Linq;
using ExerciseData.Entities;
using Oxygen.Core.Database.Providers;

namespace ExerciseData.Seeders
{
    public class RoomTimeSeeder:BaseSeeder<RoomTime>
    {
        public RoomTimeSeeder(DbContextResolver resolver) : base(resolver)
        {
        }

        protected override int GetOrder() => 1;

        protected override void Seed()
        {
            var room = Context.Get<Room>().FirstOrDefault();
            if(room == null) return;
            Add(new RoomTime
            {
                RoomId = room.RoomId,
                Time = new TimeSpan(11, 0, 0)
            });
            Add(new RoomTime
            {
                RoomId = room.RoomId,
                Time = new TimeSpan(12, 0, 0)
            });
            Add(new RoomTime
            {
                RoomId = room.RoomId,
                Time = new TimeSpan(12, 30, 0)
            });
            Add(new RoomTime
            {
                RoomId = room.RoomId,
                Time = new TimeSpan(15, 0, 0)
            });
        }
    }
}
