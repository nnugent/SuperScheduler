using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperScheduler.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public DateTime? PreferedShift { get; set; }

        public List<DateTime> TimesNotAvailable { get; set; }

        public string Name { get; set; }

    }
}