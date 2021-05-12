using Microsoft.EntityFrameworkCore.Migrations;

namespace StopLightManagement.Migrations
{
    public partial class AddMeetingName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Sites_SiteCode_siteOrganizationID",
                table: "Meetings");

            migrationBuilder.RenameColumn(
                name: "siteOrganizationID",
                table: "Meetings",
                newName: "SiteOrganizationID");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_SiteCode_siteOrganizationID",
                table: "Meetings",
                newName: "IX_Meetings_SiteCode_SiteOrganizationID");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Meetings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Sites_SiteCode_SiteOrganizationID",
                table: "Meetings",
                columns: new[] { "SiteCode", "SiteOrganizationID" },
                principalTable: "Sites",
                principalColumns: new[] { "SiteCode", "OrganizationID" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Sites_SiteCode_SiteOrganizationID",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Meetings");

            migrationBuilder.RenameColumn(
                name: "SiteOrganizationID",
                table: "Meetings",
                newName: "siteOrganizationID");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_SiteCode_SiteOrganizationID",
                table: "Meetings",
                newName: "IX_Meetings_SiteCode_siteOrganizationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Sites_SiteCode_siteOrganizationID",
                table: "Meetings",
                columns: new[] { "SiteCode", "siteOrganizationID" },
                principalTable: "Sites",
                principalColumns: new[] { "SiteCode", "OrganizationID" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
