using EFcore02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFcore02.Configurations
{
    internal class OrganizerProfileConfiguration : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(
         EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.HasKey(p => p.OrganizerProfileId);

            builder.Property(p => p.Bio)
                   .HasMaxLength(500);

            builder.Property(p => p.WebsiteUrl)
                   .HasMaxLength(300);

            builder.Property(p => p.LogoUrl)
                   .HasMaxLength(300);

            builder.HasOne(p => p.Organizer)
                   .WithOne(o => o.Profile)
                   .HasForeignKey<OrganizerProfile>(
                       p => p.OrganizerId)
                   .IsRequired();
        }

    }
}
