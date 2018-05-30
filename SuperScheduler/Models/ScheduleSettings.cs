using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperScheduler.Models
{
    public class ScheduleSettings
    {
        public int Id { get; set; }

        public int OvertimeLimit { get; set; }

        public List<Shift> BusyTimes { get; set; }

        public List<string> BusyTimeNames { get; set; }

    }
}