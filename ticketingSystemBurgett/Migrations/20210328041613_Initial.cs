using Microsoft.EntityFrameworkCore.Migrations;

namespace ticketingSystemBurgett.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Ticketing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SprintNumber = table.Column<int>(type: "int", nullable: false),
                    PointValue = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticketing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticketing_Categories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticketing_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { 1, "To Do" },
                    { 2, "In Progress" },
                    { 3, "Quality Assurance" },
                    { 4, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Ticketing",
                columns: new[] { "Id", "CategoryId", "CategoryId1", "Description", "Name", "PointValue", "SprintNumber", "StatusId" },
                values: new object[] { 1, 0, null, "Convert feet to inches", "feetToInches", 5, 2, 1 });

            migrationBuilder.InsertData(
                table: "Ticketing",
                columns: new[] { "Id", "CategoryId", "CategoryId1", "Description", "Name", "PointValue", "SprintNumber", "StatusId" },
                values: new object[] { 2, 0, null, "Convert inches to feet", "inchesToFeet", 15, 6, 1 });

            migrationBuilder.InsertData(
                table: "Ticketing",
                columns: new[] { "Id", "CategoryId", "CategoryId1", "Description", "Name", "PointValue", "SprintNumber", "StatusId" },
                values: new object[] { 3, 0, null, "Convert inches to meters", "inchesToMeters", 10, 4, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Ticketing_CategoryId1",
                table: "Ticketing",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ticketing_StatusId",
                table: "Ticketing",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticketing");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
