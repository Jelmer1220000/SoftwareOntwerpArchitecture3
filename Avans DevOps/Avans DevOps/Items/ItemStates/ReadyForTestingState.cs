﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Items.ItemStates
{
    public class ReadyForTestingState : ItemState
    {
        private readonly Item _context;

        public ReadyForTestingState(Item context)
        {
            _context = context;
        }

        public override void ToTesting()
        {
            _context.ToTestingState();
        }
    }
}
