using Microsoft.EntityFrameworkCore.Migrations;

namespace Marquette_Mansions.Data.Migrations
{
    public partial class models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "254f4c37-3ea5-478d-88a1-8f097396cd6c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3fb62b7-2630-4ec0-86da-8a1ab2ee5776", "97c06115-b86e-40c9-9a9b-7ff1e6869ffa", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3fb62b7-2630-4ec0-86da-8a1ab2ee5776");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "254f4c37-3ea5-478d-88a1-8f097396cd6c", "ffcb5b76-0b18-4035-9031-7c5225cf523f", "Admin", "Admin" });
        }
    }
}
