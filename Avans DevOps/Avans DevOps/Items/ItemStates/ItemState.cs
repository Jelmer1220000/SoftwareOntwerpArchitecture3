using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Items.ItemStates
{
    public abstract class ItemState
    {
        public virtual void ToTodo()
        {
            throw new InvalidOperationException("Niet mogelijk vanuit deze fase");
        }

        public virtual void ToDoing()
        {
            throw new InvalidOperationException("Niet mogelijk vanuit deze fase");
        }

        public virtual void ToReadyForTesting()
        {
            throw new InvalidOperationException("Niet mogelijk vanuit deze fase");
        }

        public virtual void ToTesting()
        {
            throw new InvalidOperationException("Niet mogelijk vanuit deze fase");
        }

        public virtual void ToTested()
        {
            throw new InvalidOperationException("Niet mogelijk vanuit deze fase");
        }

        public virtual void ToDone()
        {
            throw new InvalidOperationException("Niet mogelijk vanuit deze fase");
        }
    }
}
