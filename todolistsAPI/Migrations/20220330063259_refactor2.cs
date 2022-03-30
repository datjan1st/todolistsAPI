using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todolistsAPI.Migrations
{
    public partial class refactor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "TodoList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "TodoList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
