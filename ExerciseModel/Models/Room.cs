using System;
using System.Collections.Generic;

namespace ExerciseModel.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public List<RoomTime> Times { get; set; } = new();
    }
}
