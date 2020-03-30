using Microsoft.EntityFrameworkCore.Migrations;

namespace Marquette_Mansions.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82415f9f-3f93-4e97-b75c-87ef54ab385b");

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    AdminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Managers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tennants",
                columns: table => new
                {
                    TennantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tennants", x => x.TennantID);
                    table.ForeignKey(
                        name: "FK_Tennants_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: false),
                    MaintenanceOrder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    SquareFeet = table.Column<int>(nullable: false),
                    Beds = table.Column<int>(nullable: false),
                    Baths = table.Column<int>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    LandLordId = table.Column<int>(nullable: true),
                    AdminID = table.Column<int>(nullable: true),
                    TennantID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ListingID);
                    table.ForeignKey(
                        name: "FK_Listings_Managers_LandLordId",
                        column: x => x.LandLordId,
                        principalTable: "Managers",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Listings_Tennants_TennantID",
                        column: x => x.TennantID,
                        principalTable: "Tennants",
                        principalColumn: "TennantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44c13fb7-73a6-4eef-b318-9f8d8bad0b4f", "70db3dd6-e292-4214-a222-625bbcb55cc6", "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Listings_LandLordId",
                table: "Listings",
                column: "LandLordId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_TennantID",
                table: "Listings",
                column: "TennantID");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_IdentityUserId",
                table: "Managers",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tennants_IdentityUserId",
                table: "Tennants",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Tennants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44c13fb7-73a6-4eef-b318-9f8d8bad0b4f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82415f9f-3f93-4e97-b75c-87ef54ab385b", "8cf957ac-4a0a-4dee-8c38-64959e0519a0", "Admin", "Admin" });
        }
    }
}
