using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperScheduler.CustomDataStructures;

namespace SuperScheduler.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte MaxHours { get; set; }

        public List<Preference> Preferences { get; set; }
    }
}