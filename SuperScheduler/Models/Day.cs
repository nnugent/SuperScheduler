using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperScheduler.Models
{
    public class Day
    {
        public int Id { get; set; }

        public List<Shift> Shifts { get; set; }
    }
}