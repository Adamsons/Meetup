using MeetupTest.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetupTest.Persistence
{
    public class MeetupContext : DbContext, IMeetupContext
    {
        public MeetupContext(DbContextOptions options) : base(options) { }

        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
