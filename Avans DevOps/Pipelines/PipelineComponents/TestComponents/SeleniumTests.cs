using Avans_DevOps.Pipelines.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Pipelines.PipelineActions.TestComponents
{
    internal class SeleniumTests : PipelineComponent
    {
        public SeleniumTests(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
