using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.DAL.Migrations
{
    public partial class Addtestuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastName", "Password", "UpdatedAt", "UpdatedBy", "UserName", "isActive" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "test@ict.rs", "Test", "Test", "$2a$11$NfbS6xAaX/sayDDCrCFPGespdkdNxzI2yDIdZGpIRMifYYjO/EfuC", null, null, "Test", false });

            migrationBuilder.InsertData(
                table: "UserUseCases",
                columns: new[] { "UseCaseId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 },
                    { 15, 1 },
                    { 16, 1 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "UserUseCases",
                keyColumns: new[] { "UseCaseId", "UserId" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
