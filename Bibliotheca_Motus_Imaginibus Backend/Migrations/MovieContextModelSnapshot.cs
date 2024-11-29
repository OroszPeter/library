﻿// <auto-generated />
using System;
using Bibliotheca_Motus_Imaginibus_API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bibliotheca_Motus_Imaginibus_API.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bibliotheca_Motus_Imaginibus_API.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Director")
                        .HasColumnType("longtext");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<byte[]>("Poster")
                        .HasColumnType("longblob");

                    b.Property<DateTime>("ReleasedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("WatchlistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WatchlistId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre = "Action",
                            Length = 137,
                            ReleasedDate = new DateTime(1991, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Terminator 2"
                        },
                        new
                        {
                            Id = 2,
                            Genre = "Sci-Fi",
                            Length = 148,
                            ReleasedDate = new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Inception"
                        },
                        new
                        {
                            Id = 3,
                            Genre = "Sci-Fi",
                            Length = 136,
                            ReleasedDate = new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Matrix"
                        },
                        new
                        {
                            Id = 4,
                            Genre = "Crime",
                            Length = 175,
                            ReleasedDate = new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Godfather"
                        });
                });

            modelBuilder.Entity("Bibliotheca_Motus_Imaginibus_API.Entities.Ratings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<decimal>("RatingNumber")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "Amazing action, great storyline!",
                            MovieId = 1,
                            RatingNumber = 4.5m,
                            UserId = "user1"
                        },
                        new
                        {
                            Id = 2,
                            Comment = "A classic, but a bit outdated.",
                            MovieId = 1,
                            RatingNumber = 4.0m,
                            UserId = "user2"
                        },
                        new
                        {
                            Id = 3,
                            Comment = "Mind-blowing movie, loved the concept!",
                            MovieId = 2,
                            RatingNumber = 5.0m,
                            UserId = "user3"
                        },
                        new
                        {
                            Id = 4,
                            Comment = "Brilliant, but hard to follow at times.",
                            MovieId = 2,
                            RatingNumber = 4.7m,
                            UserId = "user4"
                        },
                        new
                        {
                            Id = 5,
                            Comment = "A masterpiece of cinema.",
                            MovieId = 3,
                            RatingNumber = 5.0m,
                            UserId = "user1"
                        },
                        new
                        {
                            Id = 6,
                            Comment = "Incredible visuals and action scenes!",
                            MovieId = 3,
                            RatingNumber = 4.8m,
                            UserId = "user5"
                        },
                        new
                        {
                            Id = 7,
                            Comment = "One of the greatest films ever made.",
                            MovieId = 4,
                            RatingNumber = 5.0m,
                            UserId = "user6"
                        },
                        new
                        {
                            Id = 8,
                            Comment = "Amazing storytelling and acting.",
                            MovieId = 4,
                            RatingNumber = 4.9m,
                            UserId = "user2"
                        });
                });

            modelBuilder.Entity("Bibliotheca_Motus_Imaginibus_API.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "user1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "08e1583e-034a-45f7-af5c-e36ba91b05f7",
                            Email = "user1@example.com",
                            EmailConfirmed = true,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1",
                            PasswordHash = "AQAAAAIAAYagAAAAEBySUGS8UcfBB3/Cj2/jguZv8c4llhkSws4q3JA5qH00N2bF/wWQRx4pad0ybreskg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9f359cf8-d1fb-495d-ac7b-dc7ae9d3b2c6",
                            TwoFactorEnabled = false,
                            UserName = "user1"
                        },
                        new
                        {
                            Id = "user2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cd6f42f9-0046-4ccc-9f34-bfb3da30a4ee",
                            Email = "user2@example.com",
                            EmailConfirmed = true,
                            FirstName = "Jane",
                            LastName = "Smith",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2",
                            PasswordHash = "AQAAAAIAAYagAAAAEPct2TkM4HiK302u4m2JSPu+hdqx9b+RuL8bEFhs+t7fDM6MGJOvSY1WySQnD8jU7g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "46230929-e8f9-4b6b-908c-69f3154677ae",
                            TwoFactorEnabled = false,
                            UserName = "user2"
                        },
                        new
                        {
                            Id = "user3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7f584949-c03f-4a1c-8182-f6baa7054469",
                            Email = "user3@example.com",
                            EmailConfirmed = true,
                            FirstName = "Alice",
                            LastName = "Johnson",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER3@EXAMPLE.COM",
                            NormalizedUserName = "USER3",
                            PasswordHash = "AQAAAAIAAYagAAAAEBZC7tXbiDHES6B65fNafuhwUqRKZqVLsmeISalLa+3E1NLLtpzdMHftkwi2ltcdHA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7eb53c3a-3634-4993-8299-0f46eba44c04",
                            TwoFactorEnabled = false,
                            UserName = "user3"
                        },
                        new
                        {
                            Id = "user4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "21577de9-93ed-4ecf-be51-a533fb6175c7",
                            Email = "user4@example.com",
                            EmailConfirmed = true,
                            FirstName = "Bob",
                            LastName = "Brown",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER4@EXAMPLE.COM",
                            NormalizedUserName = "USER4",
                            PasswordHash = "AQAAAAIAAYagAAAAEJlvoy2Qup7VGuJqwxJcXevpSCyh09XycqHeG0KcPKFUZR3bS7jHZ6eGPvU01UNxFg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2c57e422-a273-4e7e-8a6f-236c2c90856b",
                            TwoFactorEnabled = false,
                            UserName = "user4"
                        },
                        new
                        {
                            Id = "user5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b576e19f-39d3-4847-b658-a18c90b85bdf",
                            Email = "user5@example.com",
                            EmailConfirmed = true,
                            FirstName = "Charlie",
                            LastName = "Davis",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER5@EXAMPLE.COM",
                            NormalizedUserName = "USER5",
                            PasswordHash = "AQAAAAIAAYagAAAAEJIMqyvhoVHLtKlNoZgSyAZu/CGcQko9T6eu/1M/VeVynBwIM6Wq9bWEhH8nZOEnyg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4528acd8-7470-43f4-8a43-34a2a6a8bb98",
                            TwoFactorEnabled = false,
                            UserName = "user5"
                        },
                        new
                        {
                            Id = "user6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b68be611-919f-45c0-8640-aed030b58edc",
                            Email = "user6@example.com",
                            EmailConfirmed = true,
                            FirstName = "Emily",
                            LastName = "Wilson",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER6@EXAMPLE.COM",
                            NormalizedUserName = "USER6",
                            PasswordHash = "AQAAAAIAAYagAAAAEMWERV5Voona/RTWCjuKEP6pzjU+f4MsvDsSkSthbmm10Uo3KVXvrRdqq4AdPjNfvA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8ed46e6a-966e-40ba-8013-a7fa3c809722",
                            TwoFactorEnabled = false,
                            UserName = "user6"
                        });
                });

            modelBuilder.Entity("Bibliotheca_Motus_Imaginibus_API.Entities.Watchlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Watchlists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedDate = new DateTime(2024, 11, 17, 9, 8, 37, 747, DateTimeKind.Local).AddTicks(8227),
                            MovieId = 1,
                            UserId = "user1"
                        },
                        new
                        {
                            Id = 2,
                            AddedDate = new DateTime(2024, 11, 22, 9, 8, 37, 747, DateTimeKind.Local).AddTicks(8297),
                            MovieId = 3,
                            UserId = "user1"
                        },
                        new
                        {
                            Id = 3,
                            AddedDate = new DateTime(2024, 11, 12, 9, 8, 37, 747, DateTimeKind.Local).AddTicks(8299),
                            MovieId = 2,
                            UserId = "user2"
                        },
                        new
                        {
                            Id = 4,
                            AddedDate = new DateTime(2024, 11, 7, 9, 8, 37, 747, DateTimeKind.Local).AddTicks(8302),
                            MovieId = 4,
                            UserId = "user3"
                        },
                        new
                        {
                            Id = 5,
                            AddedDate = new DateTime(2024, 11, 2, 9, 8, 37, 747, DateTimeKind.Local).AddTicks(8304),
                            MovieId = 1,
                            UserId = "user4"
                        },
                        new
                        {
                            Id = 6,
                            AddedDate = new DateTime(2024, 10, 28, 9, 8, 37, 747, DateTimeKind.Local).AddTicks(8306),
                            MovieId = 2,
                            UserId = "user5"
                        },
                        new
                        {
                            Id = 7,
                            AddedDate = new DateTime(2024, 10, 23, 9, 8, 37, 747, DateTimeKind.Local).AddTicks(8312),
                            MovieId = 4,
                            UserId = "user6"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "user-role-id",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "user1",
                            RoleId = "user-role-id"
                        },
                        new
                        {
                            UserId = "user2",
                            RoleId = "user-role-id"
                        },
                        new
                        {
                            UserId = "user3",
                            RoleId = "user-role-id"
                        },
                        new
                        {
                            UserId = "user4",
                            RoleId = "user-role-id"
                        },
                        new
                        {
                            UserId = "user5",
                            RoleId = "user-role-id"
                        },
                        new
                        {
                            UserId = "user6",
                            RoleId = "user-role-id"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Bibliotheca_Motus_Imaginibus_API.Entities.Movie", b =>
                {
                    b.HasOne("Bibliotheca_Motus_Imaginibus_API.Entities.Watchlist", null)
                        .WithMany("Movies")
                        .HasForeignKey("WatchlistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bibliotheca_Motus_Imaginibus_API.Entities.Ratings", b =>
                {
                    b.HasOne("Bibliotheca_Motus_Imaginibus_API.Entities.Movie", "Movie")
                        .WithMany("Ratings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotheca_Motus_Imaginibus_API.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bibliotheca_Motus_Imaginibus_API.Entities.Watchlist", b =>
                {
                    b.HasOne("Bibliotheca_Motus_Imaginibus_API.Entities.User", "User")
                        .WithMany("Watchlists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Bibliotheca_Motus_Imaginibus_API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Bibliotheca_Motus_Imaginibus_API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotheca_Motus_Imaginibus_API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Bibliotheca_Motus_Imaginibus_API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bibliotheca_Motus_Imaginibus_API.Entities.Movie", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Bibliotheca_Motus_Imaginibus_API.Entities.User", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Watchlists");
                });

            modelBuilder.Entity("Bibliotheca_Motus_Imaginibus_API.Entities.Watchlist", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
