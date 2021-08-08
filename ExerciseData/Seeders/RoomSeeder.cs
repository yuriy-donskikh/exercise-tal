using System;
using ExerciseData.Entities;
using Oxygen.Core.Database.Providers;

namespace ExerciseData.Seeders
{
    public class RoomSeeder: BaseSeeder<Room>
    {
        public RoomSeeder(DbContextResolver resolver) : base(resolver)
        {
        }

        protected override int GetOrder() => 0;

        protected override void Seed()
        {
            Add(new Room
            {
                Name = "Room 1",
                Start = new TimeSpan(9, 0, 0),
                End = new TimeSpan(17, 0, 0),
                Date = DateTime.Now.Date
            });
            Add(new Room
            {
                Name = "Room 2",
                Start = new TimeSpan(9, 0, 0),
                End = new TimeSpan(17, 0, 0),
                Date = DateTime.Now.Date
            });
        }
    }
}
