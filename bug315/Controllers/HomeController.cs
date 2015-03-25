using bug315.Models; // path to directory for WorkItem
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bug315.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //create the VM for index
            WorkItemIndexVm vModel = new WorkItemIndexVm();
            //Create a list of objects (Bug, TaskToDo)
            List<WorkItem> mList = new List<WorkItem>() { 
                new Bug(){Title="audio not working", Priority=1, DateCreated=DateTime.Now, StepsToReproduce="click the sound icon"},
                new Bug(){Title="The dropdown is empty", Priority=3, DateCreated=DateTime.Now, StepsToReproduce="choose state, then city"},
                new TaskToDo(){Title="Call client XYZ", Priority=3, DateCreated=DateTime.Now.AddDays(-5), Description="Follow up on deal XYZ"},
                new TaskToDo(){Title="Purchase strong coffee", Priority=1, DateCreated=DateTime.Now.AddHours(-5), Description="Colombian Blend"},
            };

            //populate the VM (welcomeMesage & List)
            vModel.WelcomeMessage = "These are all the Bugs and Tasks.";
            vModel.WorkItemList = mList;

            //pass along the VM to the view
            return View(vModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}