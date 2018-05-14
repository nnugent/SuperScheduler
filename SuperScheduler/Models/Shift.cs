using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperScheduler.Models
{
    public class Shift
    {
        public int Id { get; set; }

        public ShiftLengths ShiftLength { get; set; }

        public ShiftStartTimes ShiftStartTime { get; set; }

    }
}