using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bug315.Models
{
    //used to transport the data (properties seen below) to the view
    public class WorkItemIndexVm
    {
        //used for the header
        public string WelcomeMessage { get; set; }
        //used to hold the data
        public List<WorkItem> WorkItemList { get; set; }

        // bug - typed cast

        public List<Bug> BugList { get; set; }

        //task - typed cast

        public List<TaskToDo> TaskList { get; set; }
    }
}