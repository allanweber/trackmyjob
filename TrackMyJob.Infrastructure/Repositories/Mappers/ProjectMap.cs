﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackMyJob.Domain.Entities;

namespace TrackMyJob.Infrastructure.Repositories.Mappers
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.ToTable(nameof(Project));
        }
    }
}
