using Avans_DevOps.Pipelines.Visitor;

namespace Avans_DevOps.Pipelines.PipelineComponents.UtilityComponents
{
    public class Utility : PipelineComponent
    {
        internal IList<Action> actionList;
        public Utility(string name) : base(name)
        {
            actionList = [];
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void AddAction(Action action)
        {
            actionList.Add(action);
        }
    }
}
