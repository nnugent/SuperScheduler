using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperScheduler.Models
{
    public class Day
    {
        public int Id { get; set; }

        public List<Employee> Staff { get; set; }

        public DateTime ShiftStart { get; set; }

        public DateTime ShiftEnd { get; set; }

        public DateTime Date { get; set; }
    }
}