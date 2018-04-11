using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperScheduler.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult HomePage()
        {
            return View();
        }
    }
}