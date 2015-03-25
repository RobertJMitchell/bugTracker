using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug315.Models
{
    public abstract class WorkItem
    {
        //Title, DateCreated, and Priority (High, Medium, and Low).
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        // Priority levels 1, 2 & 3
        public int Priority { get; set; }

    }
}