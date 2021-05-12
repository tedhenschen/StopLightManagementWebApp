using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StopLightManagement.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    SiteCode = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    OrganizationID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => new { x.SiteCode, x.OrganizationID });
                    table.ForeignKey(
                        name: "FK_Sites_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    SiteCode = table.Column<string>(nullable: false),
                    SiteOrganizationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Departments_Sites_SiteCode_SiteOrganizationID",
                        columns: x => new { x.SiteCode, x.SiteOrganizationID },
                        principalTable: "Sites",
                        principalColumns: new[] { "SiteCode", "OrganizationID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TierLevel = table.Column<int>(nullable: false),
                    Frequency = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    SiteCode = table.Column<string>(nullable: false),
                    siteOrganizationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.ID);
                    table.CheckConstraint("ck_TierLevel", "TierLevel Between 0 AND 10");
                    table.CheckConstraint("ck_Frequency", "Frequency IN ('Daily','Weekly','Bi-Weekly','Monthly')");
                    table.ForeignKey(
                        name: "FK_Meetings_Sites_SiteCode_siteOrganizationID",
                        columns: x => new { x.SiteCode, x.siteOrganizationID },
                        principalTable: "Sites",
                        principalColumns: new[] { "SiteCode", "OrganizationID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    departmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_departmentID",
                        column: x => x.departmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KPIS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformanceIndicator = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    ActiveDate = table.Column<DateTime>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    DepartmentID = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPIS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KPIS_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KPIS_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendee",
                columns: table => new
                {
                    MeetingID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => new { x.MeetingID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_Attendee_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendee_Meetings_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meetings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statement = table.Column<string>(nullable: false),
                    OriginalDueDate = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    RevisedDueDate = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    RaisedById = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    RaisedAtID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Issues_Employees_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issues_Meetings_RaisedAtID",
                        column: x => x.RaisedAtID,
                        principalTable: "Meetings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issues_Employees_RaisedById",
                        column: x => x.RaisedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issues_IssueStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "IssueStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingKPI",
                columns: table => new
                {
                    MeetingID = table.Column<int>(nullable: false),
                    KPIID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingKPI", x => new { x.MeetingID, x.KPIID });
                    table.ForeignKey(
                        name: "FK_MeetingKPI_KPIS_KPIID",
                        column: x => x.KPIID,
                        principalTable: "KPIS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingKPI_Meetings_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meetings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LowerRange = table.Column<double>(nullable: true),
                    UpperRange = table.Column<double>(nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "NVARCHAR(25)", maxLength: 25, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    DateChanged = table.Column<DateTime>(nullable: true),
                    DateDisabled = table.Column<DateTime>(nullable: true),
                    KPIID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                    table.CheckConstraint("ck_NullRange", "LowerRange is not null or UpperRange is not null");
                    table.ForeignKey(
                        name: "FK_Targets_KPIS_KPIID",
                        column: x => x.KPIID,
                        principalTable: "KPIS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    Comments = table.Column<string>(nullable: true),
                    IssueID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueComments_Issues_IssueID",
                        column: x => x.IssueID,
                        principalTable: "Issues",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_EmployeeID",
                table: "Attendee",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_SiteCode_SiteOrganizationID",
                table: "Departments",
                columns: new[] { "SiteCode", "SiteOrganizationID" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_departmentID",
                table: "Employees",
                column: "departmentID");

            migrationBuilder.CreateIndex(
                name: "IX_IssueComments_IssueID",
                table: "IssueComments",
                column: "IssueID");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_OwnerId",
                table: "Issues",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_RaisedAtID",
                table: "Issues",
                column: "RaisedAtID");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_RaisedById",
                table: "Issues",
                column: "RaisedById");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_StatusId",
                table: "Issues",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_CategoryId",
                table: "KPIS",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_DepartmentID",
                table: "KPIS",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingKPI_KPIID",
                table: "MeetingKPI",
                column: "KPIID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_SiteCode_siteOrganizationID",
                table: "Meetings",
                columns: new[] { "SiteCode", "siteOrganizationID" });

            migrationBuilder.CreateIndex(
                name: "IX_Sites_OrganizationID",
                table: "Sites",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_KPIID",
                table: "Targets",
                column: "KPIID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendee");

            migrationBuilder.DropTable(
                name: "IssueComments");

            migrationBuilder.DropTable(
                name: "MeetingKPI");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "KPIS");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "IssueStatus");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
