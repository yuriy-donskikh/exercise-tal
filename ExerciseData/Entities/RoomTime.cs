using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExerciseData.Entities
{
    public class RoomTime:IEntityTypeConfiguration<RoomTime>
    {
        public int RoomId { get; set; }
        public TimeSpan Time { get; set; }

        public void Configure(EntityTypeBuilder<RoomTime> entity)
        {
            entity.ToTable("RoomTime");
            entity.HasKey(e => new {e.RoomId, e.Time});
        }
    }
}