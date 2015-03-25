using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bug315
{
    //Singleton...
    public class BugService
    {
        private static BugService _instance = null; // private variable that holds the BugService

        public static BugService Instance // set created automatically by instance. 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BugService();
                }
                return _instance;
            }
        }

        private int _counter;

        //constructor
        private BugService()
        {
            _counter = 10;
        }

        public int Counter
        {
            get
            {
                return _counter;
            }
            set
            {
                _counter = value;
            }
        }
        public void Increment()
        { 
            _counter++
        }

        // - Hold List
        // - Add & remove to the list
    }
}