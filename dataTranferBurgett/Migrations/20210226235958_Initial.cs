using Microsoft.EntityFrameworkCore.Migrations;

namespace dataTranferBurgett.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    SportID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.SportID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SportID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Country_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_Sport_SportID",
                        column: x => x.SportID,
                        principalTable: "Sport",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { "in", "Indoor" },
                    { "out", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "GameID", "Name" },
                values: new object[,]
                {
                    { "winter", "Winter Olympics" },
                    { "summer", "Summer Olympics" },
                    { "para", "Paralympics" },
                    { "youth", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Sport",
                columns: new[] { "SportID", "Name" },
                values: new object[,]
                {
                    { "Curl", "Curling" },
                    { "Bob", "Bobsleigh" },
                    { "Dive", "Diving" },
                    { "RC", "Road Cycling" },
                    { "Arch", "Archery" },
                    { "CS", "Canoe Sprint" },
                    { "Break", "Breakdancing" },
                    { "Skate", "Skateboarding" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "CategoryId", "FlagImage", "GameID", "Name", "SportID" },
                values: new object[,]
                {
                    { "Cn", "in", "canada.jpg", "winter", "Canada", "Curl" },
                    { "Fl", "out", "Finland.jfif", "youth", "Finland", "Skate" },
                    { "Rs", "in", "Russia.jfif", "youth", "Russia", "Break" },
                    { "Cy", "in", "Cyprus.jfif", "youth", "Cyprus", "Break" },
                    { "Fc", "in", "France.jfif", "youth", "France", "Break" },
                    { "Zm", "out", "Zimbabwe.jfif", "para", "Zimbabwe", "CS" },
                    { "Pk", "out", "Pakistan.jfif", "para", "Pakistan", "CS" },
                    { "Au", "out", "Austria.jfif", "para", "Austria", "CS" },
                    { "Uk", "in", "Ukraine.jfif", "para", "Ukraine", "Arch" },
                    { "Ug", "in", "uruguay.jfif", "para", "Uruguay", "Arch" },
                    { "Tl", "in", "thailand.jfif", "para", "Thailand", "Arch" },
                    { "US", "out", "USA.jfif", "summer", "USA", "RC" },
                    { "Nl", "out", "netherlands.jfif", "summer", "Netherlands", "RC" },
                    { "Bz", "out", "brazil.jfif", "summer", "Brazil", "RC" },
                    { "Mx", "in", "Mexico.jfif", "summer", "Mexico", "Dive" },
                    { "Ch", "in", "china.jfif", "summer", "China", "Dive" },
                    { "Gm", "in", "germany.jfif", "summer", "Germany", "Dive" },
                    { "Jp", "out", "japan.jfif", "winter", "Japan", "Bob" },
                    { "It", "out", "italy.jfif", "winter", "Italy", "Bob" },
                    { "Jm", "out", "jamaica.jfif", "winter", "Jamaica", "Bob" },
                    { "GB", "in", "great_britain.jfif", "winter", "Great Britain", "Curl" },
                    { "Sw", "in", "sweden.jfif", "winter", "Sweden", "Curl" },
                    { "Sv", "out", "Slovakia.jfif", "youth", "Slovakia", "Skate" },
                    { "Pg", "out", "Portugal.jfif", "youth", "Portugal", "Skate" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_CategoryId",
                table: "Country",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_GameID",
                table: "Country",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_SportID",
                table: "Country",
                column: "SportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Sport");
        }
    }
}
