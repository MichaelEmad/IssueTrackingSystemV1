using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracking.Infra.Persistence.Migrations
{
    public partial class UpdateTheProjectConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_AspNetUsers_ParticipantsProjectsId",
                table: "ProjectUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_Project_ParticipantsProjectsId1",
                table: "ProjectUser");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_AspNetUsers_ParticipantsProjectsId1",
                table: "ProjectUser",
                column: "ParticipantsProjectsId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_Project_ParticipantsProjectsId",
                table: "ProjectUser",
                column: "ParticipantsProjectsId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_AspNetUsers_ParticipantsProjectsId1",
                table: "ProjectUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_Project_ParticipantsProjectsId",
                table: "ProjectUser");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_AspNetUsers_ParticipantsProjectsId",
                table: "ProjectUser",
                column: "ParticipantsProjectsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_Project_ParticipantsProjectsId1",
                table: "ProjectUser",
                column: "ParticipantsProjectsId1",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
