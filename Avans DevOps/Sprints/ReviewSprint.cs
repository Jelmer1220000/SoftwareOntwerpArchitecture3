﻿using Avans_DevOps.Forums;
using Avans_DevOps.Models;
using Avans_DevOps.Models.UserRoles;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.VersionControl;
using Avans_DevOps.Visitor;

namespace Avans_DevOps.Sprints
{
    public class ReviewSprint : Sprint
    {
        public byte[] reviewFile;
        public ReviewSprint(string name, DateOnly startDate, DateOnly endDate, Project project, Pipeline pipeline, IVersionControl versionControl, ScrumMaster scrumMaster, AForum forum) : base(name, startDate, endDate, project, pipeline, versionControl, scrumMaster, forum)
        {
        }

        internal override void AcceptVisitor(ISprintVisitor visitor)
        {
            visitor.AcceptReview(this);
        }

        public override void NextSprintState()
        {
            _sprintState.NextState();
        }
    }
}
