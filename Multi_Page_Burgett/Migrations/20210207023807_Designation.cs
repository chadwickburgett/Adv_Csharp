using Microsoft.EntityFrameworkCore.Migrations;

namespace Multi_Page_Burgett.Migrations
{
    public partial class Designation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DesignationId",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesignationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesignationId);
                });

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "DesignationId", "Name" },
                values: new object[,]
                {
                    { "Mr.", "Mister" },
                    { "Ms.", "Miss" },
                    { "Mrs.", "Misses" },
                    { "Other", "" }
                });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 1,
                column: "DesignationId",
                value: "Mr.");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 2,
                column: "DesignationId",
                value: "Other");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 3,
                column: "DesignationId",
                value: "Mrs.");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_DesignationId",
                table: "Contacts",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Designations_DesignationId",
                table: "Contacts",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "DesignationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Designations_DesignationId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_DesignationId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "Contacts");
        }
    }
}
