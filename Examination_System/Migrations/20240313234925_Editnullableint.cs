using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination_System.Migrations
{
    /// <inheritdoc />
    public partial class Editnullableint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_Instructor_Supervisor",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Track_Supervisor",
                table: "Track");

            migrationBuilder.AlterColumn<int>(
                name: "Supervisor",
                table: "Track",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Track_Supervisor",
                table: "Track",
                column: "Supervisor",
                unique: true,
                filter: "[Supervisor] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Instructor_Supervisor",
                table: "Track",
                column: "Supervisor",
                principalTable: "Instructor",
                principalColumn: "Ins_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_Instructor_Supervisor",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Track_Supervisor",
                table: "Track");

            migrationBuilder.AlterColumn<int>(
                name: "Supervisor",
                table: "Track",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Track_Supervisor",
                table: "Track",
                column: "Supervisor",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Instructor_Supervisor",
                table: "Track",
                column: "Supervisor",
                principalTable: "Instructor",
                principalColumn: "Ins_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
