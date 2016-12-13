using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EventLab.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public string Genre { get; set; }

    }
}
