using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class Schedule
    {
        [Key]
        [Display(Name = "Schedule ID")]
        public int ScheduleID { get; set; }

        [Display(Name = "Origin")]
        public String ScheduleOrigin { get; set; }

        [Display(Name = "Destination")]
        public String ScheduleDestination { get; set; }

        [Display(Name = "Departing Time")]
        public DateTime ScheduleDepartureDateTime { get; set; }

        [Display(Name = "Arriving Time")]
        public DateTime ScheduleArrivalDateTime { get; set; }

        [Display(Name = "Availability")]
        public bool ScheduleAvailability { get; set; }

        [Display(Name = "Ship Name")]
        public int ShipID { get; set; }

        public Ship Ship { get; set; }
    }
}