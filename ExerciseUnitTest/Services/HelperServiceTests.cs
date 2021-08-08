using System.Linq;
using System.Threading.Tasks;
using ExerciseModel.Models;
using ExerciseServices.Services;
using ExerciseUnitTest.Helpers;
using Xunit;

namespace ExerciseUnitTest.Services
{
    public class HelperServiceTests:IClassFixture<MapperFixture>, IClassFixture<ExerciseDataFixture>
    {
        private readonly MapperFixture _mapper;
        private readonly ExerciseDataFixture _exerciseData;

        public HelperServiceTests(MapperFixture mapper, ExerciseDataFixture exerciseData)
        {
            _mapper = mapper;
            _exerciseData = exerciseData;
        }

        [Fact]
        public async Task GetRoomTest()
        {
            // Arrange
            var service = new HelperService(_mapper.Mapper, _exerciseData.Resolver);
            
            // Action
            var result = await service.GetRoom(1, default); 
            
            // Assertion
            Assert.IsType<Room>(result);
            Assert.NotNull(result);
            Assert.Equal(1, result.RoomId);
        }

        [Fact]
        public void TransformRoomTest()
        {
            // Arrange
            var service = new HelperService(_mapper.Mapper, _exerciseData.Resolver);
            var model = _mapper.Mapper.Map<Room>(_exerciseData.MockRoomMany().Object.First());

            // Action
            service.TransformRoom(model);

            // Assertion
            Assert.IsType<Room>(model);
            Assert.NotNull(model);
            Assert.NotEmpty(model.Times);
            Assert.Equal(16, model.Times.Count);
        }
    }
}
