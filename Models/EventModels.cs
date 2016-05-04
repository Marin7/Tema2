using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventMVC.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string directed { get; set; }
        public string distribution { get; set; }
        public DateTime openingDate { get; set; }
        public int ticketCount { get; set; }
    }
}