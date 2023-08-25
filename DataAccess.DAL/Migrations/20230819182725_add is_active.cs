using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.DAL.Migrations
{
    public partial class addis_active : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAcitve",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAcitve",
                table: "Films",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAcitve",
                table: "FilmImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAcitve",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAcitve",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAcitve",
                table: "Authors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAcitve",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsAcitve",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "IsAcitve",
                table: "FilmImages");

            migrationBuilder.DropColumn(
                name: "IsAcitve",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsAcitve",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsAcitve",
                table: "Authors");
        }
    }
}
