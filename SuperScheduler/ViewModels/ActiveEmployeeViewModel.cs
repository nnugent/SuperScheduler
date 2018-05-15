using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperScheduler.Models;

namespace SuperScheduler.ViewModels
{
    public class ActiveEmployeeViewModel
    {
        public List<ApplicationUser> AllUsers { get; set; }

        public List<Employee> Employees { get; set; }
    }
}