using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarDialog
{
    public class NewEvent
    {
        public int Id { get; set; }
        public string eventName { get; set; }
        public DateTime dateOfEvent { get; set; }
        public string startHour { get; set; }
        public string endHour { get; set; }
        public string localization { get; set; }
        public string eventNature { get; set; }
        public int row { get; set; }
        public int column { get; set; }
    }
}
