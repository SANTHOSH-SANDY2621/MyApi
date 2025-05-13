using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Models;

public partial class LearningNetContext : DbContext
{
    public LearningNetContext()
    {
    }

    public LearningNetContext(DbContextOptions<LearningNetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<VersionInfo> VersionInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Learning.Net;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__Employer__BAB7E67621842E66");

            entity.ToTable("Employer");

            entity.Property(e => e.TableId)
                .ValueGeneratedNever()
                .HasColumnName("Table_Id");
            entity.Property(e => e.EmpName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Employers)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("Fk_EMPLOYEEID");
        });

        modelBuilder.Entity<VersionInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VersionInfo");

            entity.HasIndex(e => e.Version, "UC_Version")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.AppliedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1024);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
