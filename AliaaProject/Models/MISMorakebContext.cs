using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AliaaProject.Models;

public partial class MISMorakebContext : DbContext
{
    public MISMorakebContext()
    {
    }

    public MISMorakebContext(DbContextOptions<MISMorakebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<College> Colleges { get; set; }

    public virtual DbSet<Committee> Committees { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Governorate> Governorates { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<JobGroup> JobGroups { get; set; }

    public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }

    public virtual DbSet<Observation> Observations { get; set; }

    public virtual DbSet<Qualification> Qualifications { get; set; }

    public virtual DbSet<QualificationLevel> QualificationLevels { get; set; }

    public virtual DbSet<QualitativeGroup> QualitativeGroups { get; set; }

    public virtual DbSet<University> Universities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-H8NV8VC\\SQLEXPRESS;Database=MISMorakeb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.Property(e => e.RoleId).HasMaxLength(450);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<College>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Committee>(entity =>
        {
            entity.Property(e => e.UserId).HasMaxLength(450);
            entity.Property(e => e.UserName).HasDefaultValue("");

            entity.HasOne(d => d.College).WithMany(p => p.Committees)
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Committees)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.NationalId);

            entity.Property(e => e.NationalId).HasMaxLength(14);
            entity.Property(e => e.Cadre).HasMaxLength(50);
            entity.Property(e => e.JobStyle).HasMaxLength(50);
            entity.Property(e => e.LastMonitoringPeriod)
                .HasMaxLength(10)
                .HasDefaultValue("NotDedicated");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Specialization).HasMaxLength(100);

            entity.HasOne(d => d.College).WithMany(p => p.Employees).HasForeignKey(d => d.CollegeId);

            entity.HasOne(d => d.Governorate).WithMany(p => p.Employees).HasForeignKey(d => d.GovernorateId);

            entity.HasOne(d => d.Grade).WithMany(p => p.Employees).HasForeignKey(d => d.GradeId);

            entity.HasOne(d => d.JobGroup).WithMany(p => p.Employees).HasForeignKey(d => d.JobGroupId);

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.Employees).HasForeignKey(d => d.MaritalStatusId);

            entity.HasOne(d => d.Qualification).WithMany(p => p.Employees).HasForeignKey(d => d.QualificationId);

            entity.HasOne(d => d.QualificationLevel).WithMany(p => p.Employees).HasForeignKey(d => d.QualificationLevelId);

            entity.HasOne(d => d.QualitativeGroup).WithMany(p => p.Employees).HasForeignKey(d => d.QualitativeGroupId);

            entity.HasOne(d => d.University).WithMany(p => p.Employees).HasForeignKey(d => d.UniversityId);
        });

        modelBuilder.Entity<Governorate>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<JobGroup>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<MaritalStatus>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Observation>(entity =>
        {
            entity.Property(e => e.DateOfObservation).HasColumnName("dateOfObservation");
            entity.Property(e => e.EmployeeId).HasMaxLength(14);

            entity.HasOne(d => d.Committee).WithMany(p => p.Observations).HasForeignKey(d => d.CommitteeId);

            entity.HasOne(d => d.Employee).WithMany(p => p.Observations).HasForeignKey(d => d.EmployeeId);
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<QualificationLevel>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<QualitativeGroup>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<University>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
