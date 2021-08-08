using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExerciseModel.Models;
using ExerciseServices.Services.Dynamic;
using ExerciseServices.Services.Interfaces;
using ExerciseUnitTest.Helpers;
using Moq;
using Xunit;

namespace ExerciseUnitTest.Services.Dynamic
{
    public class ExerciseServiceTests:IClassFixture<MapperFixture>, IClassFixture<ExerciseDataFixture>
    {
        private readonly MapperFixture _mapper;
        private readonly ExerciseDataFixture _exerciseData;
        private readonly Mock<IHelperService> _helperService; 

        public ExerciseServiceTests(MapperFixture mapper, ExerciseDataFixture exerciseData)
        {
            _mapper = mapper;
            _exerciseData = exerciseData;
            _helperService = new Mock<IHelperService>();
            _helperService.Setup(i => i.GetRoom(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(
                Task.FromResult(new Room
                {
                    RoomId = 0,
                    Date = DateTime.Now.Date,
                    Start = new TimeSpan(9, 0, 0),
                    End = new TimeSpan(17, 0, 0),
                    Name = "Room"
                }));

        }

        [Fact]
        public async Task GetRoomsTest()
        {
            // Arrange
            var service = new ExerciseService(_mapper.Mapper, _exerciseData.Resolver, _helperService.Object);
            
            // Action
            var result = await service.GetRooms(default); 
            
            // Assertion
            Assert.IsType<List<Room>>(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task AddRoomTest()
        {
            // Arrange
            var service = new ExerciseService(_mapper.Mapper, _exerciseData.Resolver, _helperService.Object);
            var room = new Room {Name = "Room", Date = DateTime.Now.Date};

            // Action
            var result = await service.AddRoom(room, default);

            // Assertion
            Assert.IsType<Room>(result);
            Assert.NotNull(result);
            Assert.Equal(DateTime.Now.Date, result.Date);
        }

        [Fact]
        public async Task DeleteRoomTest()
        {
            // Arrange
            var service = new ExerciseService(_mapper.Mapper, _exerciseData.Resolver, _helperService.Object);

            // Action
            await service.DeleteRoom(0, default);

            // Assertion
            // Success if no exception happened above
        }

        [Fact]
        public async Task AddTimeTest()
        {
            // Arrange
            var service = new ExerciseService(_mapper.Mapper, _exerciseData.Resolver, _helperService.Object);

            // Action
            await service.AddTime(0, "09:00", default);

            // Assertion
            // Success if no exception happened above
        }

        [Fact]
        public async Task DeleteTimeTest()
        {
            // Arrange
            var service = new ExerciseService(_mapper.Mapper, _exerciseData.Resolver, _helperService.Object);

            // Action
            await service.DeleteTime(0, "09:00", default);

            // Assertion
            // Success if no exception happened above
        }
    }
}
