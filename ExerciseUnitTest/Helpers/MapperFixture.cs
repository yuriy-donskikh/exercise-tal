using System;
using AutoMapper;
using ExerciseServices.Mappers;

namespace ExerciseUnitTest.Helpers
{
    public class MapperFixture : IDisposable
    {
        public IMapper Mapper { get; }

        public MapperFixture()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(MapperProfile)));
            Mapper = new Mapper(config);
        }

        public void Dispose()
        {
        }
    }
}
