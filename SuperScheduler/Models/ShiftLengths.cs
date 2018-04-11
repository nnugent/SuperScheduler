using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperScheduler.Models
{
    public class ShiftLengths
    {
        public int Id { get; set; }

        public List<DateTime> Shifts { get; set; }

    }
}