using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperScheduler.Models;

namespace SuperScheduler.CustomDataStructures
{
    public class Preference
    {
        public int Id { get; set; }

        public bool ToWork { get; set; }

        public DateTime Day { get; set; }

        ShiftStartTimes StartTime { get; set; }

        ShiftLengths ShiftLength { get; set; }

    }

}