using Microsoft.EntityFrameworkCore.Migrations;

namespace Habitix.Data.Migrations
{
    public partial class UpdateDataBaseTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Habits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "Habits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
