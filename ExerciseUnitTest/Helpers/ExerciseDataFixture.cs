using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExerciseData.Entities;
using MockQueryable.Moq;
using Moq;
using Oxygen.Core.Database.Interfaces;
using Oxygen.Core.Database.Providers;

namespace ExerciseUnitTest.Helpers
{
    public class ExerciseDataFixture
    {
        public DbContextResolver Resolver { get; }

        public ExerciseDataFixture()
        {
            var context = new Mock<IOxygenDbContext>();
            
            context.Setup(i => i.Get<Room>()).Returns(MockRoomMany().Object);
            context.Setup(i => i.Get<RoomTime>()).Returns(MockRoomMany().Object.First().Times.AsQueryable().BuildMock().Object);
            context.Setup(i =>
                    i.DeleteEntitiesAsync(It.IsAny<CancellationToken>(), It.IsAny<It.IsSubtype<It.IsAnyType>>()))
                .Returns(Task.CompletedTask);

            context.Setup(i =>
                    i.SaveEntitiesAsync<It.IsAnyType>(It.IsAny<CancellationToken>(), It.IsAny<It.IsAnyType>()))
                .Returns(Task.FromResult(0));

            var resolver = new Mock<DbContextResolver>();
            resolver.Setup(i => i(It.IsAny<string>())).Returns(() => context.Object);
            Resolver = resolver.Object;
        }

        public Mock<IQueryable<Room>> MockRoomMany()
        {
            var result = new List<Room>
            {
                new()
                {
                    RoomId = 1, 
                    Name = "Room 1", 
                    Date = DateTime.Now.Date,
                    Start = new TimeSpan(9,0,0),
                    End = new TimeSpan(17,0,0),
                    Times = new()
                    {
                        new() {RoomId = 1, Time = new TimeSpan(11, 0, 0)},
                        new() {RoomId = 1, Time = new TimeSpan(12, 0, 0)},
                        new() {RoomId = 1, Time = new TimeSpan(12, 30, 0)},
                        new() {RoomId = 1, Time = new TimeSpan(15, 30, 0)},
                    }
                },
                new()
                {
                    RoomId = 2,
                    Name = "Room 2",
                    Date = DateTime.Now.Date,
                    Start = new TimeSpan(9,0,0),
                    End = new TimeSpan(17,0,0),
                    Times = new List<RoomTime>
                    {
                        new (){RoomId = 2, Time = new TimeSpan(16,0,0)},
                    }
                },
            };
            return result.AsQueryable().BuildMock();
        }
    }
}
