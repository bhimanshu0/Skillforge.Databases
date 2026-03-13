using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skillforge.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CertificationID",
                table: "ComplianceRecord",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Certification",
                columns: table => new
                {
                    CertificationID = table.Column<int>(type: "INT", nullable: false),
                    EmployeeID = table.Column<string>(type: "CHAR(5)", nullable: false),
                    CourseID = table.Column<string>(type: "CHAR(5)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Status = table.Column<string>(type: "VARCHAR(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certification", x => x.CertificationID);
                    table.ForeignKey(
                        name: "FK_Certification_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certification_User_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceRecord_CertificationID",
                table: "ComplianceRecord",
                column: "CertificationID");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_CourseID",
                table: "Certification",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_EmployeeID",
                table: "Certification",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplianceRecord_Certification_CertificationID",
                table: "ComplianceRecord",
                column: "CertificationID",
                principalTable: "Certification",
                principalColumn: "CertificationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplianceRecord_Certification_CertificationID",
                table: "ComplianceRecord");

            migrationBuilder.DropTable(
                name: "Certification");

            migrationBuilder.DropIndex(
                name: "IX_ComplianceRecord_CertificationID",
                table: "ComplianceRecord");

            migrationBuilder.AlterColumn<int>(
                name: "CertificationID",
                table: "ComplianceRecord",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");
        }
    }
}
