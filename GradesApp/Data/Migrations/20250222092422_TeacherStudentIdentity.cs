using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradesApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeacherStudentIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_UserId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Students",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_UserId",
                table: "Students",
                newName: "IX_Students_AccountId");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AccountId",
                table: "Teachers",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_AccountId",
                table: "Students",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_AccountId",
                table: "Teachers",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_AccountId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_AccountId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_AccountId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Students",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_AccountId",
                table: "Students",
                newName: "IX_Students_UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_UserId",
                table: "Teachers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
