using System;
using System.Linq.Expressions;
using TrackMyJob.Domain.Entities;
using TrackMyJob.Framework.Specifications;

namespace TrackMyJob.Domain.Specifications
{
    public class AssignmentsLateByProjectId : BaseSpecification<Assignment>
    {
        public AssignmentsLateByProjectId(int projectId)
        {
            ProjectId = projectId;
        }

        public override string Description => string.Empty;

        public int ProjectId { get; }

        protected override Expression<Func<Assignment, bool>> GetFinalExpression()
            => assignment => assignment.ProjectId == this.ProjectId 
            && assignment.DueDate < DateTime.Now;
    }
}
