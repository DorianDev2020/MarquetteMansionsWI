using Microsoft.EntityFrameworkCore.Migrations;

namespace Marquette_Mansions.Data.Migrations
{
    public partial class modeltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3fb62b7-2630-4ec0-86da-8a1ab2ee5776");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82415f9f-3f93-4e97-b75c-87ef54ab385b", "8cf957ac-4a0a-4dee-8c38-64959e0519a0", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82415f9f-3f93-4e97-b75c-87ef54ab385b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3fb62b7-2630-4ec0-86da-8a1ab2ee5776", "97c06115-b86e-40c9-9a9b-7ff1e6869ffa", "Admin", "Admin" });
        }
    }
}
