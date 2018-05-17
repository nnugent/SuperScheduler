using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperScheduler.Models
{
    public class OneWeekSchedule
    {
        public int Id { get; set; }

        public List<Day> Week { get; set; }

        public List<Employee> Employees { get; set; }

        public List<ShiftLengths> ShiftLengths { get; set; }

        public List<ShiftStartTimes> ShiftStartTimes { get; set; }

        public List<Position> Positions { get; set; }
    }
}