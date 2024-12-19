using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bibliotheca_Motus_Imaginibus_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "List<string>",
                columns: table => new
                {
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Genre = table.Column<string>(type: "longtext", nullable: false),
                    Director = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Actor1 = table.Column<string>(type: "longtext", nullable: false),
                    Actor2 = table.Column<string>(type: "longtext", nullable: false),
                    Actor3 = table.Column<string>(type: "longtext", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Poster = table.Column<byte[]>(type: "longblob", nullable: true),
                    WatchlistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RatingNumber = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Watchlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watchlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watchlists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watchlists_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "user-role-id", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user1", 0, "06ca0a4d-9dc3-44d5-84c7-19aafc24c2e1", "user1@example.com", true, "FirstName1", "LastName1", false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAEF+hYbNBmjQ40+xGc0QJRvXlDDiXi070D0JHjtV8lMhGXKi9bKD2x6eMQqldV3qVNg==", null, false, "a06bd2f0-fb70-4217-8be4-0681766fa774", false, "user1" },
                    { "user10", 0, "6a9d6ff1-6e95-4606-8f0a-84ea562bca21", "user10@example.com", true, "FirstName10", "LastName10", false, null, "USER10@EXAMPLE.COM", "USER10", "AQAAAAIAAYagAAAAEJw8ozY8kbRe1JkYCtj8J+2CDVjo7WNuzO8Zx29g8WkKQYedejMlwC/+Y+RCybcTZQ==", null, false, "52575fdd-7dab-4de3-8d4b-50c6b9b22e87", false, "user10" },
                    { "user11", 0, "761e6b59-59e2-42d5-8fa4-5ac4e9f5f3da", "user11@example.com", true, "FirstName11", "LastName11", false, null, "USER11@EXAMPLE.COM", "USER11", "AQAAAAIAAYagAAAAEM664Aq/WzppCUzutT8kU7hWRXOzvUPIulChGUNxlXMdV8f/VqdocTZG0Br0U1wvTg==", null, false, "d70046cf-ce2a-4520-87bd-2638b0ef318d", false, "user11" },
                    { "user12", 0, "ed60c87f-b4cc-405d-ab3f-5492b6e1a1c7", "user12@example.com", true, "FirstName12", "LastName12", false, null, "USER12@EXAMPLE.COM", "USER12", "AQAAAAIAAYagAAAAEJ5r5k2Am90PxoIuO1bg+yWiXox6l17GEmx74crzHprWYoMrXYUj3rNND0L4x8udnQ==", null, false, "3125afe6-d889-4d53-863b-fa90b523f17e", false, "user12" },
                    { "user13", 0, "d316095a-ca32-4d5e-b525-097a29c5ceeb", "user13@example.com", true, "FirstName13", "LastName13", false, null, "USER13@EXAMPLE.COM", "USER13", "AQAAAAIAAYagAAAAEHM/3Fxkb1PzXMs5zPrJaHnOPAS08XY2xRHILV99O4e66U8owb01yB9zviDX7K4ISg==", null, false, "f7b3cfb3-79a6-4977-afb8-5794b4b088eb", false, "user13" },
                    { "user14", 0, "5b8c6083-5460-4ab8-9e22-c405de9102b9", "user14@example.com", true, "FirstName14", "LastName14", false, null, "USER14@EXAMPLE.COM", "USER14", "AQAAAAIAAYagAAAAEGOQ68XpymRF3Cc319+rmmLXc486TAj/7tssl5HMlIyOAigZILIGPJhAS5UpQ8uPfg==", null, false, "23e1c3bd-815a-444c-a654-bd9f6736d76f", false, "user14" },
                    { "user15", 0, "11c47537-a21d-4692-9b92-5565e6ea8252", "user15@example.com", true, "FirstName15", "LastName15", false, null, "USER15@EXAMPLE.COM", "USER15", "AQAAAAIAAYagAAAAEN8qQysDZ7I65BukAe6COM2JDV7mD3OJ9j9OXNJU0Jnrd+qV1A8tvvGEGhMR+WUShQ==", null, false, "53a29119-aec9-44d1-bfce-681c9443efd8", false, "user15" },
                    { "user16", 0, "fc238313-b015-4eec-8a08-f539f03588bc", "user16@example.com", true, "FirstName16", "LastName16", false, null, "USER16@EXAMPLE.COM", "USER16", "AQAAAAIAAYagAAAAEAgSPcH37QUr2wY6Ov1gy4isEU9+9mjGJpqkMZu8ZaWIa1o33a571yJNFhJrnj/Xcw==", null, false, "e7b07aa4-14f3-4786-aac5-31310d3a0d3c", false, "user16" },
                    { "user17", 0, "bf297c2e-b55c-47e0-b195-0525e1ad2891", "user17@example.com", true, "FirstName17", "LastName17", false, null, "USER17@EXAMPLE.COM", "USER17", "AQAAAAIAAYagAAAAEHy09jYN9lQItYFL+KosSNSlPbQx1OGtL2yGpW0ytypPpCR+YWeV9kKoTBLtEX2NcA==", null, false, "04616aee-1859-4e31-ae54-60e043ccb980", false, "user17" },
                    { "user18", 0, "d613e376-67ea-49ea-971e-516403e1898e", "user18@example.com", true, "FirstName18", "LastName18", false, null, "USER18@EXAMPLE.COM", "USER18", "AQAAAAIAAYagAAAAEH3sw2eBfSiBe5oCE8sXXBqCsXXwL8QWhj3R26OLXvVlPZsRgaK2q6ioHsM8qInpnQ==", null, false, "0fbc355c-fc4d-40fc-8962-efcdfdeb35ed", false, "user18" },
                    { "user19", 0, "9e6808f6-4f35-4ea2-8c6d-c76ca12426e7", "user19@example.com", true, "FirstName19", "LastName19", false, null, "USER19@EXAMPLE.COM", "USER19", "AQAAAAIAAYagAAAAEGbruQ2Q+8+JVEke1LYS4xxO/2107VNCXlXupGES+HJ1EhgAPOOC5aEjFoyZoMifRw==", null, false, "17e04e27-b090-45db-8800-1e5edca96095", false, "user19" },
                    { "user2", 0, "8f6afce0-8236-484e-906b-f19e3faefd60", "user2@example.com", true, "FirstName2", "LastName2", false, null, "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEO0JYTmEcjiRYxwOvkkEx0j2OqfX55Ge3nSLA5ikFDFPUhxn8e6bvRq6Ug0ubAb/Hw==", null, false, "322e9fec-1691-42a3-816e-1d49512398f7", false, "user2" },
                    { "user20", 0, "033b8011-380c-4e8d-955c-6041e6cd6099", "user20@example.com", true, "FirstName20", "LastName20", false, null, "USER20@EXAMPLE.COM", "USER20", "AQAAAAIAAYagAAAAENWZGatPPHiG2WxJlvMSZHgT0JViNAb/1CGZ5b3zGwyqOHcxoZgx9KJRifc3hDpcIw==", null, false, "60960e12-b785-4e5b-b1de-77777371e73d", false, "user20" },
                    { "user21", 0, "600e2361-9e60-422c-aeaa-0924e4f162bd", "user21@example.com", true, "FirstName21", "LastName21", false, null, "USER21@EXAMPLE.COM", "USER21", "AQAAAAIAAYagAAAAEJIZia7xfwtjA5e+q6pfbwqn6XK3mHsvILshyTa2TiT3oOSWxDbYNVyilew3sbcqZA==", null, false, "55286b55-453f-4d31-a3b1-486237d05360", false, "user21" },
                    { "user22", 0, "88b24c33-c5e9-4f46-bb38-32c2e4e3ae05", "user22@example.com", true, "FirstName22", "LastName22", false, null, "USER22@EXAMPLE.COM", "USER22", "AQAAAAIAAYagAAAAEEFfo6XeY1rMoJ2OnExQyAQV0xopJ2p3isF40j1YvZUP9D0p+JxtMVy3w6tdM6mYhw==", null, false, "6d45de2a-5890-4d7f-bd7a-c759673d68bb", false, "user22" },
                    { "user23", 0, "6a30f455-33ae-45b7-84ee-6c3e9174f2eb", "user23@example.com", true, "FirstName23", "LastName23", false, null, "USER23@EXAMPLE.COM", "USER23", "AQAAAAIAAYagAAAAEEFMIkqEDD7bTNJK8oan4RnAa6NT3mH1vtShCueXHpo1xlxDUs95RPDc3kKTGTPzpw==", null, false, "d76b1193-c0f7-4de8-a15d-276a896354fd", false, "user23" },
                    { "user24", 0, "88115932-3586-4efc-9f9d-25b21e93f22e", "user24@example.com", true, "FirstName24", "LastName24", false, null, "USER24@EXAMPLE.COM", "USER24", "AQAAAAIAAYagAAAAEBU0Yml6XLOt5B/ty1IHB5/NtvZImjwg2SpGk2V2qNt33+A1xytY7pmUNDpLCtjkfA==", null, false, "c0a2980c-699e-4384-bf5e-da1d8fbb56cd", false, "user24" },
                    { "user25", 0, "248580cd-eec2-4203-be5b-28b0a51d0a78", "user25@example.com", true, "FirstName25", "LastName25", false, null, "USER25@EXAMPLE.COM", "USER25", "AQAAAAIAAYagAAAAEHEJNMP44qbg8unQGeJAfYY2yKBQNhWrsJHHYBUEYB/afeMfuiRRXCnmHVtLpuSkTA==", null, false, "0067a6c8-3ddc-4b60-9d2b-1a371d51f3fa", false, "user25" },
                    { "user3", 0, "81a42c4d-4ec2-4f6d-8930-08c50456d763", "user3@example.com", true, "FirstName3", "LastName3", false, null, "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAEM1zarVRoMMQKOB8nzE4iiGe151ZgSex6mVykjyxx1/hhMYkIgFBF6BvTaTAjVyozw==", null, false, "7cd766d9-e9bb-4cf7-94fd-90bce630bd2e", false, "user3" },
                    { "user4", 0, "7ea48619-158b-47c8-b105-530fffcc9f0b", "user4@example.com", true, "FirstName4", "LastName4", false, null, "USER4@EXAMPLE.COM", "USER4", "AQAAAAIAAYagAAAAEBRimH9HED5D2Dil6E2OegZ5dA8fEHS17GmGcaeQV5cGTvbdHdUwMxJ93cwyqZwW5Q==", null, false, "cab8f780-524c-47b2-9aba-ebe1e5027bc5", false, "user4" },
                    { "user5", 0, "6fb0e05a-4655-42ad-b948-8b30d1fcb326", "user5@example.com", true, "FirstName5", "LastName5", false, null, "USER5@EXAMPLE.COM", "USER5", "AQAAAAIAAYagAAAAEEYrRe5m41BfTHmUUifroBzb9ycCX0SR1KhoILqOC4HFtzCXaX/vKQEHohwPm8o/Jw==", null, false, "9cd2db6d-b1d2-443a-824a-d4d2429f7474", false, "user5" },
                    { "user6", 0, "06dddedd-48f8-4737-886a-b5420fe3de2b", "user6@example.com", true, "FirstName6", "LastName6", false, null, "USER6@EXAMPLE.COM", "USER6", "AQAAAAIAAYagAAAAEOusbs1hbyCl+OWVqH4fIwYUAjkxB9mIHqPSKI4LkCAwRgQ6nFhHMbWGTJJudQCLzQ==", null, false, "60da2dbe-07f3-43b1-9316-e3394c0f13e1", false, "user6" },
                    { "user7", 0, "852b496c-28a8-473d-9695-b6a749ac721f", "user7@example.com", true, "FirstName7", "LastName7", false, null, "USER7@EXAMPLE.COM", "USER7", "AQAAAAIAAYagAAAAEOaOY7DuLOtos/zuiE3qi8AjLQQfgf7ObVB9lZt1Ba9CsJnq8N0TJhpuXSxMXcUNVQ==", null, false, "37a6c1b2-c53b-458b-8aef-278e234580bc", false, "user7" },
                    { "user8", 0, "7a113ab1-811d-4101-be51-527b71504ca4", "user8@example.com", true, "FirstName8", "LastName8", false, null, "USER8@EXAMPLE.COM", "USER8", "AQAAAAIAAYagAAAAELzEpnvj5YP960Vn1gkvcyrbapz9LEW67EZvDYgRQ96YnDgPqO8Ah5Dw92+EofI3EA==", null, false, "78c18f98-7980-4828-b868-95d27865f032", false, "user8" },
                    { "user9", 0, "6bc2f4ff-7bff-436f-b048-8985507e1e4d", "user9@example.com", true, "FirstName9", "LastName9", false, null, "USER9@EXAMPLE.COM", "USER9", "AQAAAAIAAYagAAAAEIorT0z7IkIDzwP3yyZRj3sJmF4qG1golqLQQqJ4fRhozV7YMsQqfD+XX74V8fMINQ==", null, false, "3640f385-6d6c-4e33-a14d-ad34e6579beb", false, "user9" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Actor1", "Actor2", "Actor3", "AddedAt", "Description", "Director", "Genre", "Length", "Poster", "ReleasedDate", "Title", "WatchlistId" },
                values: new object[,]
                {
                    { 1, "Arnold Schwarzenegger", "Linda Hamilton", "Edward Furlong", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(5143), "A gépek és emberek háborújának közepén a jövőbeli vezető, John Connor, visszaküldi a Terminátort, hogy megvédje a fiatalabb önmagát a gépek elől.", "James Cameron", "Akció", 137, null, new DateTime(1991, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terminátor 2", null },
                    { 2, "Leonardo DiCaprio", "Joseph Gordon-Levitt", "Ellen Page", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(5597), "Egy tolvaj, aki képes az emberek álmaiba behatolni, egy utolsó küldetést kap, amely megváltoztatja az emberiség jövőjét.", "Christopher Nolan", "Sci-Fi", 148, null, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eredet", null },
                    { 3, "Keanu Reeves", "Laurence Fishburne", "Carrie-Anne Moss", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(5856), "A hacker, Neo, felfedezi, hogy a világ, amiben él, valójában egy mesterségesen generált álom, és elindul a harc a valóság megszerzéséért.", "Lana Wachowski", "Sci-Fi", 136, null, new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mátrix", null },
                    { 4, "Marlon Brando", "Al Pacino", "James Caan", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(6099), "A Corleone család, egy olasz-amerikai maffiacsalád, és annak hatalma, politikai befolyása, valamint a családi kapcsolatok története.", "Francis Ford Coppola", "Krimi", 175, null, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "A keresztapa", null },
                    { 5, "Christian Bale", "Heath Ledger", "Aaron Eckhart", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(6341), "Batman szembesül Jokerrrel, a gonosz nevettetővel, aki a Gotham városában uralkodó káoszt szeretné elérni, miközben saját identitásának és elveinek határait is feszegeti.", "Christopher Nolan", "Akció", 152, null, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "A sötét lovag", null },
                    { 6, "John Travolta", "Uma Thurman", "Samuel L. Jackson", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(6587), "Két bérgyilkos napi kalandjait követhetjük, miközben véletlenek és szórakoztató párbeszédek révén kibontakozik egy sötét humorral teli történet.", "Quentin Tarantino", "Krimi", 154, null, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ponyvaregény", null },
                    { 7, "Mark Hamill", "Harrison Ford", "Carrie Fisher", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(6844), "Luke Skywalker és barátai a Birodalom elleni harc során igyekeznek megsemmisíteni a Halálcsillagot, miközben felfedezik saját erejüket és küldetésüket.", "George Lucas", "Sci-Fi", 121, null, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Egy új remény", null },
                    { 8, "Sigourney Weaver", "Tom Skerritt", "John Hurt", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(7090), "A Nostromo űrhajó legénysége egy ismeretlen bolygóról hozott idegen lénytől kezd el rettegni, miközben kétségbeesetten próbálnak életben maradni.", "Ridley Scott", "Sci-Fi", 117, null, new DateTime(1979, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "A nyolcadik utas: a Halál", null },
                    { 9, "Russell Crowe", "Joaquin Phoenix", "Connie Nielsen", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(7344), "Maximus, egy római katona, akit árulás miatt a császári család ellenségei elárulnak, gladiátorként próbál visszavágni a római birodalom hatalmának megdöntéséért.", "Ridley Scott", "Történelmi", 155, null, new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gladiátor", null },
                    { 10, "Tom Hanks", "Robin Wright", "Gary Sinise", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(7586), "Forrest Gump története, aki egyszerű elmebeli képességekkel rendelkezik, de életét olyan fontos történelmi események formálják, amelyekkel sokak számára inspirációt ad.", "Robert Zemeckis", "Dráma", 142, null, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump", null },
                    { 11, "Tim Robbins", "Morgan Freeman", "Bob Gunton", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(7836), "Andy Dufresne, egy bankár ártatlanul letartóztatva, élete végéig a Shawshank börtönben próbál meg túlélni, miközben megőrzi reményét és titkos tervét.", "Frank Darabont", "Dráma", 142, null, new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "A remény rabjai", null },
                    { 12, "Liam Neeson", "Ben Kingsley", "Ralph Fiennes", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(8153), "A film Schindler történetét követi, aki a második világháború alatt több mint ezer zsidó életét mentette meg, miközben sikeresen elkerülte a náci hatóságok figyelmét.", "Steven Spielberg", "Történelmi", 195, null, new DateTime(1993, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler listája", null },
                    { 13, "Leonardo DiCaprio", "Matt Damon", "Jack Nicholson", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(8383), "Billy Costigan, egy fiatal rendőr, beépül a bostoni maffiába, miközben a maffia ügyeiért dolgozó Colin Sullivan titkosszolgálati informátorként segíti a bűnözőket.", "Martin Scorsese", "Krimi", 151, null, new DateTime(2006, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A tégla", null },
                    { 14, "Jamie Foxx", "Christoph Waltz", "Leonardo DiCaprio", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(8616), "Django, egy felszabadított rabszolga, szövetséget köt egy német fejvadásszal, hogy megmentsen feleségét, és igazságot szolgáltasson egy brutális rabszolga-kereskedőnek.", "Quentin Tarantino", "Western", 165, null, new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Django elszabadul", null },
                    { 15, "Clint Eastwood", "Lee Van Cleef", "Eli Wallach", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(8853), "A film három különböző férfi keresztutjait követi, akik a vadnyugat törvényei szerint küzdenek a túlélésért, miközben egy hatalmas bűnügyi összeesküvésben vesznek részt.", "Sergio Leone", "Western", 165, null, new DateTime(1968, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "A vadnyugat hőskora", null },
                    { 16, "Leonardo DiCaprio", "Kate Winslet", "Billy Zane", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(9271), "Jack és Rose szerelmének története, akik egy tragikus sorsú hajón, a Titanic fedélzetén találkoznak és élnek át mindent, ami a sors által nekik kijut.", "James Cameron", "Romantikus", 195, null, new DateTime(1997, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titanic", null },
                    { 17, "Ryan Gosling", "Rachel McAdams", "James Garner", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(9528), "Noah és Allie szerelme, mely hosszú évek után sem halványul el, miközben két különböző világ találkozik és a szeretet mindent legyőz.", "Nick Cassavetes", "Romantikus", 123, null, new DateTime(2004, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szerelmünk lapjai", null },
                    { 18, "Bill Murray", "Dan Aykroyd", "Sigourney Weaver", new DateTime(2024, 12, 18, 9, 42, 32, 427, DateTimeKind.Local).AddTicks(9779), "Három tudós és egy szellemirtó csoport létrehozása, akik New York városában az emelkedő szellemeket és paranormális jelenségeket kezdik el üldözni.", "Ivan Reitman", "Vígjáték", 105, null, new DateTime(1984, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szellemirtók", null },
                    { 19, "John Candy", "Joe Flaherty", "Harold Ramis", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(38), "Két bűnöző, akik nemcsak az igazságszolgáltatás elől menekülnek, hanem saját szörnyű döntéseik következményeivel is küzdenek egy hatalmas vígjátékban.", "Jim Abrahams", "Vígjáték", 84, null, new DateTime(1991, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nagy durranás", null },
                    { 20, "Jim Carrey", "Courtney Cox", "Sean Young", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(295), "Ace Ventura, egy szórakoztató és zűrös állati nyomozó, aki segít visszaszerezni egy eltűnt delfint, miközben elképesztő kalandokon megy keresztül.", "Tom Shadyac", "Vígjáték", 86, null, new DateTime(1994, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ace Ventura: Állati nyomozó", null },
                    { 21, "Heather Langenkamp", "Johnny Depp", "Robert Englund", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(545), "Freddy Krueger, a szörnyű álmok gyilkosa visszatér, hogy a fiatalokat egy rémálomban elpusztítsa, miközben ők próbálják kideríteni, hogyan állíthatják meg őt.", "Wes Craven", "Horror", 91, null, new DateTime(1984, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rémálom az Elm utcában", null },
                    { 22, "Ellen Burstyn", "Max von Sydow", "Linda Blair", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(808), "A fiatal Regan MacNeil-t egy gonosz démon szállja meg, és egy pap segítségét kérik, hogy kiűzzék a démoni jelenlétet, miközben a szülők kétségbeesetten küzdenek.", "William Friedkin", "Horror", 122, null, new DateTime(1973, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Az ördögűző", null },
                    { 23, "Jamie Lee Curtis", "Donald Pleasence", "Tony Moran", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(1063), "Michael Myers, a gyilkos, aki elmenekült egy pszichiátriai intézetből, hogy folytassa az áldozatok sorozatát Halloween éjszakáján, miközben Laurie Strode próbál túlélni.", "John Carpenter", "Horror", 91, null, new DateTime(1978, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halloween", null },
                    { 24, "Betsy Palmer", "Adrienne King", "Harry Manfredini", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(1354), "A Crystal Lake kempingezői sorozatos gyilkosságokat tapasztalnak, miközben egy rejtélyes gyilkos, Jason Voorhees újra és újra támadja őket.", "Sean S. Cunningham", "Horror", 95, null, new DateTime(1980, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Péntek 13.", null },
                    { 25, "Matthew McConaughey", "Anne Hathaway", "Jessica Chastain", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(1668), "A Föld elpusztulása előtt egy csapat űrhajós a galaxisba indul, hogy egy új otthont találjon az emberiség számára, miközben mélyen elgondolkodtató kérdéseket vetnek fel az időről és a szeretetről.", "Christopher Nolan", "Sci-Fi", 169, null, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar", null },
                    { 26, "Leonardo DiCaprio", "Tom Hardy", "Domhnall Gleeson", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(1940), "Hugh Glass, egy vadász, akit egy medve súlyosan megsebesít, és úgy hagynak, hogy meghaljon, visszavág és igyekszik túlélni a vadonban, miközben bosszút esküszik az őt cserbenhagyó társai ellen.", "Alejandro G. Iñárritu", "Kaland", 156, null, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "A visszatérő", null },
                    { 27, "Elijah Wood", "Ian McKellen", "Viggo Mortensen", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(2159), "A háború végső csatája kezdődik, miközben Frodo és Sam közel járnak a Sötét Úr, Sauron megsemmisítéséhez, miközben Aragorn és a Szövetség a háborúban harcol.", "Peter Jackson", "Kaland", 201, null, new DateTime(2003, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "A gyűrűk ura: A király visszatér", null },
                    { 28, "Daniel Radcliffe", "Rupert Grint", "Emma Watson", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(2383), "Harry Potter felfedezi, hogy ő egy varázsló, és elindul a mágikus világban, miközben barátaival egy misztikus kő nyomában járnak, hogy megakadályozzák a sötét varázsló visszatérését.", "Chris Columbus", "Kaland", 152, null, new DateTime(2001, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter és a bölcsek köve", null },
                    { 29, "Harrison Ford", "Karen Allen", "Paul Freeman", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(2603), "Indiana Jones, a kalandor régész, megpróbálja megelőzni a nácikat, akik az elveszett frigyládát keresik, egy titkos ereklyét, amely hatalmas hatalommal bír.", "Steven Spielberg", "Kaland", 115, null, new DateTime(1981, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indiana Jones és az elveszett frigyláda fosztogatói", null },
                    { 30, "Russell Crowe", "Jennifer Connelly", "Ed Harris", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(2836), "John Nash, a zseniális matematikus, a skizofréniával küzd, miközben próbálja megérteni a saját elméjét, és harcol a belső démonokkal, hogy megtartsa a karrierjét és a szerelmét.", "Ron Howard", "Dráma", 135, null, new DateTime(2001, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egy csodálatos elme", null },
                    { 31, "Miles Teller", "J.K. Simmons", "Melissa Benoist", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(3113), "Andrew, egy fiatal dobos, mindent feláldoz, hogy elérje álmait, miközben egy szigorú és manipulatív tanár, Fletcher próbálja elérni, hogy a legjobbat hozza ki belőle.", "Damien Chazelle", "Dráma", 106, null, new DateTime(2014, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Whiplash", null },
                    { 32, "Harrison Ford", "Rutger Hauer", "Sean Young", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(3333), "Rick Deckard, egy szárnyas fejvadász, aki egy újabb gyilkos androidot kell, hogy levadásszon, kétségbeesetten keres egy igazságot egy világban, amelyben a gépek és az emberek közötti határok elmosódnak.", "Ridley Scott", "Sci-Fi", 117, null, new DateTime(1982, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szárnyas fejvadász", null },
                    { 33, "Edward Norton", "Liv Tyler", "Tim Roth", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(3551), "Bruce Banner, aki tudatosan próbálja megállítani a szörnyű szörnyeteg Hulkot, miután egy kísérlet következtében folyamatosan mutálódik, miközben el akarja kerülni, hogy a katonai hatalom elfogja őt.", "Louis Leterrier", "Akció", 112, null, new DateTime(2008, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "A hihetetlen Hulk", null },
                    { 34, "Mike Myers", "Beyoncé Knowles", "Vernon Troyer", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(3801), "Austin Powers, a híres brit titkos ügynök, visszatér, hogy megakadályozza a gonosz Dr. Evil tervét, miközben a nevetés határain túl is szórakoztatja a közönséget.", "Jay Roach", "Vígjáték", 95, null, new DateTime(1999, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "KicsiKÉM – Austin Powers 2.", null },
                    { 35, "Johnny Depp", "Armie Hammer", "Tom Wilkinson", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(4019), "A vadnyugat határain túl egy különös kettős kapcsolat alakul ki: a titokzatos Lone Ranger és Tonto, az indián kísérője, hogy felvegyék a harcot a korrupt erőkkel.", "Gore Verbinski", "Western", 149, null, new DateTime(2013, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "A magányos lovas", null },
                    { 36, "Chadwick Boseman", "Michael B. Jordan", "Lupita Nyong'o", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(4391), "T'Challa, Wakanda királya és új Fekete Párduc, szembesül egy nagy hatalmú ellenséggel, aki megpróbálja felfedni országát és kihasználni annak gazdagságát.", "Ryan Coogler", "Akció", 134, null, new DateTime(2018, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fekete Párduc", null },
                    { 37, "Ryan Reynolds", "Morena Baccarin", "T.J. Miller", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(4634), "Wade Wilson, egy egykori különleges erőket végző katona, akit kísérletezéssel alakítanak át, hogy megszerezze gyógyító képességét, és harcba száll a bűnözőkkel.", "Tim Miller", "Akció", 108, null, new DateTime(2016, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deadpool", null },
                    { 38, "Hugh Jackman", "Patrick Stewart", "Dafne Keen", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(4864), "Logan, az öreg és beteg X-Men tag, segít egy fiatal mutantot elmenekülni, miközben harcol saját szellemi és fizikai határain túl.", "James Mangold", "Akció", 137, null, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Logan", null },
                    { 39, "Ben Affleck", "Henry Cavill", "Gal Gadot", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(5168), "Batman és Superman összecsapása, miközben mindketten próbálják megérteni, miért kell harcolniuk, miközben a világot egy új fenyegetés is veszélyezteti.", "Zack Snyder", "Akció", 151, null, new DateTime(2016, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman v Superman: Az igazság hajnal", null },
                    { 40, "Ryan Reynolds", "Josh Brolin", "Zazie Beetz", new DateTime(2024, 12, 18, 9, 42, 32, 428, DateTimeKind.Local).AddTicks(5517), "Deadpool visszatér, hogy egy új csapatot toborozzon, miközben harcol a világot fenyegető gonosz erőkkel, és megpróbálja felfedezni saját személyiségét.", "David Leitch", "Akció", 119, null, new DateTime(2018, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deadpool 2", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "user-role-id", "user1" },
                    { "user-role-id", "user10" },
                    { "user-role-id", "user11" },
                    { "user-role-id", "user12" },
                    { "user-role-id", "user13" },
                    { "user-role-id", "user14" },
                    { "user-role-id", "user15" },
                    { "user-role-id", "user16" },
                    { "user-role-id", "user17" },
                    { "user-role-id", "user18" },
                    { "user-role-id", "user19" },
                    { "user-role-id", "user2" },
                    { "user-role-id", "user20" },
                    { "user-role-id", "user21" },
                    { "user-role-id", "user22" },
                    { "user-role-id", "user23" },
                    { "user-role-id", "user24" },
                    { "user-role-id", "user25" },
                    { "user-role-id", "user3" },
                    { "user-role-id", "user4" },
                    { "user-role-id", "user5" },
                    { "user-role-id", "user6" },
                    { "user-role-id", "user7" },
                    { "user-role-id", "user8" },
                    { "user-role-id", "user9" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Comment", "MovieId", "RatingNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "Valóban mestermű, mindenkinek ajánlom!", 1, 4, "user22" },
                    { 2, "Kicsit lassú volt a tempó, de összességében jó.", 1, 1, "user24" },
                    { 3, "A karakterek nagyon jól kidolgozottak.", 1, 1, "user9" },
                    { 4, "A karakterek nagyon jól kidolgozottak.", 1, 4, "user5" },
                    { 5, "Hihetetlen történet, teljesen magával ragadott!", 2, 5, "user9" },
                    { 6, "Hihetetlen történet, teljesen magával ragadott!", 2, 2, "user17" },
                    { 7, "Valóban mestermű, mindenkinek ajánlom!", 2, 5, "user22" },
                    { 8, "Nem igazán az én ízlésem, de értem miért szeretik.", 2, 1, "user16" },
                    { 9, "Lenyűgöző látványvilág és remek színészi játék!", 3, 2, "user10" },
                    { 10, "Nagyszerű film, nagyon élveztem!", 3, 1, "user22" },
                    { 11, "Lenyűgöző látványvilág és remek színészi játék!", 3, 3, "user3" },
                    { 12, "Sokkal jobb, mint amire számítottam.", 3, 4, "user14" },
                    { 13, "A karakterek nagyon jól kidolgozottak.", 4, 1, "user4" },
                    { 14, "Sokkal jobb, mint amire számítottam.", 4, 5, "user22" },
                    { 15, "Hihetetlen történet, teljesen magával ragadott!", 4, 5, "user19" },
                    { 16, "Hihetetlen történet, teljesen magával ragadott!", 4, 5, "user23" },
                    { 17, "Egyszerűen fantasztikus, nem tudom eléggé dicsérni!", 5, 3, "user24" },
                    { 18, "Kissé kiszámítható, de azért szórakoztató.", 5, 4, "user2" },
                    { 19, "Nagyszerű film, nagyon élveztem!", 5, 2, "user14" },
                    { 20, "Hihetetlen történet, teljesen magával ragadott!", 5, 5, "user5" },
                    { 21, "Nagyszerű film, nagyon élveztem!", 6, 2, "user16" },
                    { 22, "A karakterek nagyon jól kidolgozottak.", 6, 1, "user3" },
                    { 23, "Kissé kiszámítható, de azért szórakoztató.", 6, 2, "user5" },
                    { 24, "Hihetetlen történet, teljesen magával ragadott!", 6, 4, "user18" },
                    { 25, "Hihetetlen történet, teljesen magával ragadott!", 7, 3, "user2" },
                    { 26, "Nagyszerű film, nagyon élveztem!", 7, 5, "user21" },
                    { 27, "A karakterek nagyon jól kidolgozottak.", 7, 3, "user23" },
                    { 28, "Nagyszerű film, nagyon élveztem!", 7, 1, "user16" },
                    { 29, "Valóban mestermű, mindenkinek ajánlom!", 8, 2, "user13" },
                    { 30, "Kissé kiszámítható, de azért szórakoztató.", 8, 4, "user19" },
                    { 31, "Nagyszerű film, nagyon élveztem!", 8, 3, "user11" },
                    { 32, "Hihetetlen történet, teljesen magával ragadott!", 8, 2, "user17" },
                    { 33, "Lenyűgöző látványvilág és remek színészi játék!", 9, 3, "user8" },
                    { 34, "A karakterek nagyon jól kidolgozottak.", 9, 1, "user20" },
                    { 35, "Egyszerűen fantasztikus, nem tudom eléggé dicsérni!", 9, 4, "user24" },
                    { 36, "Nagyszerű film, nagyon élveztem!", 9, 1, "user9" },
                    { 37, "Hihetetlen történet, teljesen magával ragadott!", 10, 5, "user19" },
                    { 38, "A karakterek nagyon jól kidolgozottak.", 10, 4, "user5" },
                    { 39, "Kicsit lassú volt a tempó, de összességében jó.", 10, 3, "user21" },
                    { 40, "Hihetetlen történet, teljesen magával ragadott!", 10, 5, "user16" },
                    { 41, "Hihetetlen történet, teljesen magával ragadott!", 11, 2, "user3" },
                    { 42, "Valóban mestermű, mindenkinek ajánlom!", 11, 1, "user22" },
                    { 43, "Hihetetlen történet, teljesen magával ragadott!", 11, 5, "user20" },
                    { 44, "Valóban mestermű, mindenkinek ajánlom!", 11, 3, "user17" },
                    { 45, "Nem igazán az én ízlésem, de értem miért szeretik.", 12, 5, "user7" },
                    { 46, "Nagyszerű film, nagyon élveztem!", 12, 5, "user20" },
                    { 47, "Nagyszerű film, nagyon élveztem!", 12, 4, "user6" },
                    { 48, "Kicsit lassú volt a tempó, de összességében jó.", 12, 2, "user23" },
                    { 49, "Kissé kiszámítható, de azért szórakoztató.", 13, 3, "user8" },
                    { 50, "A karakterek nagyon jól kidolgozottak.", 13, 5, "user23" },
                    { 51, "Lenyűgöző látványvilág és remek színészi játék!", 13, 2, "user5" },
                    { 52, "Valóban mestermű, mindenkinek ajánlom!", 13, 2, "user13" },
                    { 53, "Kicsit lassú volt a tempó, de összességében jó.", 14, 2, "user7" },
                    { 54, "Nem igazán az én ízlésem, de értem miért szeretik.", 14, 3, "user15" },
                    { 55, "Valóban mestermű, mindenkinek ajánlom!", 14, 4, "user12" },
                    { 56, "Kissé kiszámítható, de azért szórakoztató.", 14, 1, "user18" },
                    { 57, "Lenyűgöző látványvilág és remek színészi játék!", 15, 4, "user11" },
                    { 58, "Lenyűgöző látványvilág és remek színészi játék!", 15, 4, "user4" },
                    { 59, "Nem igazán az én ízlésem, de értem miért szeretik.", 15, 2, "user3" },
                    { 60, "Valóban mestermű, mindenkinek ajánlom!", 15, 4, "user22" },
                    { 61, "Nagyszerű film, nagyon élveztem!", 16, 1, "user5" },
                    { 62, "A karakterek nagyon jól kidolgozottak.", 16, 2, "user10" },
                    { 63, "Lenyűgöző látványvilág és remek színészi játék!", 16, 2, "user17" },
                    { 64, "Valóban mestermű, mindenkinek ajánlom!", 16, 2, "user1" },
                    { 65, "Sokkal jobb, mint amire számítottam.", 17, 3, "user23" },
                    { 66, "Sokkal jobb, mint amire számítottam.", 17, 4, "user20" },
                    { 67, "A karakterek nagyon jól kidolgozottak.", 17, 3, "user16" },
                    { 68, "Nagyszerű film, nagyon élveztem!", 17, 1, "user21" },
                    { 69, "Nem igazán az én ízlésem, de értem miért szeretik.", 18, 1, "user5" },
                    { 70, "Nagyszerű film, nagyon élveztem!", 18, 3, "user23" },
                    { 71, "Nem igazán az én ízlésem, de értem miért szeretik.", 18, 4, "user9" },
                    { 72, "Valóban mestermű, mindenkinek ajánlom!", 18, 1, "user13" },
                    { 73, "Sokkal jobb, mint amire számítottam.", 19, 3, "user10" },
                    { 74, "Egyszerűen fantasztikus, nem tudom eléggé dicsérni!", 19, 2, "user20" },
                    { 75, "Kissé kiszámítható, de azért szórakoztató.", 19, 2, "user18" },
                    { 76, "Kissé kiszámítható, de azért szórakoztató.", 19, 3, "user4" },
                    { 77, "A karakterek nagyon jól kidolgozottak.", 20, 3, "user1" },
                    { 78, "Valóban mestermű, mindenkinek ajánlom!", 20, 4, "user25" },
                    { 79, "Kissé kiszámítható, de azért szórakoztató.", 20, 3, "user14" },
                    { 80, "Nem igazán az én ízlésem, de értem miért szeretik.", 20, 5, "user22" },
                    { 81, "Valóban mestermű, mindenkinek ajánlom!", 21, 2, "user4" },
                    { 82, "Sokkal jobb, mint amire számítottam.", 21, 1, "user22" },
                    { 83, "A karakterek nagyon jól kidolgozottak.", 21, 2, "user23" },
                    { 84, "Kicsit lassú volt a tempó, de összességében jó.", 21, 5, "user6" },
                    { 85, "Nem igazán az én ízlésem, de értem miért szeretik.", 22, 3, "user20" },
                    { 86, "Valóban mestermű, mindenkinek ajánlom!", 22, 1, "user24" },
                    { 87, "Egyszerűen fantasztikus, nem tudom eléggé dicsérni!", 22, 4, "user9" },
                    { 88, "Lenyűgöző látványvilág és remek színészi játék!", 22, 3, "user14" },
                    { 89, "Kicsit lassú volt a tempó, de összességében jó.", 23, 5, "user4" },
                    { 90, "Nagyszerű film, nagyon élveztem!", 23, 5, "user16" },
                    { 91, "A karakterek nagyon jól kidolgozottak.", 23, 5, "user15" },
                    { 92, "Kicsit lassú volt a tempó, de összességében jó.", 23, 3, "user1" },
                    { 93, "Kissé kiszámítható, de azért szórakoztató.", 24, 5, "user13" },
                    { 94, "A karakterek nagyon jól kidolgozottak.", 24, 2, "user5" },
                    { 95, "Nagyszerű film, nagyon élveztem!", 24, 1, "user23" },
                    { 96, "Nem igazán az én ízlésem, de értem miért szeretik.", 24, 5, "user4" },
                    { 97, "A karakterek nagyon jól kidolgozottak.", 25, 3, "user4" },
                    { 98, "Hihetetlen történet, teljesen magával ragadott!", 25, 5, "user1" },
                    { 99, "Hihetetlen történet, teljesen magával ragadott!", 25, 2, "user25" },
                    { 100, "Kissé kiszámítható, de azért szórakoztató.", 25, 4, "user9" },
                    { 101, "Kissé kiszámítható, de azért szórakoztató.", 26, 5, "user20" },
                    { 102, "Nem igazán az én ízlésem, de értem miért szeretik.", 26, 4, "user25" },
                    { 103, "Hihetetlen történet, teljesen magával ragadott!", 26, 4, "user19" },
                    { 104, "Hihetetlen történet, teljesen magával ragadott!", 26, 5, "user11" },
                    { 105, "Nagyszerű film, nagyon élveztem!", 27, 2, "user20" },
                    { 106, "Kicsit lassú volt a tempó, de összességében jó.", 27, 3, "user10" },
                    { 107, "Sokkal jobb, mint amire számítottam.", 27, 3, "user21" },
                    { 108, "Nagyszerű film, nagyon élveztem!", 27, 2, "user6" },
                    { 109, "Lenyűgöző látványvilág és remek színészi játék!", 28, 5, "user1" },
                    { 110, "Sokkal jobb, mint amire számítottam.", 28, 5, "user17" },
                    { 111, "Sokkal jobb, mint amire számítottam.", 28, 2, "user11" },
                    { 112, "A karakterek nagyon jól kidolgozottak.", 28, 4, "user20" },
                    { 113, "Kissé kiszámítható, de azért szórakoztató.", 29, 2, "user8" },
                    { 114, "Egyszerűen fantasztikus, nem tudom eléggé dicsérni!", 29, 2, "user16" },
                    { 115, "Sokkal jobb, mint amire számítottam.", 29, 2, "user6" },
                    { 116, "Sokkal jobb, mint amire számítottam.", 29, 1, "user13" },
                    { 117, "Kissé kiszámítható, de azért szórakoztató.", 30, 3, "user1" },
                    { 118, "Valóban mestermű, mindenkinek ajánlom!", 30, 4, "user10" },
                    { 119, "Egyszerűen fantasztikus, nem tudom eléggé dicsérni!", 30, 1, "user7" },
                    { 120, "A karakterek nagyon jól kidolgozottak.", 30, 2, "user21" },
                    { 121, "A karakterek nagyon jól kidolgozottak.", 31, 5, "user23" },
                    { 122, "Lenyűgöző látványvilág és remek színészi játék!", 31, 4, "user25" },
                    { 123, "Sokkal jobb, mint amire számítottam.", 31, 1, "user17" },
                    { 124, "Valóban mestermű, mindenkinek ajánlom!", 31, 1, "user15" },
                    { 125, "Kicsit lassú volt a tempó, de összességében jó.", 32, 4, "user15" },
                    { 126, "Lenyűgöző látványvilág és remek színészi játék!", 32, 5, "user11" },
                    { 127, "Kissé kiszámítható, de azért szórakoztató.", 32, 2, "user21" },
                    { 128, "Kissé kiszámítható, de azért szórakoztató.", 32, 3, "user3" },
                    { 129, "Kicsit lassú volt a tempó, de összességében jó.", 33, 5, "user1" },
                    { 130, "Hihetetlen történet, teljesen magával ragadott!", 33, 2, "user3" },
                    { 131, "Hihetetlen történet, teljesen magával ragadott!", 33, 1, "user12" },
                    { 132, "Nagyszerű film, nagyon élveztem!", 33, 1, "user14" },
                    { 133, "Sokkal jobb, mint amire számítottam.", 34, 3, "user12" },
                    { 134, "Kissé kiszámítható, de azért szórakoztató.", 34, 4, "user19" },
                    { 135, "Hihetetlen történet, teljesen magával ragadott!", 34, 1, "user6" },
                    { 136, "Nem igazán az én ízlésem, de értem miért szeretik.", 34, 5, "user11" },
                    { 137, "Kissé kiszámítható, de azért szórakoztató.", 35, 1, "user12" },
                    { 138, "A karakterek nagyon jól kidolgozottak.", 35, 3, "user4" },
                    { 139, "Nagyszerű film, nagyon élveztem!", 35, 3, "user2" },
                    { 140, "A karakterek nagyon jól kidolgozottak.", 35, 4, "user19" },
                    { 141, "Nem igazán az én ízlésem, de értem miért szeretik.", 36, 2, "user9" },
                    { 142, "Lenyűgöző látványvilág és remek színészi játék!", 36, 5, "user13" },
                    { 143, "Egyszerűen fantasztikus, nem tudom eléggé dicsérni!", 36, 3, "user4" },
                    { 144, "Egyszerűen fantasztikus, nem tudom eléggé dicsérni!", 36, 1, "user20" },
                    { 145, "Nagyszerű film, nagyon élveztem!", 37, 2, "user4" },
                    { 146, "Hihetetlen történet, teljesen magával ragadott!", 37, 4, "user17" },
                    { 147, "Hihetetlen történet, teljesen magával ragadott!", 37, 5, "user13" },
                    { 148, "Kissé kiszámítható, de azért szórakoztató.", 37, 4, "user5" },
                    { 149, "Kissé kiszámítható, de azért szórakoztató.", 38, 1, "user8" },
                    { 150, "Lenyűgöző látványvilág és remek színészi játék!", 38, 5, "user2" },
                    { 151, "Egyszerűen fantasztikus, nem tudom eléggé dicsérni!", 38, 5, "user20" },
                    { 152, "Nagyszerű film, nagyon élveztem!", 38, 1, "user22" },
                    { 153, "Egyszerűen fantasztikus, nem tudom eléggé dicsérni!", 39, 4, "user9" },
                    { 154, "Hihetetlen történet, teljesen magával ragadott!", 39, 3, "user14" },
                    { 155, "Hihetetlen történet, teljesen magával ragadott!", 39, 1, "user23" },
                    { 156, "A karakterek nagyon jól kidolgozottak.", 39, 1, "user10" },
                    { 157, "Egyszerűen fantasztikus, nem tudom eléggé dicsérni!", 40, 5, "user3" },
                    { 158, "Nem igazán az én ízlésem, de értem miért szeretik.", 40, 4, "user23" },
                    { 159, "Kicsit lassú volt a tempó, de összességében jó.", 40, 3, "user14" },
                    { 160, "A karakterek nagyon jól kidolgozottak.", 40, 5, "user18" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_WatchlistId",
                table: "Movies",
                column: "WatchlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_MovieId",
                table: "Watchlists",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_UserId",
                table: "Watchlists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Watchlists_WatchlistId",
                table: "Movies",
                column: "WatchlistId",
                principalTable: "Watchlists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watchlists_AspNetUsers_UserId",
                table: "Watchlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Watchlists_WatchlistId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "List<string>");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Watchlists");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
