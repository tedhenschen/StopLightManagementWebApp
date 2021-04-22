using Microsoft.EntityFrameworkCore.Migrations;

namespace StopLightManagement.Migrations
{
    public partial class AddMeetingDepartmentRelationship : Migration
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

            migrationBuilder.CreateTable(
                name: "MeetingDepartments",
                columns: table => new
                {
                    MeetingID = table.Column<int>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingDepartments", x => new { x.MeetingID, x.DepartmentID });
                    table.ForeignKey(
                        name: "FK_MeetingDepartments_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingDepartments_Meetings_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meetings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingDepartments_DepartmentID",
                table: "MeetingDepartments",
                column: "DepartmentID");

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

            migrationBuilder.DropTable(
                name: "MeetingDepartments");

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
