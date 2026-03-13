using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skillforge.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competency",
                columns: table => new
                {
                    CompetencyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "CHAR(10)", nullable: false),
                    Description = table.Column<string>(type: "CHAR(50)", nullable: true),
                    Level = table.Column<string>(type: "CHAR(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competency", x => x.CompetencyID);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "CHAR(5)", nullable: false),
                    Name = table.Column<string>(type: "CHAR(20)", nullable: false),
                    Role = table.Column<string>(type: "CHAR(20)", nullable: false),
                    Email = table.Column<string>(type: "CHAR(50)", nullable: false),
                    Phone = table.Column<string>(type: "CHAR(10)", nullable: false),
                    Status = table.Column<string>(type: "CHAR(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false),
                    EnrollmentID = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => new { x.AttendanceID, x.EnrollmentID });
                    table.ForeignKey(
                        name: "FK_Attendance_Enrollment_EnrollmentID",
                        column: x => x.EnrollmentID,
                        principalTable: "Enrollment",
                        principalColumn: "EnrollmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    AuditID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HRID = table.Column<string>(type: "CHAR(5)", maxLength: 20, nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Findings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.AuditID);
                    table.ForeignKey(
                        name: "FK_Audit_User_HRID",
                        column: x => x.HRID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    AuditID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "CHAR(5)", nullable: true),
                    Action = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Resource = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.AuditID);
                    table.ForeignKey(
                        name: "FK_AuditLog_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ComplianceRecord",
                columns: table => new
                {
                    ComplianceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<string>(type: "CHAR(5)", nullable: false),
                    CertificationID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceRecord", x => x.ComplianceID);
                    table.ForeignKey(
                        name: "FK_ComplianceRecord_User_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<string>(type: "char(5)", nullable: false),
                    Title = table.Column<string>(type: "char(20)", nullable: false),
                    Description = table.Column<string>(type: "char(50)", nullable: false),
                    TrainerID = table.Column<string>(type: "char(5)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "char(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_User_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "SkillGap",
                columns: table => new
                {
                    SkillGapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<string>(type: "CHAR(5)", nullable: false),
                    CompetencyID = table.Column<int>(type: "int", nullable: false),
                    GapLevel = table.Column<int>(type: "int", nullable: false),
                    DateIdentified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillGap", x => x.SkillGapID);
                    table.ForeignKey(
                        name: "FK_SkillGap_Competency_CompetencyID",
                        column: x => x.CompetencyID,
                        principalTable: "Competency",
                        principalColumn: "CompetencyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillGap_User_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ModuleID = table.Column<string>(type: "char(5)", nullable: false),
                    CourseID = table.Column<string>(type: "char(5)", nullable: true),
                    Title = table.Column<string>(type: "char(20)", nullable: true),
                    ContentURI = table.Column<string>(type: "char(50)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "char(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ModuleID);
                    table.ForeignKey(
                        name: "FK_Module_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<string>(type: "char(5)", nullable: true),
                    EmployeeID = table.Column<string>(type: "CHAR(5)", nullable: true),
                    Metrics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneratedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK_Report_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_Report_User_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_EnrollmentID",
                table: "Attendance",
                column: "EnrollmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_HRID",
                table: "Audit",
                column: "HRID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLog_UserID",
                table: "AuditLog",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceRecord_EmployeeID",
                table: "ComplianceRecord",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TrainerID",
                table: "Course",
                column: "TrainerID");

            migrationBuilder.CreateIndex(
                name: "IX_Module_CourseID",
                table: "Module",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Report_CourseID",
                table: "Report",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Report_EmployeeID",
                table: "Report",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillGap_CompetencyID",
                table: "SkillGap",
                column: "CompetencyID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillGap_EmployeeID",
                table: "SkillGap",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "ComplianceRecord");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "SkillGap");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Competency");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
