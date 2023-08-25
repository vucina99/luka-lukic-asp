using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.DAL.Migrations
{
    public partial class addis_activefixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAcitve",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "IsAcitve",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsAcitve",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "IsAcitve",
                table: "Users",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsAcitve",
                table: "FilmImages",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsAcitve",
                table: "Comments",
                newName: "isActive");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Films",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Authors",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Users",
                newName: "IsAcitve");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "FilmImages",
                newName: "IsAcitve");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Comments",
                newName: "IsAcitve");

            migrationBuilder.AddColumn<bool>(
                name: "IsAcitve",
                table: "Films",
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
    }
}
