using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Workflow.Infrastructure.Data.Models;

public partial class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Priority> Priority { get; set; }

    public virtual DbSet<State> State { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.HasIndex(e => e.Description, "IX_Priority_Description").IsUnique();

            entity.Property(e => e.Code).ValueGeneratedNever();
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.HasIndex(e => e.Description, "IX_State_Description").IsUnique();

            entity.Property(e => e.Code).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.HasOne(d => d.PriorityCodeNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.PriorityCode)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.StateCodeNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StateCode)
                .OnDelete(DeleteBehavior.Restrict);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
