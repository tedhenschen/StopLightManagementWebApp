using Microsoft.EntityFrameworkCore.Migrations;

namespace StopLightManagement.Migrations
{
    public partial class meetingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Sites_SiteCode_SiteOrganizationID",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_SiteCode_SiteOrganizationID",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "SiteOrganizationID",
                table: "Meetings");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationID",
                table: "Meetings",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_SiteCode_OrganizationID",
                table: "Meetings",
                columns: new[] { "SiteCode", "OrganizationID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Sites_SiteCode_OrganizationID",
                table: "Meetings",
                columns: new[] { "SiteCode", "OrganizationID" },
                principalTable: "Sites",
                principalColumns: new[] { "SiteCode", "OrganizationID" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Sites_SiteCode_OrganizationID",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_SiteCode_OrganizationID",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "OrganizationID",
                table: "Meetings");

            migrationBuilder.AddColumn<int>(
                name: "SiteOrganizationID",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_SiteCode_SiteOrganizationID",
                table: "Meetings",
                columns: new[] { "SiteCode", "SiteOrganizationID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Sites_SiteCode_SiteOrganizationID",
                table: "Meetings",
                columns: new[] { "SiteCode", "SiteOrganizationID" },
                principalTable: "Sites",
                principalColumns: new[] { "SiteCode", "OrganizationID" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
