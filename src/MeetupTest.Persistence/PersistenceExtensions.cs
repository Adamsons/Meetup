using System;
using MeetupTest.Persistence.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MeetupTest.Persistence
{
    public static class PersistenceExtensions
    {
        private static Lazy<SqliteConnection> _connection;

        public static IServiceCollection AddSqlPersistence(this IServiceCollection services)
        {
            _connection = new Lazy<SqliteConnection>(() =>
            {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();
                return connection;
            });

            services.AddDbContext<MeetupContext>(options =>
            {
                options.UseSqlite(_connection.Value);
            }, ServiceLifetime.Scoped);

            services.AddScoped<IMeetupContext, MeetupContext>();

            return services;
        }

        public static void SeedData(this MeetupContext context)
        {
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            context.Meetups.AddRange(new Meetup
            {
                Id = 1,
                Name = "React London",
                Location = "Facebook",
                StartTime = DateTime.Today.AddHours(18),
                EndTime = DateTime.Today.AddHours(20)
            },
            new Meetup
            {
                Id = 2,
                Name = "React London",
                Location = "The Guardian",
                StartTime = DateTime.Today.AddDays(1).AddHours(18),
                EndTime = DateTime.Today.AddDays(1).AddHours(20)
            },
            new Meetup
            {
                Id = 3,
                Name = "DDD South West",
                Location = "Bristol",
                StartTime = DateTime.Today.AddHours(15),
                EndTime = DateTime.Today.AddHours(19)
            });

            context.SaveChanges();
        }
    }
}
