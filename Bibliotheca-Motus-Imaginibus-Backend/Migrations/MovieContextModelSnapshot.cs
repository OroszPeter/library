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
                        .IsRequired()
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
                            Director = "James Cameron",
                            Genre = "Action",
                            Length = 137,
                            ReleasedDate = new DateTime(1991, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Terminator 2"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Christopher Nolan",
                            Genre = "Sci-Fi",
                            Length = 148,
                            ReleasedDate = new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Inception"
                        },
                        new
                        {
                            Id = 3,
                            Director = "Lana Wachowski",
                            Genre = "Sci-Fi",
                            Length = 136,
                            ReleasedDate = new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Matrix"
                        },
                        new
                        {
                            Id = 4,
                            Director = "Francis Ford Coppola",
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

                    b.Property<int>("RatingNumber")
                        .HasColumnType("int");

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
                            RatingNumber = 4,
                            UserId = "user1"
                        },
                        new
                        {
                            Id = 2,
                            Comment = "A classic, but a bit outdated.",
                            MovieId = 1,
                            RatingNumber = 4,
                            UserId = "user2"
                        },
                        new
                        {
                            Id = 3,
                            Comment = "Mind-blowing movie, loved the concept!",
                            MovieId = 2,
                            RatingNumber = 5,
                            UserId = "user3"
                        },
                        new
                        {
                            Id = 4,
                            Comment = "Brilliant, but hard to follow at times.",
                            MovieId = 2,
                            RatingNumber = 4,
                            UserId = "user4"
                        },
                        new
                        {
                            Id = 5,
                            Comment = "A masterpiece of cinema.",
                            MovieId = 3,
                            RatingNumber = 50,
                            UserId = "user1"
                        },
                        new
                        {
                            Id = 6,
                            Comment = "Incredible visuals and action scenes!",
                            MovieId = 3,
                            RatingNumber = 4,
                            UserId = "user5"
                        },
                        new
                        {
                            Id = 7,
                            Comment = "One of the greatest films ever made.",
                            MovieId = 4,
                            RatingNumber = 5,
                            UserId = "user6"
                        },
                        new
                        {
                            Id = 8,
                            Comment = "Amazing storytelling and acting.",
                            MovieId = 4,
                            RatingNumber = 4,
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
                            ConcurrencyStamp = "6a66cf13-7d05-4e39-9387-f05ce365278d",
                            Email = "user1@example.com",
                            EmailConfirmed = true,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1",
                            PasswordHash = "AQAAAAIAAYagAAAAEIkljxRx+t0HzDwUYocZaCoqA8O/verrdcSiCgV2Dhq/ZdN6e24z3Wu6cV20V3y5VQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "68b1981c-94e5-4490-b5ac-d17427251043",
                            TwoFactorEnabled = false,
                            UserName = "user1"
                        },
                        new
                        {
                            Id = "user2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d00152b4-2109-48a6-b4bc-afdb76fc6186",
                            Email = "user2@example.com",
                            EmailConfirmed = true,
                            FirstName = "Jane",
                            LastName = "Smith",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2",
                            PasswordHash = "AQAAAAIAAYagAAAAEHJywxhWbdlRuVNFi1czqdx979GxE3I4avsZvjkFIya7LUaKiK9n9FNgbwWILOS4Lw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "171c57a5-328c-4c90-9b9f-65359965d707",
                            TwoFactorEnabled = false,
                            UserName = "user2"
                        },
                        new
                        {
                            Id = "user3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9c8221ca-4105-4691-ba79-5007b71ec96f",
                            Email = "user3@example.com",
                            EmailConfirmed = true,
                            FirstName = "Alice",
                            LastName = "Johnson",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER3@EXAMPLE.COM",
                            NormalizedUserName = "USER3",
                            PasswordHash = "AQAAAAIAAYagAAAAEOcw0/8he3m7dA01jLtE0PLWrpEsATDPYGCneOcYHaQosw6ExXUY3a03PrLeiKJaKg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fd16d671-aec3-4051-ac88-ee79094606db",
                            TwoFactorEnabled = false,
                            UserName = "user3"
                        },
                        new
                        {
                            Id = "user4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c390df62-bbfb-4cc0-aab9-de2b3a911ffc",
                            Email = "user4@example.com",
                            EmailConfirmed = true,
                            FirstName = "Bob",
                            LastName = "Brown",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER4@EXAMPLE.COM",
                            NormalizedUserName = "USER4",
                            PasswordHash = "AQAAAAIAAYagAAAAEGd2HFhREd6Mk3wtzzoq9GOoVCIzMtWHnMN5wyxPskS/2yti/1OqBUXja0WV/KKQWg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c0a4cf30-447f-45b9-8a03-184dcb36da6d",
                            TwoFactorEnabled = false,
                            UserName = "user4"
                        },
                        new
                        {
                            Id = "user5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "44977e4a-0fb9-491a-b927-010019adf441",
                            Email = "user5@example.com",
                            EmailConfirmed = true,
                            FirstName = "Charlie",
                            LastName = "Davis",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER5@EXAMPLE.COM",
                            NormalizedUserName = "USER5",
                            PasswordHash = "AQAAAAIAAYagAAAAEINwdiFaOS7jwJUZN4v4hjoUppzFnqgu8p8SccPMrQ5wfaxOizA6+4K3TWlDAGkJAg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1d47d11e-a76e-497f-9043-04d9bbe2a519",
                            TwoFactorEnabled = false,
                            UserName = "user5"
                        },
                        new
                        {
                            Id = "user6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "05c44ade-9b77-4b88-87a6-b0946a4453ec",
                            Email = "user6@example.com",
                            EmailConfirmed = true,
                            FirstName = "Emily",
                            LastName = "Wilson",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER6@EXAMPLE.COM",
                            NormalizedUserName = "USER6",
                            PasswordHash = "AQAAAAIAAYagAAAAELDt/obl7F73V60VEMyAqhICj5lAGVHoo73g76ZReqp85lWBW1qprhb1zknQdW0S3Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "76de24da-34fa-4958-8304-99145d8d54b9",
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
                            AddedDate = new DateTime(2024, 11, 22, 10, 33, 52, 769, DateTimeKind.Local).AddTicks(284),
                            MovieId = 1,
                            UserId = "user1"
                        },
                        new
                        {
                            Id = 2,
                            AddedDate = new DateTime(2024, 11, 27, 10, 33, 52, 769, DateTimeKind.Local).AddTicks(366),
                            MovieId = 3,
                            UserId = "user1"
                        },
                        new
                        {
                            Id = 3,
                            AddedDate = new DateTime(2024, 11, 17, 10, 33, 52, 769, DateTimeKind.Local).AddTicks(369),
                            MovieId = 2,
                            UserId = "user2"
                        },
                        new
                        {
                            Id = 4,
                            AddedDate = new DateTime(2024, 11, 12, 10, 33, 52, 769, DateTimeKind.Local).AddTicks(372),
                            MovieId = 4,
                            UserId = "user3"
                        },
                        new
                        {
                            Id = 5,
                            AddedDate = new DateTime(2024, 11, 7, 10, 33, 52, 769, DateTimeKind.Local).AddTicks(375),
                            MovieId = 1,
                            UserId = "user4"
                        },
                        new
                        {
                            Id = 6,
                            AddedDate = new DateTime(2024, 11, 2, 10, 33, 52, 769, DateTimeKind.Local).AddTicks(379),
                            MovieId = 2,
                            UserId = "user5"
                        },
                        new
                        {
                            Id = 7,
                            AddedDate = new DateTime(2024, 10, 28, 10, 33, 52, 769, DateTimeKind.Local).AddTicks(388),
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
