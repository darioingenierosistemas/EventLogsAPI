using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormEventLog.Models
{
    public class EventLogs
    {
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public string EventType { get; set; }
    }
}
