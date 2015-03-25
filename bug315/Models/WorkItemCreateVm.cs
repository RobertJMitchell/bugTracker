using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug315.Models
{
    public class WorkItemCreateVm
    {
        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public List<string> Priority { get; set; }

        public string StepsToReproduce { get; set; }

        public string Greeting { get; set; }
    }
}