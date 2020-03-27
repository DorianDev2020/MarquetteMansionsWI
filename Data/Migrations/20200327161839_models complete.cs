using Microsoft.EntityFrameworkCore.Migrations;

namespace Marquette_Mansions.Data.Migrations
{
    public partial class modelscomplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9ff690f-645a-4783-9127-9bbeff5815fa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "254f4c37-3ea5-478d-88a1-8f097396cd6c", "ffcb5b76-0b18-4035-9031-7c5225cf523f", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "254f4c37-3ea5-478d-88a1-8f097396cd6c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9ff690f-645a-4783-9127-9bbeff5815fa", "fb1b1e3b-55a2-408c-886c-1b5e038a1763", "Admin", "Admin" });
        }
    }
}
