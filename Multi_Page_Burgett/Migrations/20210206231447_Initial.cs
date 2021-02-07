using Microsoft.EntityFrameworkCore.Migrations;

namespace Multi_Page_Burgett.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactsId);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactsId", "Address", "Name", "Note", "Phone" },
                values: new object[] { 1, "123 Main Street, Anytown USA", "Ben Gates", "I met Ben while he was looking for a treasure map on the back of the Declaration of Independance.", "123-456-7891" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactsId", "Address", "Name", "Note", "Phone" },
                values: new object[] { 2, "Bag End, Bagshot Row, Hobbbiton, Shire ", "Frodo Baggins", "I met Frodo when he joined a fellowship to destrow a powerful ring", "None" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactsId", "Address", "Name", "Note", "Phone" },
                values: new object[] { 3, "111 Myhouse Road, Des Moines Ia.", "Angie Burgett", "Angie is my wife, I met her 22 years ago at a local coffee shop. She is truly my better half.", "515-555-5555" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
