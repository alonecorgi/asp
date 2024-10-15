using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Led.Models;

public partial class LedContext : DbContext
{
    public LedContext(DbContextOptions<LedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LED_state> LED_state { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LED_state>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_LED");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.state)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.time).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
