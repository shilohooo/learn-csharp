using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreConfig.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                schema: "dbo",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false, comment: "主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "学生姓名")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.StudentId);
                },
                comment: "学生信息表");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentInfo",
                schema: "dbo");
        }
    }
}
