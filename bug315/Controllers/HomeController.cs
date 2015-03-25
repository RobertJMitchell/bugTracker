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
        //init the Singleton / BugService
        private BugService _service;

        public HomeController() {
          _service = new BugService();
    }


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
            // list of bug and tasks
            vModel.WorkItemList = mList;

            //LINQ to filter only the BUG types
            List<WorkItem> tempList = mList.Where(b => b.GetType().Name == "Bug").ToList();
            // cast it to a List with type of BUG
            List<Bug> listOfBug = tempList.Cast<Bug>().ToList();
            // apply to viewmodel
            vModel.BugList = listOfBug;
            //linq to filter only task types
            List<WorkItem> tempList2 = mList.Where(b => b.GetType().Name == "Task").ToList();

            //cast it to a list with type of task
            List<TaskToDo> listOfTask = tempList2.Cast<TaskToDo>().ToList();
            //apply yo view model
            vModel.TaskList = listOfTask;

            _service.Counter++;
            vModel.Count = _service.Counter;

            //pass along the VM to the view
            return View(vModel);
        }

        public ActionResult About()
        {
            _service.Counter++;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            _service.Counter++;
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}