using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Items.ItemStates
{
    public interface IItemState
    {
        public void NextState();

        public void OnEnter();

        public void BackToTesting();

        public void BackToStart();
    }
}
