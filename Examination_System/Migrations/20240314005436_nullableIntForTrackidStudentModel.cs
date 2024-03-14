using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination_System.Migrations
{
    /// <inheritdoc />
    public partial class nullableIntForTrackidStudentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Track_TrackId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Track_TrackId",
                table: "Student",
                column: "TrackId",
                principalTable: "Track",
                principalColumn: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Track_TrackId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Track_TrackId",
                table: "Student",
                column: "TrackId",
                principalTable: "Track",
                principalColumn: "TrackId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
