using System.Collections.Generic;
using TrackMyJob.Framework.Entities;

namespace TrackMyJob.Domain.Entities
{
    public class Project : BaseEntity
    {
        public Project()
        {

        }

        public Project(string name)
        {
            this.Name = name;
            this.PathName = this.Name.ToLower().Replace(" ", string.Empty);
        }

        public string Name { get; private set; }

        public string PathName { get; private set; }
    }
}
