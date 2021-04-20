using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cremeCoffeeBurgett.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Origins",
                columns: table => new
                {
                    OriginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Process = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origins", x => x.OriginId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Beans",
                columns: table => new
                {
                    BeanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CountryId = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beans", x => x.BeanId);
                    table.ForeignKey(
                        name: "FK_Beans_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeanOrigins",
                columns: table => new
                {
                    BeanId = table.Column<int>(type: "int", nullable: false),
                    OriginId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeanOrigins", x => new { x.BeanId, x.OriginId });
                    table.ForeignKey(
                        name: "FK_BeanOrigins_Beans_BeanId",
                        column: x => x.BeanId,
                        principalTable: "Beans",
                        principalColumn: "BeanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeanOrigins_Origins_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origins",
                        principalColumn: "OriginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { "blend", "Blend" },
                    { "tanzania", "Tanzania" },
                    { "indonesia", "Indonesia" },
                    { "peru", "Peru" },
                    { "papua new guinea", "Papua New Guinea" },
                    { "mexico", "Mexico" },
                    { "kenya", "Kenya" },
                    { "honduras", "Honduras" },
                    { "rwanda", "Rwanda" },
                    { "guatemala", "Guatemala" },
                    { "ethiopa", "Ethiopa" },
                    { "costa rica", "Costa Rica" },
                    { "columbia", "Columbia" },
                    { "burundi", "Burundi" },
                    { "brazil", "Brazil" },
                    { "usa", "USA" }
                });

            migrationBuilder.InsertData(
                table: "Origins",
                columns: new[] { "OriginId", "Name", "Process" },
                values: new object[,]
                {
                    { 15, "USA", "Natural" },
                    { 16, "Honduras", "Washed" },
                    { 17, "Kenya", "Honey" },
                    { 18, "Mexico", "Washed" },
                    { 22, "Rwanda", "Washed" },
                    { 20, "Peru", "Washed" },
                    { 21, "Rwanda", "Honey" },
                    { 23, "Indonesia", "Washed" },
                    { 14, "Guatemala", "Natural" },
                    { 19, "Papua New Guinea", "Natural" },
                    { 13, "Guatemala", "Honey" },
                    { 5, "Blend", "Natural" },
                    { 11, "Ethiopia", "Washed" },
                    { 10, "Ethiopia", "Honey" },
                    { 9, "Costa Rica", "Honey" },
                    { 8, "Columbia", "Natural" },
                    { 7, "Columbia", "Washed" },
                    { 6, "Blend", "Washed" },
                    { 25, "Indonesia", "Honey" },
                    { 4, "Burundi", "Honey" },
                    { 3, "Burundi", "Natural" },
                    { 2, "Brazil", "Washed" },
                    { 1, "Brazil", "Honey" },
                    { 12, "Ethiopia", "Natural" },
                    { 26, "Tanzania", "Natural" }
                });

            migrationBuilder.InsertData(
                table: "Beans",
                columns: new[] { "BeanId", "CountryId", "Name", "Price" },
                values: new object[,]
                {
                    { 3, "blend", "Cold Brew Blend", 16.5 },
                    { 25, "indonesia", "Sulawesi", 19.5 },
                    { 23, "rwanda", "Rwanda", 19.989999999999998 },
                    { 21, "peru", "Peru", 18.5 },
                    { 20, "papua new guinea", "Papua New Guinea", 19.75 },
                    { 19, "mexico", "Mexico Chiapas", 19.989999999999998 },
                    { 18, "mexico", "Mexico", 18.5 },
                    { 17, "kenya", "Kenya", 19.75 },
                    { 15, "honduras", "Honduras", 18.5 },
                    { 14, "usa", "Hawaii Kona", 35.25 },
                    { 13, "guatemala", "Guatemala", 18.5 },
                    { 11, "ethiopa", "Ethiopa", 19.75 },
                    { 9, "costa rica", "Decaf Cost Rica", 17.989999999999998 },
                    { 26, "indonesia", "Sumatra", 19.0 },
                    { 5, "costa rica", "Costa Rica", 17.989999999999998 },
                    { 4, "columbia", "Columbia", 17.5 },
                    { 2, "burundi", "Burundi", 19.5 },
                    { 1, "brazil", "Brazil", 18.0 },
                    { 29, "blend", "Whiskey Barrel Aged Blend", 26.75 },
                    { 28, "blend", "Traders Blend", 16.75 },
                    { 24, "blend", "Sunshine Blend", 16.75 },
                    { 22, "blend", "Rise and Shine Blend", 16.5 },
                    { 16, "blend", "Italian Roast", 16.5 },
                    { 12, "blend", "French Roast", 17.0 },
                    { 10, "blend", "Decaf Daylight Blend", 18.25 },
                    { 7, "blend", "Daylight Blend", 18.25 },
                    { 6, "blend", "Crimson Tide Blend", 16.5 },
                    { 8, "columbia", "Decaf Columbia", 17.5 },
                    { 27, "tanzania", "Tanzania", 21.0 }
                });

            migrationBuilder.InsertData(
                table: "BeanOrigins",
                columns: new[] { "BeanId", "OriginId" },
                values: new object[,]
                {
                    { 3, 5 },
                    { 25, 25 },
                    { 23, 21 },
                    { 21, 20 },
                    { 20, 19 },
                    { 19, 18 },
                    { 18, 18 },
                    { 17, 17 },
                    { 15, 16 },
                    { 14, 15 },
                    { 13, 13 },
                    { 11, 10 },
                    { 9, 9 },
                    { 26, 23 },
                    { 5, 9 },
                    { 4, 7 },
                    { 2, 4 },
                    { 1, 1 },
                    { 29, 6 },
                    { 28, 5 },
                    { 24, 6 },
                    { 22, 6 },
                    { 16, 5 },
                    { 12, 5 },
                    { 10, 6 },
                    { 7, 5 },
                    { 6, 6 },
                    { 8, 7 },
                    { 27, 26 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BeanOrigins_OriginId",
                table: "BeanOrigins",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Beans_CountryId",
                table: "Beans",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "BeanOrigins");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Beans");

            migrationBuilder.DropTable(
                name: "Origins");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
