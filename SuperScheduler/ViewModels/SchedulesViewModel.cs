using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SuperScheduler.Models;

namespace SuperScheduler.ViewModels
{
    public class SchedulesViewModel
    {

        public List<OneWeekSchedule> Schedules { get; set; }

    }
}