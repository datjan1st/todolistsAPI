using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todolistsAPI.Migrations
{
    public partial class refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTodoList_category_CategoriesCategoryId",
                table: "CategoryTodoList");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTodoList_TodoList_TodoListnumber",
                table: "CategoryTodoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "TodoList",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "TodoListnumber",
                table: "CategoryTodoList",
                newName: "TodoListsNumber");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTodoList_TodoListnumber",
                table: "CategoryTodoList",
                newName: "IX_CategoryTodoList_TodoListsNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTodoList_Category_CategoriesCategoryId",
                table: "CategoryTodoList",
                column: "CategoriesCategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTodoList_TodoList_TodoListsNumber",
                table: "CategoryTodoList",
                column: "TodoListsNumber",
                principalTable: "TodoList",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTodoList_Category_CategoriesCategoryId",
                table: "CategoryTodoList");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTodoList_TodoList_TodoListsNumber",
                table: "CategoryTodoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "TodoList",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "TodoListsNumber",
                table: "CategoryTodoList",
                newName: "TodoListnumber");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTodoList_TodoListsNumber",
                table: "CategoryTodoList",
                newName: "IX_CategoryTodoList_TodoListnumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTodoList_category_CategoriesCategoryId",
                table: "CategoryTodoList",
                column: "CategoriesCategoryId",
                principalTable: "category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTodoList_TodoList_TodoListnumber",
                table: "CategoryTodoList",
                column: "TodoListnumber",
                principalTable: "TodoList",
                principalColumn: "number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
