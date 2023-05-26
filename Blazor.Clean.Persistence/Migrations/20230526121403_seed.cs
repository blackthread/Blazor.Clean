using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.Clean.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ToDoItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 26, 14, 14, 3, 381, DateTimeKind.Local).AddTicks(6743), new DateTime(2023, 5, 26, 14, 14, 3, 381, DateTimeKind.Local).AddTicks(6789) });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "Description", "IsCompleted", "ModifiedBy" },
                values: new object[] { 1, null, new DateTime(2023, 5, 26, 14, 14, 3, 381, DateTimeKind.Local).AddTicks(8154), new DateTime(2023, 5, 26, 14, 14, 3, 381, DateTimeKind.Local).AddTicks(8161), "Do Awesome Stuff", false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 26, 14, 5, 55, 205, DateTimeKind.Local).AddTicks(8346), new DateTime(2023, 5, 26, 14, 5, 55, 205, DateTimeKind.Local).AddTicks(8411) });
        }
    }
}
