using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillForgeLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Trainer_TrainerID",
                table: "Course");

            migrationBuilder.DropTable(
                name: "Trainer");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Course_User_TrainerID",
                table: "Course",
                column: "TrainerID",
                principalTable: "User",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_User_TrainerID",
                table: "Course");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    TrainerID = table.Column<string>(type: "Char(5)", nullable: false),
                    TrainerName = table.Column<string>(type: "char(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.TrainerID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Trainer_TrainerID",
                table: "Course",
                column: "TrainerID",
                principalTable: "Trainer",
                principalColumn: "TrainerID");
        }
    }
}
