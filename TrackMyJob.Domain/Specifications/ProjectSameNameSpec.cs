using System;
using System.Linq.Expressions;
using TrackMyJob.Domain.Entities;
using TrackMyJob.Framework.Specifications;

namespace TrackMyJob.Domain.Specifications
{
    public class ProjectSameNameSpec: BaseSpecification<Project>
    {
        public ProjectSameNameSpec(Project project)
        {
            this.Project = project;
        }

        public override string Description => $"Already exist a project with name {Project.Name}";

        public Project Project { get; }

        protected override Expression<Func<Project, bool>> GetFinalExpression()
            => project => project.Name == this.Project.Name && project.Id != this.Project.Id;
    }
}
