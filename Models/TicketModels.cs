using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventMVC.Models
{
    public class Ticket
    {
        public int ID { get; set; }

        [ForeignKey("Event")]
        public int EventID { get; set; }
        public virtual Event Event { get; set; }

        public int number { get; set; }
        public int row { get; set; }
    }
}