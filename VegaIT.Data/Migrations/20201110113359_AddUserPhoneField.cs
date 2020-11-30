using Microsoft.EntityFrameworkCore.Migrations;

namespace VegaIT.Data.Migrations
{
    public partial class AddUserPhoneField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");
        }
    }
}
