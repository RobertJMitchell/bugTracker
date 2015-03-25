using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug315.Models
{
    public class Bug : WorkItem
    {
        public string StepsToReproduce { get; set; }
    }
}