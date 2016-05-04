using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EventMVC.Models
{
    public class EventDBContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}