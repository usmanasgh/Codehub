using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorWebAssemblyApp.Server.Migrations
{
    public partial class AddBusinessEmployeeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessEmployees_BusinessDepartment_DepartmentId",
                table: "BusinessEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessDepartment",
                table: "BusinessDepartment");

            migrationBuilder.RenameTable(
                name: "BusinessDepartment",
                newName: "BusinessDepartments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessDepartments",
                table: "BusinessDepartments",
                column: "DepartmentId");

            migrationBuilder.InsertData(
                table: "BusinessEmployees",
                columns: new[] { "EmployeeId", "DateOfBrith", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "David@pragimtech.com", "John", 0, "Hastings", "images/john.png" },
                    { 2, new DateTime(1981, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sam@pragimtech.com", "Sam", 0, "Galloway", "images/sam.jpg" },
                    { 3, new DateTime(1979, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "mary@pragimtech.com", "Mary", 1, "Smith", "images/mary.png" },
                    { 4, new DateTime(1982, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "sara@pragimtech.com", "Sara", 1, "Longway", "images/sara.png" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessEmployees_BusinessDepartments_DepartmentId",
                table: "BusinessEmployees",
                column: "DepartmentId",
                principalTable: "BusinessDepartments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessEmployees_BusinessDepartments_DepartmentId",
                table: "BusinessEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessDepartments",
                table: "BusinessDepartments");

            migrationBuilder.DeleteData(
                table: "BusinessEmployees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BusinessEmployees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BusinessEmployees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BusinessEmployees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "BusinessDepartments",
                newName: "BusinessDepartment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessDepartment",
                table: "BusinessDepartment",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessEmployees_BusinessDepartment_DepartmentId",
                table: "BusinessEmployees",
                column: "DepartmentId",
                principalTable: "BusinessDepartment",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
