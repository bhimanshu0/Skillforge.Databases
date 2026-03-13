using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skillforge.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certification_Course_CourseID",
                table: "Certification");

            migrationBuilder.DropForeignKey(
                name: "FK_Certification_User_EmployeeID",
                table: "Certification");

            migrationBuilder.DropForeignKey(
                name: "FK_ComplianceRecord_Certification_CertificationID",
                table: "ComplianceRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certification",
                table: "Certification");

            migrationBuilder.RenameTable(
                name: "Certification",
                newName: "Certifications");

            migrationBuilder.RenameIndex(
                name: "IX_Certification_EmployeeID",
                table: "Certifications",
                newName: "IX_Certifications_EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Certification_CourseID",
                table: "Certifications",
                newName: "IX_Certifications_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certifications",
                table: "Certifications",
                column: "CertificationID");

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    AssessmentID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<string>(type: "CHAR(5)", nullable: true),
                    Type = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    MaxScore = table.Column<decimal>(type: "DECIMAL(4,1)", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.AssessmentID);
                    table.ForeignKey(
                        name: "FK_Assessments_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentID = table.Column<int>(type: "INT", nullable: false),
                    EmployeeID = table.Column<string>(type: "CHAR(5)", nullable: false),
                    Score = table.Column<decimal>(type: "DECIMAL(4,1)", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK_Results_Assessments_AssessmentID",
                        column: x => x.AssessmentID,
                        principalTable: "Assessments",
                        principalColumn: "AssessmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_User_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_CourseID",
                table: "Assessments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_AssessmentID",
                table: "Results",
                column: "AssessmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_EmployeeID",
                table: "Results",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Course_CourseID",
                table: "Certifications",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_User_EmployeeID",
                table: "Certifications",
                column: "EmployeeID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplianceRecord_Certifications_CertificationID",
                table: "ComplianceRecord",
                column: "CertificationID",
                principalTable: "Certifications",
                principalColumn: "CertificationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Course_CourseID",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_User_EmployeeID",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_ComplianceRecord_Certifications_CertificationID",
                table: "ComplianceRecord");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certifications",
                table: "Certifications");

            migrationBuilder.RenameTable(
                name: "Certifications",
                newName: "Certification");

            migrationBuilder.RenameIndex(
                name: "IX_Certifications_EmployeeID",
                table: "Certification",
                newName: "IX_Certification_EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Certifications_CourseID",
                table: "Certification",
                newName: "IX_Certification_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certification",
                table: "Certification",
                column: "CertificationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Certification_Course_CourseID",
                table: "Certification",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certification_User_EmployeeID",
                table: "Certification",
                column: "EmployeeID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplianceRecord_Certification_CertificationID",
                table: "ComplianceRecord",
                column: "CertificationID",
                principalTable: "Certification",
                principalColumn: "CertificationID");
        }
    }
}
