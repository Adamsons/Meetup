using MeetupTest.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetupTest.Persistence
{
    public interface IMeetupContext
    {
        DbSet<Meetup> Meetups { get; set; }
        DbSet<Seat> Seats { get; set; }
        DbSet<Booking> Bookings { get; set; }
    }
}