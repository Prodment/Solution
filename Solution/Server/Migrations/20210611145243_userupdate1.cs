using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Solution.Server.Migrations
{
    public partial class userupdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 6, 11, 16, 52, 43, 86, DateTimeKind.Local).AddTicks(451), new DateTime(2021, 6, 11, 16, 52, 43, 86, DateTimeKind.Local).AddTicks(9432) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 6, 11, 16, 52, 43, 88, DateTimeKind.Local).AddTicks(367), new DateTime(2021, 6, 11, 16, 52, 43, 88, DateTimeKind.Local).AddTicks(373) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 6, 11, 16, 52, 43, 88, DateTimeKind.Local).AddTicks(462), new DateTime(2021, 6, 11, 16, 52, 43, 88, DateTimeKind.Local).AddTicks(463) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 6, 11, 12, 23, 17, 533, DateTimeKind.Local).AddTicks(361), new DateTime(2021, 6, 11, 12, 23, 17, 533, DateTimeKind.Local).AddTicks(9022) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 6, 11, 12, 23, 17, 535, DateTimeKind.Local).AddTicks(731), new DateTime(2021, 6, 11, 12, 23, 17, 535, DateTimeKind.Local).AddTicks(741) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 6, 11, 12, 23, 17, 535, DateTimeKind.Local).AddTicks(832), new DateTime(2021, 6, 11, 12, 23, 17, 535, DateTimeKind.Local).AddTicks(833) });
        }
    }
}
