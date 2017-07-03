using MeetupTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetupTest.Persistence
{
    public class MeetupContext : DbContext
    {
        public MeetupContext(DbContextOptions<MeetupContext> options) : base(options) { }

        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
