using Microsoft.EntityFrameworkCore;
using StopLightManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagement.Context
{
    public class TierMeetingContext : DbContext
    {
        public TierMeetingContext(DbContextOptions<TierMeetingContext> options)
            : base(options)
        {
        }

        public TierMeetingContext()
        {
        }

        protected override void
       OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeetingKPI>()
                .HasKey(x => new { x.MeetingID, x.KPIID });

            modelBuilder.Entity<Attendee>()
                .HasKey(x => new { x.MeetingID, x.EmployeeID });

            modelBuilder.Entity<Site>()
                        .HasKey(x => new { x.SiteCode, x.OrganizationID });

            modelBuilder.Entity<Site>()
                        .HasOne(s => s.Organization)
                        .WithMany(O => O.Sites)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                       .HasOne(d => d.Site)
                       .WithMany(s => s.Departments)
                       .IsRequired()
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Meeting>()
                       .HasOne(m => m.Site)
                       .WithMany(s => s.Meetings)
                       .IsRequired()
                       .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Issue>()
                       .HasOne(i => i.Owner)
                       .WithMany(e => e.IssuesOwned)
                       .IsRequired()
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Issue>()
                       .HasOne(i => i.RaisedBy)
                       .WithMany(e => e.IssuesRaised)
                       .IsRequired()
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IssueComment>()
                      .HasOne(ic => ic.Issue)
                      .WithMany(i => i.IssueComments)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Meeting>()
                        .HasCheckConstraint("ck_TierLevel", "TierLevel Between 0 AND 10")
                        .HasCheckConstraint("ck_Frequency", "Frequency IN ('Daily','Weekly','Bi-Weekly','Monthly')");

            modelBuilder.Entity<Target>()
                .HasCheckConstraint("ck_NullRange", "LowerRange is not null or UpperRange is not null");

            modelBuilder.Entity<Organization>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Department>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Employee>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Employee>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<IssueComment>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<KPI>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Meeting>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Site>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Target>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Issue>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getutcdate()");
        }

        public DbSet<Site> Sites { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<KPI> KPIS { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueComment> IssueComments { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StopLightManagement.Models.Attendee> Attendee { get; set; }
        public DbSet<StopLightManagement.Models.IssueStatus> IssueStatus { get; set; }
        public DbSet<StopLightManagement.Models.MeetingKPI> MeetingKPI { get; set; }

    }
}
