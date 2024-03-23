using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Models
{
    public class Activity
    {
        private bool _isDone = false;

        

        public bool SetActivityState(bool  isDone)
        {
           return _isDone = isDone;
        }

        public bool isActivityDone()
        {
            return _isDone;
        }
    }
}
