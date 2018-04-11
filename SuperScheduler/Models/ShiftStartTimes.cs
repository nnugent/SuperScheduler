using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperScheduler.Models
{
    public class ShiftStartTimes
    {
        public int Id { get; set; }

        public List<DateTime> ShiftLengths { get; set; }
    }
}