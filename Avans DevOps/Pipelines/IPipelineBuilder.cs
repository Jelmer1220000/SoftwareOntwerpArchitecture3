using System.ComponentModel;


namespace Avans_DevOps.Pipelines
{
    public interface IPipelineBuilder
    {
       public IPipelineBuilder AddComponent(IComponent component);
      /* public IPipelineBuilder AddTesting(ITestingVisitor testingVisitor);*/
       public IPipelineBuilder AddCustomAction(Action customAction);
       public IPipeline Build();
    }
}
