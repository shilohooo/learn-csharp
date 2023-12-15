using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFluentApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedStudentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StuNo",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StuNo",
                table: "Students");
        }
    }
}
