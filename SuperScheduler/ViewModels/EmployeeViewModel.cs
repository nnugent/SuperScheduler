using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperScheduler.Models;

namespace SuperScheduler.ViewModels
{
    public class EmployeeViewModel
    {
        public List<Employee> Employees { get; set; }

        public List<Position> Positions { get; set; }


    }
}