using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodosBackend.Migrations
{
    public partial class inittodos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iscomplete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "todos",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Nhiem Vu 1" });

            migrationBuilder.InsertData(
                table: "todos",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Nhiem Vu 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todos");
        }
    }
}
