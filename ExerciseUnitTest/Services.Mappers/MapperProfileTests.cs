using System.Threading.Tasks;
using AutoMapper;
using ExerciseUnitTest.Helpers;
using Xunit;

namespace ExerciseUnitTest.Services.Mappers
{
    public class MapperProfileTests:IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;

        public MapperProfileTests(MapperFixture mapperFixture)
        {
            _mapper = mapperFixture.Mapper;
        }

        [Fact]
        public Task Configuration()
        {
            return Task.Run(() => _mapper.ConfigurationProvider.AssertConfigurationIsValid());
        }

    }
}
