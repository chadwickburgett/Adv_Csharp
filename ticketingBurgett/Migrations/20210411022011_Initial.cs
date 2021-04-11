using Microsoft.EntityFrameworkCore.Migrations;

namespace ticketingBurgett.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MilitaryTime = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    sprint = table.Column<int>(type: "int", nullable: false),
                    pointValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "DayId", "Name" },
                values: new object[,]
                {
                    { 1, "Monday" },
                    { 2, "Tuesday" },
                    { 3, "Wednesday" },
                    { 4, "Thursday" },
                    { 5, "Friday" },
                    { 6, "Saturday" },
                    { 7, "Sunday" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { 1, "to do" },
                    { 2, "in progress" },
                    { 3, "quality assurance" },
                    { 4, "done" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "DayId", "Description", "MilitaryTime", "Name", "StatusId", "pointValue", "sprint" },
                values: new object[] { 1, 1, "Convert feet to inches", "1500", "feetToInches", 1, 5, 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "DayId", "Description", "MilitaryTime", "Name", "StatusId", "pointValue", "sprint" },
                values: new object[] { 2, 1, "Convert inches to feet", "1500", "inchesToFeet", 1, 15, 6 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "DayId", "Description", "MilitaryTime", "Name", "StatusId", "pointValue", "sprint" },
                values: new object[] { 3, 1, "Convert inches to meters", "1500", "inchesToMeters", 1, 10, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DayId",
                table: "Tickets",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
