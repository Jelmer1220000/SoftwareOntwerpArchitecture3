using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Notifications
{
    public abstract class Subscriber
    {
        public virtual void SprintUpdate(string text)
        {

        }

        public virtual void ItemUpdate(string text)
        {

        }

        public virtual void ScrumMasterUpdate(string text) 
        { 
        
        }

        public virtual void TestersUpdate(string text) 
        {
        
        }

        public virtual void ProductOwnerUpdate(string text)
        {

        }

        public virtual void ThreadUpdate(string text)
        {
            
        }

    }
}
