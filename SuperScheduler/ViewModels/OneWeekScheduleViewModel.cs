using SuperScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperScheduler.ViewModels
{
    public class OneWeekScheduleViewModel
    {
        public List<Employee> Employees { get; set; }

        public List<ShiftLengths> ShiftLengths { get; set; }

        public List<ShiftStartTimes> ShiftStartTimes { get; set; }

        public List<Position> Positions { get; set; }

        public OneWeekSchedule Schedule { get; set; }
    }
}