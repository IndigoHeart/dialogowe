using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarDialog
{
    public class EventContext:DbContext
    {
        public DbSet<NewEvent> newEvents { get; set; }
    }
}
