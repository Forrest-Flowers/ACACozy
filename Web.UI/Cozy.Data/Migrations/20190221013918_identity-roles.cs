using Microsoft.EntityFrameworkCore.Migrations;

namespace Cozy.Data.Migrations
{
    public partial class identityroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e76a2801-c83e-4b66-92d3-347b64e6cd11", "2b642368-fb03-42c3-aa3c-29be96b7a229", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a6ec84c-4f09-41ad-8dd0-4835ce188c08", "90ad0bcb-cec0-4f2f-b96d-124da79c98e6", "Tenant", "TENANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8a6ec84c-4f09-41ad-8dd0-4835ce188c08", "90ad0bcb-cec0-4f2f-b96d-124da79c98e6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e76a2801-c83e-4b66-92d3-347b64e6cd11", "2b642368-fb03-42c3-aa3c-29be96b7a229" });
        }
    }
}
