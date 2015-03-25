using Bug315.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bug315.Controllers
{
    public class HomeController : Controller
    {
        // privite instance of a singleton
        private BugService _service;

        // Point to the Singleton instance
        public HomeController()
        {
            //_service = new BugService(); //ERROR - creating a Instance
            _service = BugService.Instance; // fetch the Instance
        }


        public ActionResult Index()
        {
            // create the VM for index
            WorkItemIndexVm vModel = new WorkItemIndexVm();
            // Populate the VM (welcomeMessage & List)
            vModel.WelcomeMessage = "These are all the Bugs and Tasks";
            // list of bug & tasks
            vModel.WorkItemList = _service.fetchAllBugs();

            // LINQ to filter only the BUG types..
            List<WorkItem> tempList = _service.fetchAllBugs().Where(b => b.GetType().Name == "Bug").ToList();
            // Cast it to a List w/ type of BUG
            List<Bug> listOfBug = tempList.Cast<Bug>().ToList();
            // apply yo view model
            vModel.BugList = listOfBug;

            // LINQ to filter only the BUG types..
            List<WorkItem> tempList2 = _service.fetchAllBugs().Where(b => b.GetType().Name == "TaskToDo").ToList();
            // Cast it to a List w/ type of Task
            List<TaskToDo> listOfTask = tempList2.Cast<TaskToDo>().ToList();
            // apply yo view model
            vModel.TaskList = listOfTask;

            _service.Increment();
            vModel.Count = _service.Counter;

            // pass along the VM to the View
            return View(vModel);
        }

        public ActionResult Create()
        {
            WorkItemCreateVm vm = new WorkItemCreateVm();
            vm.Greeting = "Hello from Create ViewModel!";
            vm.Priority = new List<string>(){
                "Low",
                "Medium",
                "High"
            };
            return View(vm);
        }
        [HttpPost]
        public ActionResult Create(WorkItemCreateVm createVM)
        {
            var priority = createVM.Priority.FirstOrDefault();
            var priorityAssign = 0;
            if (priority == "Low")
	        {   
                priorityAssign = 1;		 
	        } 
            if (priority == "Medium")
            {
                priorityAssign = 2;
            }
            if (priority == "High")
            {
                priorityAssign = 3;
            }
            var newBug = new Bug() { Title = createVM.Title, DateCreated = createVM.DateCreated, Priority = priorityAssign, StepsToReproduce = createVM.StepsToReproduce };
            _service.Create(newBug);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            _service.Increment();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            _service.Increment();
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}