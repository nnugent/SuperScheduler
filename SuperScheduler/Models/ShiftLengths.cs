using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperScheduler.Models
{
    public class ShiftLengths
    {
        public int Id { get; set; }

        [Display(Name = "Shift Length")]
        public double Shift { get; set; }

        public bool Display { get; set; }
    }
}