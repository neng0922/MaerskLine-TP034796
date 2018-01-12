using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class ShipScheduleViewModal
    {
        public List<Ship> Ships { get; set; }

        public Schedule Schedule { get; set; }
    }
}