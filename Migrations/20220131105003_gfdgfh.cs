using Microsoft.EntityFrameworkCore.Migrations;

namespace shipwithme.Migrations
{
    public partial class gfdgfh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "notify",
                table: "Registration",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "notify",
                table: "Preference",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "notify",
                table: "Createpurposal",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "notify",
                table: "Registration");

            migrationBuilder.DropColumn(
                name: "notify",
                table: "Preference");

            migrationBuilder.DropColumn(
                name: "notify",
                table: "Createpurposal");
        }
    }
}
