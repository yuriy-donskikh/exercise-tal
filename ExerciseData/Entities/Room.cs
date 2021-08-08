using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExerciseData.Entities
{
    public class Room:IEntityTypeConfiguration<Room>
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public List<RoomTime> Times { get; set; } = new();

        public void Configure(EntityTypeBuilder<Room> entity)
        {
            entity.ToTable("Room");
            entity.HasKey(e => e.RoomId);
            entity.Property(e => e.RoomId).ValueGeneratedOnAdd();

            entity.HasMany(e => e.Times)
                .WithOne()
                .HasForeignKey(k => k.RoomId)
                .OnDelete(DeleteBehavior.Cascade)
                ;
        }
    }
}
