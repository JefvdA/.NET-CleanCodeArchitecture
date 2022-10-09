using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class DataSeedingV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "TodoItem",
                table: "tblTodoItems",
                columns: new[] { "Id", "Description" },
                values: new object[] { -2, "This is the second todo item" });

            migrationBuilder.InsertData(
                schema: "TodoItem",
                table: "tblTodoItems",
                columns: new[] { "Id", "Description" },
                values: new object[] { -1, "This is the first todo item" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "TodoItem",
                table: "tblTodoItems",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "TodoItem",
                table: "tblTodoItems",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
