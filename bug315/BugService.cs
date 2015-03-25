using Bug315.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug315
{
    // Singleton...
    public class BugService
    {
        // Private Vars...
        private int _counter;

        //holds all bugs 
        private List<WorkItem> _allBugs;

        // internal variable to holde the BugService
        private static BugService _instance = null;

        public static BugService Instance { get {
                if(_instance == null){
                    _instance = new BugService();
                }
            return _instance;
            } 
        }


        // Constructor...
        private BugService()
        {

            _counter = 10;
            // Create a list of object (Bug, TaskToDo)
            _allBugs = new List<WorkItem>() {
                new Bug(){Title="audio not working", Priority=1, DateCreated=DateTime.Now, StepsToReproduce="click the sound icon"},
                new Bug(){Title="The dropdown is empty", Priority=3, DateCreated=DateTime.Now, StepsToReproduce="choose state, then city"},
                new TaskToDo(){Title="Call client XYZ", Priority=3, DateCreated=DateTime.Now.AddDays(-5), Description="Follow up deal ABC"},
                new TaskToDo(){Title="Purchase strong coffee", Priority=1, DateCreated=DateTime.Now.AddHours(-5), Description="Colmbian blend please"}
            };

             
        }


       // Public Counter prop - talks to the Private _counter
        public int Counter { get {
            return _counter;
        } set{
            _counter = value;
        } }

        public void Increment()
        {
            _counter++;
        }
        //fetch all the bugs 

        public List<WorkItem> fetchAllBugs() {
            return _allBugs;
        }
        
        // post to list from CREATE

        public void Create(Bug createBug)
        {
            _allBugs.Add(createBug);
           
        }

    }
}