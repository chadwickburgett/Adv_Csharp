using Microsoft.EntityFrameworkCore.Migrations;

namespace ticketingSystemBurgett.Migrations
{
    public partial class DBAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: "done");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: "inprogress");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: "qa");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: "todo");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Ticketing",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Ticketing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId1",
                table: "Ticketing",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Statuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ticketing_Categories_CategoryId1",
                table: "Ticketing",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticketing_Categories_CategoryId1",
                table: "Ticketing");

            migrationBuilder.DropIndex(
                name: "IX_Ticketing_CategoryId1",
                table: "Ticketing");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ticketing",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ticketing",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ticketing",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Ticketing");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Ticketing");

            migrationBuilder.AlterColumn<string>(
                name: "StatusId",
                table: "Ticketing",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "StatusId",
                table: "Statuses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { "todo", "To Do" },
                    { "inprogress", "In Progress" },
                    { "qa", "Quality Assurance" },
                    { "done", "Done" }
                });
        }
    }
}
