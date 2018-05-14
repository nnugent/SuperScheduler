using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperScheduler.Models;
using SuperScheduler.CustomDataStructures;

namespace SuperScheduler.ViewModels
{
    public class AddPreferenceViewModel
    {
        public Preference Preference { get; set; }

        public List<ShiftLengths> ShiftLengths { get; set; }

        public List<ShiftStartTimes> ShiftStartTimes { get; set; }
    }
}