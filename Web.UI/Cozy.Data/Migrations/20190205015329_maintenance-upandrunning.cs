using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cozy.Data.Migrations
{
    public partial class maintenanceupandrunning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Maintenances",
                newName: "MaintenanceStatusId");

            migrationBuilder.CreateTable(
                name: "MaintenanceStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MaintenanceStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "In Progress" },
                    { 3, "Closed" },
                    { 4, "Cancelled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_MaintenanceStatusId",
                table: "Maintenances",
                column: "MaintenanceStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_MaintenanceStatuses_MaintenanceStatusId",
                table: "Maintenances",
                column: "MaintenanceStatusId",
                principalTable: "MaintenanceStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_MaintenanceStatuses_MaintenanceStatusId",
                table: "Maintenances");

            migrationBuilder.DropTable(
                name: "MaintenanceStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Maintenances_MaintenanceStatusId",
                table: "Maintenances");

            migrationBuilder.RenameColumn(
                name: "MaintenanceStatusId",
                table: "Maintenances",
                newName: "Status");
        }
    }
}
