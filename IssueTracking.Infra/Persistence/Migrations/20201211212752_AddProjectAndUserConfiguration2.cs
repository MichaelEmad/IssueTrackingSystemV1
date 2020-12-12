using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracking.Infra.Persistence.Migrations
{
    public partial class AddProjectAndUserConfiguration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Project_Id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_OwnerId",
                table: "Project",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_OwnerId",
                table: "Project",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_OwnerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_OwnerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Project");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Project_Id",
                table: "AspNetUsers",
                column: "Id",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
