using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination_System.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Course_ID);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Ins_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Img_Id = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Ins_Id);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Exam_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Exam_ID);
                    table.ForeignKey(
                        name: "FK_Exam_Course_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Course",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Topic_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Topic_ID);
                    table.ForeignKey(
                        name: "FK_Topic_Course_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Course",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorCourse",
                columns: table => new
                {
                    CrsId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorCourse", x => new { x.CrsId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_InstructorCourse_Course_CrsId",
                        column: x => x.CrsId,
                        principalTable: "Course",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorCourse_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Ins_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Supervisor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_Track_Instructor_Supervisor",
                        column: x => x.Supervisor,
                        principalTable: "Instructor",
                        principalColumn: "Ins_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Ques_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quest = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Corr_Answer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OPt1_Answer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OPt2_Answer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OPt3_Answer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Quest_Deg = table.Column<int>(type: "int", nullable: false),
                    Exam_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Ques_ID);
                    table.ForeignKey(
                        name: "FK_Question_Exam_Exam_ID",
                        column: x => x.Exam_ID,
                        principalTable: "Exam",
                        principalColumn: "Exam_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image_ID = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track_Instructor",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    Ins_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track_Instructor", x => new { x.Ins_Id, x.TrackId });
                    table.ForeignKey(
                        name: "FK_Track_Instructor_Instructor_Ins_Id",
                        column: x => x.Ins_Id,
                        principalTable: "Instructor",
                        principalColumn: "Ins_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Track_Instructor_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId");
                });

            migrationBuilder.CreateTable(
                name: "StudentAnswer",
                columns: table => new
                {
                    Stud_Id = table.Column<int>(type: "int", nullable: false),
                    Ques_ID = table.Column<int>(type: "int", nullable: false),
                    Student_Answer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    If_Correct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswer", x => new { x.Stud_Id, x.Ques_ID });
                    table.ForeignKey(
                        name: "FK_StudentAnswer_Question_Ques_ID",
                        column: x => x.Ques_ID,
                        principalTable: "Question",
                        principalColumn: "Ques_ID");
                    table.ForeignKey(
                        name: "FK_StudentAnswer_Student_Stud_Id",
                        column: x => x.Stud_Id,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    CrsId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.CrsId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentCourse_Course_CrsId",
                        column: x => x.CrsId,
                        principalTable: "Course",
                        principalColumn: "Course_ID");
                    table.ForeignKey(
                        name: "FK_StudentCourse_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Course_ID",
                table: "Exam",
                column: "Course_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCourse_InstructorId",
                table: "InstructorCourse",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Exam_ID",
                table: "Question",
                column: "Exam_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_TrackId",
                table: "Student",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswer_Ques_ID",
                table: "StudentAnswer",
                column: "Ques_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentId",
                table: "StudentCourse",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_Course_ID",
                table: "Topic",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Track_Supervisor",
                table: "Track",
                column: "Supervisor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Track_Instructor_TrackId",
                table: "Track_Instructor",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorCourse");

            migrationBuilder.DropTable(
                name: "StudentAnswer");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Track_Instructor");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Instructor");
        }
    }
}
