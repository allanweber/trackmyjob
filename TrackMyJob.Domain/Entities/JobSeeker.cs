using TrackMyJob.Framework.Entities;

namespace TrackMyJob.Domain.Entities
{
    public class JobSeeker: BaseEntity
    {
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; } 
    }
}
