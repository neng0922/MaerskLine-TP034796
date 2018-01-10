using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class OrderScheduleViewModel
    {
        public Order Order { get; set; }

        public Schedule Schedule { get; set; }
    }
}