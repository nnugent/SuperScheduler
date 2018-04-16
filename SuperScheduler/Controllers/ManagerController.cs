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


namespace SuperScheduler.Controllers
{
    [Authorize(Roles = "CanManageSchedule")]
    public class ManagerController : Controller
    {
        private ApplicationDbContext _context;
        

        public ManagerController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult AddShiftLengths()
        {
            return View();
        }

        public ActionResult AddShiftStartTimes()
        {
            return View();
        }

        public ActionResult NewShift(ShiftLengths newShift)
        {
            try
            {
                newShift.Shift = Convert.ToDouble(newShift.Shift);
                bool exists = CheckIfExists(newShift);
                if (!exists)
                {
                    _context.ShiftLengths.Add(newShift);
                    _context.SaveChanges();
                }
                else
                {
                    RetryDialogueBox("This input already exists. Click retry to enter a new number.", "Duplicate Input.");
                }
            }
            catch
            {
                RetryDialogueBox("Input can only contain a number. Click retry to enter a new number.", "Invalid Input.");
            }
            return View("AddShiftLengths");
        }

        public ActionResult NewShiftStartTime(ShiftStartTimes newShiftStartTime)
        { 
            try
            {
                newShiftStartTime.ShiftStartTime = Convert.ToDouble(newShiftStartTime.ShiftStartTime);
                bool exists = CheckIfExists(newShiftStartTime);
                if (!exists)
                {
                    _context.ShiftStartTimes.Add(newShiftStartTime);
                    _context.SaveChanges();
                }
                else
                {
                    RetryDialogueBox("This input already exists. Click retry to enter a new number.", "Duplicate Input.");
                }
            }
            catch
            {
                RetryDialogueBox("Input can only contain a number.\nClick retry to input a new number.", "Invalid Input.");
            }
            return View("AddShiftStartTimes");
        }

        public bool CheckIfExists(ShiftStartTimes shiftStart) 
        {
            var count = _context.ShiftStartTimes.Select(s => s.ShiftStartTime).Where(s => s.Equals(shiftStart.ShiftStartTime)).Count();
            if(count > 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckIfExists(ShiftLengths shiftLength)
        {
            var count = _context.ShiftLengths.Select(s => s.Shift).Where(s => s.Equals(shiftLength.Shift)).Count();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public void RetryDialogueBox(string message, string caption)
        {
            MessageBoxButtons retryButton;
            DialogResult result;
            retryButton = MessageBoxButtons.RetryCancel;
            result = MessageBox.Show(message, caption, retryButton);
            if (!(result == DialogResult.Retry))
            {
                View("HomePage", "HomePage");
            }
        }
    }
}