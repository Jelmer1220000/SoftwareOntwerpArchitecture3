using Avans_DevOps.Pipelines.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Pipelines.PipelineActions.BuildComponents
{
    public class BuildAnt : PipelineComponent
    {
        public BuildAnt(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
