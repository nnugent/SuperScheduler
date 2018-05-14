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
using SuperScheduler.CustomDataStructures;

namespace SuperScheduler.Controllers
{
    [AllowAnonymous]
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult AddPreference()
        {
            var shiftLengths = _context.ShiftLengths.ToList();
            var shiftStartTimes = _context.ShiftStartTimes.ToList();
            var viewModel = new AddPreferenceViewModel()
            {
                ShiftLengths = shiftLengths,
                ShiftStartTimes = shiftStartTimes
            };
            return View(viewModel);
        }

        public ActionResult NewPreference(Preference Preference)
        {
            return RedirectToAction("AddPreference");
        }
    }
}