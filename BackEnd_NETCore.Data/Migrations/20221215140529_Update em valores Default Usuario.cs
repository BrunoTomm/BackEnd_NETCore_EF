using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndNETCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateemvaloresDefaultUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("309b7c99-ff3d-4338-859f-d1a6b5857ce4"),
                column: "DateCreated",
                value: new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("309b7c99-ff3d-4338-859f-d1a6b5857ce4"),
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
