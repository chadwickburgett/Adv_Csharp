using Microsoft.EntityFrameworkCore.Migrations;

namespace dataTranferBurgett.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: "Cn",
                column: "FlagImage",
                value: "canada.jfif");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: "Mx",
                column: "FlagImage",
                value: "mexico.jfif");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: "Cn",
                column: "FlagImage",
                value: "canada.jpg");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: "Mx",
                column: "FlagImage",
                value: "Mexico.jfif");
        }
    }
}
