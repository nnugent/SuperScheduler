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
using Microsoft.AspNet.Identity;

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

        public ActionResult AccountDetails()
        {
            string userId = User.Identity.GetUserId();
            var employee = _context.Employees.Select(e => e).Where(e => e.UserId == userId).FirstOrDefault();
            if (employee != null)
            {
                var viewModel = new Employee()
                {
                    PhoneNumber = employee.PhoneNumber,
                    Name = employee.Name,
                    MaxHours = employee.MaxHours
                };
                return View(viewModel);
            }
            return View();
        }

        public ActionResult SaveDetails(Employee employee)
        {
            var userId = User.Identity.GetUserId();
            employee.PhoneNumber.Trim();
            employee.PhoneNumber = employee.PhoneNumber.Replace(" ", "");
            if (CheckPhoneNumberFormat(employee.PhoneNumber))
            {
                if (employee.Id == 0)
                {
                    employee.UserId = userId;
                    employee.Active = false;
                    _context.Employees.Add(employee);
                    employee.PositionId = _context.Positions.FirstOrDefault().Id;
                }
                try
                {
                    Convert.ToByte(employee.MaxHours);
                    _context.SaveChanges();
                }
                catch
                {
                    return RedirectToAction(RetryDialogueBox("There was an issue saving to the database. Please try again.", "Save Error.", "AccountDetails"));
                }
            }
            else
            {
                return RedirectToAction(RetryDialogueBox("Invalid phone number formatting.", "Invalid Input.", "AccountDetails"));
            }
            return RedirectToAction("HomePage");
        }

        public bool CheckPhoneNumberFormat(string phoneNumber)
        {
            bool result = false;
            if ((phoneNumber.Substring(0, 1)) == "(" && (phoneNumber.Substring(4, 1)) == ")" && (phoneNumber.Substring(8, 1)) == "-")
            {
                result = true;
            }
            else
            {
                return result;
            }
            if (result)
            {
                try
                {
                    Convert.ToInt32(phoneNumber.Substring(1, 3));
                    Convert.ToInt32(phoneNumber.Substring(5, 3));
                    Convert.ToInt32(phoneNumber.Substring(9, 4));
                }
                catch
                {
                    result = false;
                }
            }
            return result;
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