﻿using SuperScheduler.Models;
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

        public ActionResult AddPositions()
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
                    return RedirectToAction(RetryDialogueBox("This input already exists. Click retry to enter a new number.", "Duplicate Input.", "AddShiftLengths"));
                }
            }
            catch
            {
                return RedirectToAction(RetryDialogueBox("Input can only contain a number. Click retry to enter a new number.", "Invalid Input.", "AddShiftLengths"));
            }
            return RedirectToAction("AddShiftLengths");
        }

        public ActionResult NewPosition(Position newPosition)
        {
            bool exists = CheckIfExists(newPosition);
            if (!exists && (newPosition.Name) != "" && newPosition.Name != null)
            {
                try
                {
                    _context.Positions.Add(newPosition);
                    _context.SaveChanges();
                }
                catch
                {
                    return RedirectToAction(RetryDialogueBox("Input was invalid. Click retry to enter a new postion name.", "Invalid Input.", "AddPositions"));
                }
            }
            else if(newPosition.Name == "" || newPosition.Name == null)
            {
                return RedirectToAction(RetryDialogueBox("You must input a name. Click retry to enter a new position.", "Invalid Input.", "AddPositions"));
            }
            else
            {
                return RedirectToAction(RetryDialogueBox("That position already exists. Click retry to enter a new position.", "Invalid Input.", "AddPositions"));
            }
            return RedirectToAction("AddPositions");
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
                    return RedirectToAction(RetryDialogueBox("This input already exists. Click retry to enter a new number.", "Duplicate Input.", "AddShiftStartTimes"));
                }
            }
            catch
            {
                return RedirectToAction(RetryDialogueBox("Input can only contain a number.\nClick retry to input a new number.", "Invalid Input.", "AddShiftStartTimes"));
            }
            return RedirectToAction("AddShiftStartTimes");
        }

        public ActionResult ShiftLengths()
        {
            var shiftLengths = _context.ShiftLengths.ToList();
            List<TimeSpan> shiftsInTime = new List<TimeSpan>();
            foreach(ShiftLengths el in shiftLengths)
            {
                shiftsInTime.Add(TimeSpan.Parse(el.Shift.ToString()+":00"));
            }
            var viewModel = new ShiftLengthViewModel()
            {
                ShiftLengths = shiftsInTime
            };
            return View("ShiftLengths",viewModel);
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

        public bool CheckIfExists(Position position)
        {
            var count = _context.Positions.Select(s => s.Name).Where(s => s.Equals(position.Name)).Count();
            if (count > 0)
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

        public string RetryDialogueBox(string message, string caption, string retryView)
        {
            MessageBoxButtons retryButton;
            DialogResult result;
            retryButton = MessageBoxButtons.RetryCancel;
            result = MessageBox.Show(message, caption, retryButton);
            if (result != DialogResult.Retry)
            {
                return "HomePage";
            }
            return retryView;
        }
    }
}