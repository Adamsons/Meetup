﻿using System;

namespace MeetupTest.Domain.Models
{
    public class Meetup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
