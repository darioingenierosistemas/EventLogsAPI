using EventLogsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventLogsAPI.Data
{
    public class EventLogsDB : DbContext
    {
        public EventLogsDB(DbContextOptions<EventLogsDB> options) : base(options)
        {

        }

        public DbSet<EventLogs> EventLogs => Set<EventLogs>();
    }
}
