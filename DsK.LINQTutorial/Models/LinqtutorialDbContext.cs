using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DsK.LINQTutorial.Models;

public partial class LinqtutorialDbContext : DbContext
{
    public LinqtutorialDbContext()
    {
    }

    public LinqtutorialDbContext(DbContextOptions<LinqtutorialDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAdditionalInfo> UserAdditionalInfos { get; set; }

    public virtual DbSet<UserPhoneNumber> UserPhoneNumbers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=LINQTutorialDB;Trusted_Connection=True;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasMany(d => d.Users).WithMany(p => p.Games)
                .UsingEntity<Dictionary<string, object>>(
                    "UserGame",
                    r => r.HasOne<User>().WithMany().HasForeignKey("UsersId"),
                    l => l.HasOne<Game>().WithMany().HasForeignKey("GamesId"),
                    j =>
                    {
                        j.HasKey("GamesId", "UsersId");
                        j.ToTable("UserGames");
                        j.HasIndex(new[] { "UsersId" }, "IX_UserGames_UsersId");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<UserAdditionalInfo>(entity =>
        {
            entity.ToTable("UserAdditionalInfo");

            entity.HasIndex(e => e.Email, "IX_UserAdditionalInfo_Email").IsUnique();

            entity.HasIndex(e => e.UserId, "IX_UserAdditionalInfo_UserId").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(256);

            entity.HasOne(d => d.User).WithOne(p => p.UserAdditionalInfo).HasForeignKey<UserAdditionalInfo>(d => d.UserId);
        });

        modelBuilder.Entity<UserPhoneNumber>(entity =>
        {
            entity.HasIndex(e => e.PhoneNumber, "IX_UserPhoneNumbers").IsUnique();

            entity.HasIndex(e => e.UserId, "IX_UserPhoneNumbers_UserId");

            entity.Property(e => e.PhoneNumber).HasMaxLength(12);

            entity.HasOne(d => d.User).WithMany(p => p.UserPhoneNumbers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPhoneNumbers_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
