using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperScheduler.Models
{
    public class ShiftStartTimes
    {
        public int Id { get; set; }

        [Display(Name = "Shift Start Time")]
        public double ShiftStartTime { get; set; }
    }
}