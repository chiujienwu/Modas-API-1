using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Modas.Models
{
  public class EventDbContext : DbContext
  {
    public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }
    public DbSet<Event> Events { get; set; }
    public DbSet<Location> Locations { get; set; }

    public Event AddEvent(Event evt)
    {
      this.Events.Add(evt);
      this.SaveChanges();
      return evt;
    }
    public Event UpdateEvent(Event evt)
    {
      Event Event = this.Events.FirstOrDefault(e => e.EventId == evt.EventId);
      Event.TimeStamp = evt.TimeStamp;
      Event.Flagged = evt.Flagged;
      Event.LocationId = evt.LocationId;
      this.SaveChanges();
      return Event;
    }
  }
}
