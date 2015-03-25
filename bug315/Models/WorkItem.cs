using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bug315.Models
{
    public abstract class WorkItem
    {
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        //1, 2, and 3 are the priority integers
        public int Priority { get; set; }
    }
}