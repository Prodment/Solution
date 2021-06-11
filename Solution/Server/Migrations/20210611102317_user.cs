using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Solution.Server.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surburb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidentialAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.GID);
                });

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountHolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.GID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.GID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KnownAs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankDetailsGID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressGID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.GID);
                    table.ForeignKey(
                        name: "FK_Profile_Address_AddressGID",
                        column: x => x.AddressGID,
                        principalTable: "Address",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profile_BankDetails_BankDetailsGID",
                        column: x => x.BankDetailsGID,
                        principalTable: "BankDetails",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VenueAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deposit = table.Column<bool>(type: "bit", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientGID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.GID);
                    table.ForeignKey(
                        name: "FK_Booking_Client_ClientGID",
                        column: x => x.ClientGID,
                        principalTable: "Client",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    GID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileGID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.GID);
                    table.ForeignKey(
                        name: "FK_User_Profile_ProfileGID",
                        column: x => x.ProfileGID,
                        principalTable: "Profile",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Created", "DescriptionType", "Updated" },
                values: new object[] { 1, new DateTime(2021, 6, 11, 12, 23, 17, 533, DateTimeKind.Local).AddTicks(361), "Admin", new DateTime(2021, 6, 11, 12, 23, 17, 533, DateTimeKind.Local).AddTicks(9022) });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Created", "DescriptionType", "Updated" },
                values: new object[] { 2, new DateTime(2021, 6, 11, 12, 23, 17, 535, DateTimeKind.Local).AddTicks(731), "Manager", new DateTime(2021, 6, 11, 12, 23, 17, 535, DateTimeKind.Local).AddTicks(741) });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Created", "DescriptionType", "Updated" },
                values: new object[] { 3, new DateTime(2021, 6, 11, 12, 23, 17, 535, DateTimeKind.Local).AddTicks(832), "Artist", new DateTime(2021, 6, 11, 12, 23, 17, 535, DateTimeKind.Local).AddTicks(833) });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ClientGID",
                table: "Booking",
                column: "ClientGID");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_AddressGID",
                table: "Profile",
                column: "AddressGID");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_BankDetailsGID",
                table: "Profile",
                column: "BankDetailsGID");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileGID",
                table: "User",
                column: "ProfileGID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BankDetails");
        }
    }
}
