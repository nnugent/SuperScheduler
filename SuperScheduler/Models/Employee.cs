using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SuperScheduler.CustomDataStructures;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace SuperScheduler.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public int? PositionId{ get; set; }

        [ForeignKey("PositionId")]
        public Position Position { get; set; }

        [Display(Name = "Max hours each week.")]
        public byte MaxHours { get; set; }

        [Display(Name = "Phone Number Example: (123)456-7890")]
        public string PhoneNumber { get; set; }

        public bool Active { get; set; }

        public List<Preference> Preferences { get; set; }
    }
}