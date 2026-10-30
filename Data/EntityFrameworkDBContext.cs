using EFcore02.Configurations;
using EFcore02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFcore02.Data
{
    public class EntityFrameworkDBContext : DbContext
    {
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                "Server=.;Database=EntityFramework02;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }
       
        public EntityFrameworkDBContext()
        {
        }

        public EntityFrameworkDBContext(
            DbContextOptions<EntityFrameworkDBContext> options)
            : base(options)
        {
        }

      



        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Badge> Badges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // OrganizerProfile Configuration
            modelBuilder.ApplyConfiguration(
                new OrganizerProfileConfiguration());

            // Event Configuration
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.Title)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(e => e.Description)
                      .IsRequired();

                entity.HasOne(e => e.Organizer)
                      .WithMany(o => o.Events)
                      .HasForeignKey(e => e.OrganizerId)
                      .IsRequired();
            });

            // Badge Configuration
            modelBuilder.Entity<Badge>(entity =>
            {
                entity.HasKey(b => b.BadgeId);

                entity.Property(b => b.BadgeNumber)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasIndex(b => b.BadgeNumber)
                      .IsUnique();

                entity.Property(b => b.IssuedDate)
                      .IsRequired();

                entity.Property(b => b.Tier)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.HasCheckConstraint(
                    "CK_Badge_Tier",
                    "[Tier] IN ('Standard', 'VIP')");

                entity.HasOne(b => b.Attendee)
                      .WithOne(a => a.Badge)
                      .HasForeignKey<Badge>(b => b.AttendeeId)
                      .IsRequired();
            });

            // Attendee - Badge One-to-One
            modelBuilder.Entity<Badge>()
                .HasIndex(b => b.AttendeeId)
                .IsUnique();
        }


    }
}
