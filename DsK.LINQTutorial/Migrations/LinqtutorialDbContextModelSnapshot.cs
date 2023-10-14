﻿// <auto-generated />
using DsK.LINQTutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DsK.LINQTutorial.Migrations
{
    [DbContext(typeof(LinqtutorialDbContext))]
    partial class LinqtutorialDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DsK.LINQTutorial.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DsK.LINQTutorial.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DsK.LINQTutorial.Models.UserAdditionalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_UserAdditionalInfo_Email")
                        .IsUnique();

                    b.HasIndex(new[] { "UserId" }, "IX_UserAdditionalInfo_UserId")
                        .IsUnique();

                    b.ToTable("UserAdditionalInfo", (string)null);
                });

            modelBuilder.Entity("DsK.LINQTutorial.Models.UserPhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PhoneNumber" }, "IX_UserPhoneNumbers")
                        .IsUnique();

                    b.HasIndex(new[] { "UserId" }, "IX_UserPhoneNumbers_UserId");

                    b.ToTable("UserPhoneNumbers");
                });

            modelBuilder.Entity("UserGame", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "UsersId");

                    b.HasIndex(new[] { "UsersId" }, "IX_UserGames_UsersId");

                    b.ToTable("UserGames", (string)null);
                });

            modelBuilder.Entity("DsK.LINQTutorial.Models.UserAdditionalInfo", b =>
                {
                    b.HasOne("DsK.LINQTutorial.Models.User", "User")
                        .WithOne("UserAdditionalInfo")
                        .HasForeignKey("DsK.LINQTutorial.Models.UserAdditionalInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DsK.LINQTutorial.Models.UserPhoneNumber", b =>
                {
                    b.HasOne("DsK.LINQTutorial.Models.User", "User")
                        .WithMany("UserPhoneNumbers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserPhoneNumbers_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserGame", b =>
                {
                    b.HasOne("DsK.LINQTutorial.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DsK.LINQTutorial.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DsK.LINQTutorial.Models.User", b =>
                {
                    b.Navigation("UserAdditionalInfo");

                    b.Navigation("UserPhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}