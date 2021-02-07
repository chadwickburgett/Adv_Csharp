using Microsoft.EntityFrameworkCore.Migrations;

namespace Multi_Page_Burgett.Migrations
{
    public partial class Contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: "Other",
                column: "Name",
                value: "Other");

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "DesignationId", "Name" },
                values: new object[] { "Hobbit", "Hobbit" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 2,
                columns: new[] { "DesignationId", "Note" },
                values: new object[] { "Hobbit", "I met Frodo when he joined a fellowship to destroy a powerful ring" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: "Hobbit");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactsId",
                keyValue: 2,
                columns: new[] { "DesignationId", "Note" },
                values: new object[] { "Other", "I met Frodo when he joined a fellowship to destrow a powerful ring" });

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: "Other",
                column: "Name",
                value: "");
        }
    }
}
