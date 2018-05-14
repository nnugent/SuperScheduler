using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SuperScheduler.Models;


namespace SuperScheduler.CustomDataStructures
{
    public class Preference
    {
        public int Id { get; set; }

        [Display(Name = "Check if requesting to work")]
        public bool ToWork { get; set; }

        [Display(Name = "When preference begins")]
        public int StartTimeId { get; set; }

        public DayOfWeek Day { get; set; }

        [Display(Name = "How long is the preference")]
        public int ShiftLengthId { get; set; }
        
        [ForeignKey("StartTimeId")]
        public ShiftStartTimes StartTimes { get; set; }

        [ForeignKey("ShiftLengthId")]
        public ShiftLengths ShiftLengths { get; set; }

    }

}