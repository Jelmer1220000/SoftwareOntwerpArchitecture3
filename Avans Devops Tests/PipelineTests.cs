using Avans_DevOps.Models.UserRoles;
using Avans_DevOps.Models;
using Avans_DevOps.Notifications;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Sprints.SprintFactory;
using Avans_DevOps.Sprints;
using Avans_DevOps.VersionControl.Factory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_DevOps.Visitor;

namespace Avans_Devops_Tests
{
    public class PipelineTests
    {
        [Fact]
        public void Pipeline_can_be_run()
        {
            //Arrange
            var pipeline =  new Mock<Pipeline>();
            var PipelineVisitor = new Mock<PipelineVisitor>();
            //Act

            //Assert
            
        }
    }
}
