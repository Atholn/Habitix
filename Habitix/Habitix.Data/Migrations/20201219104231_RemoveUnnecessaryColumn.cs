using Microsoft.EntityFrameworkCore.Migrations;

namespace Habitix.Data.Migrations
{
    public partial class RemoveUnnecessaryColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "HabitsDates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "HabitsDates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
