using SuperScheduler.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;
using System.Windows.Forms;
using SuperScheduler.ViewModels;

namespace SuperScheduler.Controllers
{
    public class EmployeeConteroller : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeConteroller()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult HomePage()
        {
            return View("HomePage");
        }
    }
}