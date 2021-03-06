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
                    newShift.Display = true;
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
            else if (newPosition.Name == "" || newPosition.Name == null)
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
                    newShiftStartTime.Display = true;
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

        public ActionResult Positions()
        {
            var positions = _context.Positions.ToList();
            var positionNames = new List<string>();
            foreach(Position el in positions)
            {
                positionNames.Add(el.Name);
            }
            var viewModel = new PositionViewModel()
            {
                Positions = positionNames
            };
            return View("Positions", viewModel);
        }

        public ActionResult Employees()
        {
            var viewModel = new EmployeeViewModel()
            {
                Employees = _context.Employees.ToList(),
                Positions = _context.Positions.ToList()
            };
            return View(viewModel);
        }

        public ActionResult ChangeEmployeeStatus(string employeeId)
        {
            var employee = _context.Employees.Select(e => e).Where(e => e.UserId == employeeId).FirstOrDefault();
            employee.Active = !employee.Active;

            _context.SaveChanges();

            return RedirectToAction("Employees");
        }

        public ActionResult EditEmployeePositions()
        {
            var viewModel = new EmployeeViewModel()
            {
                Employees = _context.Employees.ToList(),
                Positions = _context.Positions.ToList()
            };
            return View(viewModel);
        }

        public ActionResult ChangeEmployeePosition(string employeeId, int? positionId)
        {
            var employee = _context.Employees.Select(e => e).Where(e => e.UserId == employeeId).FirstOrDefault();
            employee.PositionId = positionId;
            _context.SaveChanges();
            return RedirectToAction("EditEmployeePositions");
        }

        public ActionResult ChangeEmployeePositions(EmployeeViewModel viewModel)
        {
            var currentEmployees = _context.Employees.ToList();
            for(int i = 0; i < currentEmployees.Count; i++)
            {
                if (viewModel.Employees[i].PositionId != null)
                {
                    currentEmployees[i].PositionId = viewModel.Employees[i].PositionId;
                }
            }
            _context.SaveChanges();
            return RedirectToAction("EditEmployeePositions");
        }

        public ActionResult ShiftLengths()
        {
            var shiftLengths = _context.ShiftLengths.ToList();
            List<TimeSpan> shiftsInTime = new List<TimeSpan>();
            foreach (ShiftLengths el in shiftLengths)
            {
                shiftsInTime.Add(TimeSpan.Parse(el.Shift.ToString() + ":00"));
            }
            var viewModel = new ShiftLengthViewModel()
            {
                ShiftLengths = shiftsInTime
            };
            return View("ShiftLengths", viewModel);
        }

        public ActionResult ShiftStartTimes()
        {
            var shiftStartTimes = _context.ShiftStartTimes.ToList();
            var shiftStartTimesInTime = new List<TimeSpan>();

            foreach (ShiftStartTimes el in shiftStartTimes)
            {
                shiftStartTimesInTime.Add(TimeSpan.Parse(el.ShiftStartTime.ToString() + ":00" ));
            }
            var viewModel = new ShiftStartTimesViewModel()
            {
                ShiftStartTimes = shiftStartTimesInTime
            };
            return View("ShiftStartTimes", viewModel);
        }

        public ActionResult RemovePosition(string positionName)
        {
            _context.Positions.Remove(_context.Positions.Select(s => s).FirstOrDefault(s => s.Name.Equals(positionName)));
            _context.SaveChanges();
            return RedirectToAction("Positions");
        }

        public ActionResult RemoveShiftLength(string hours)
        {
            var lengthOfShift = Convert.ToDouble(hours);
            _context.ShiftLengths.Remove(_context.ShiftLengths.Select(s => s).FirstOrDefault(s => s.Shift.Equals(lengthOfShift)));
            _context.SaveChanges();
            return RedirectToAction("ShiftLengths");
        }

        public ActionResult RemoveShiftStartTime(string time)
        {
            var shiftStartTime = Convert.ToDouble(time);
            _context.ShiftStartTimes.Remove(_context.ShiftStartTimes.Select(s => s).FirstOrDefault(s => s.ShiftStartTime.Equals(shiftStartTime)));
            _context.SaveChanges();
            return RedirectToAction("ShiftStartTimes");
        }

        public bool CheckIfExists(ShiftStartTimes shiftStart)
        {
            var count = _context.ShiftStartTimes.Select(s => s.ShiftStartTime).Where(s => s.Equals(shiftStart.ShiftStartTime)).Count();
            if (count > 0)
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

        public ActionResult GenerateSchedule()
        {
            var employees = _context.Employees.ToList();
            var shiftLengths = _context.ShiftLengths.ToList();
            var shiftStartTimes = _context.ShiftStartTimes.ToList();
            var positions = _context.Positions.ToList();
            var week = new List<Models.Day>();

            for(int i = 0; i < 8; i++)
            {
                week.Add(null);
            }
            var viewModel = new OneWeekSchedule()
            {
                Employees = employees,
                ShiftLengths = shiftLengths,
                ShiftStartTimes = shiftStartTimes,
                Positions = positions,
                Week = week
            };
            return View(viewModel);
        }

        public ActionResult AutoGenerateSchedule(OneWeekSchedule schedule)
        {
            Random ran = new Random();
            var week = schedule.Week.ToList();
            var shiftStartTimes = _context.ShiftStartTimes.ToList();
            var shiftLengths = _context.ShiftLengths.ToList();
            var employees = _context.Employees.ToList();
            var positions = _context.Positions.ToList();

            for(int i = 0; i < week.Count; i++)
            {
                for(int j = 0; j < week[i].Shifts.Count; j++)
                {
                    if (week[i].Shifts[j].ShiftStartTime.ShiftStartTime == 0)
                    {
                        if (ran.Next(10) < 7)
                        {
                            week[i].Shifts[j].ShiftStartTime = shiftStartTimes[ran.Next(shiftStartTimes.Count())];
                        }
                        else
                        {
                            week[i].Shifts[j].ShiftStartTime.ShiftStartTime = 0;
                        }
                    }

                    if (week[i].Shifts[j].ShiftLength.Shift == 0 && week[i].Shifts[j].ShiftStartTime.ShiftStartTime != 0)
                    {
                        if (week[i].Shifts[j].ShiftStartTime.ShiftStartTime + 8 <= 23)
                        {
                            week[i].Shifts[j].ShiftLength.Shift = 8;
                        }
                        else
                        {
                            week[i].Shifts[j].ShiftLength.Shift = 23 - week[i].Shifts[j].ShiftStartTime.ShiftStartTime;
                        }
                    }
                }
            }

            schedule.ShiftLengths = shiftLengths;
            schedule.ShiftStartTimes = shiftStartTimes;
            schedule.Employees = employees;
            schedule.Week = week;
            schedule.Positions = positions;

            return View("ScheduleStepTwo", schedule);
        }

        public ActionResult ViewSchedules()
        {
            var viewModel = new SchedulesViewModel()
            {
                Schedules = _context.OneWeekSchedules.ToList()
            };
            return View("ViewSchedules", viewModel);
        }

        public ActionResult DeleteSchedule(string scheduleName)
        {
            var thing = _context.OneWeekSchedules.Select(s => s).FirstOrDefault(s => s.ScheduleName.Equals(scheduleName));
            _context.OneWeekSchedules.Remove(thing);
            _context.SaveChanges();
            return RedirectToAction("ViewSchedules");
        }

        public ActionResult SaveSchedule(OneWeekSchedule schedule)
        {
            _context.OneWeekSchedules.Add(schedule);
            _context.SaveChanges();
            var viewModel = new OneWeekSchedule()
            {
                Employees = _context.Employees.ToList(),
                Week = schedule.Week,
                Positions = _context.Positions.ToList(),
                ScheduleName = schedule.ScheduleName,
                ShiftLengths = _context.ShiftLengths.ToList(),
                ShiftStartTimes = _context.ShiftStartTimes.ToList()
            };
            return View("DisplaySchedule", viewModel);
        }
    }
}