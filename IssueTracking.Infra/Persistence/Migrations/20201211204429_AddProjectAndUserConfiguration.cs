using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracking.Infra.Persistence.Migrations
{
    public partial class AddProjectAndUserConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_AspNetUsers_ParticipantsProjectsId1",
                table: "ProjectUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_Project_ParticipantsProjectsId",
                table: "ProjectUser");

            migrationBuilder.RenameColumn(
                name: "ParticipantsProjectsId1",
                table: "ProjectUser",
                newName: "ProjectsId");

            migrationBuilder.RenameColumn(
                name: "ParticipantsProjectsId",
                table: "ProjectUser",
                newName: "ParticipantsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectUser_ParticipantsProjectsId1",
                table: "ProjectUser",
                newName: "IX_ProjectUser_ProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_AspNetUsers_ParticipantsId",
                table: "ProjectUser",
                column: "ParticipantsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_Project_ProjectsId",
                table: "ProjectUser",
                column: "ProjectsId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_AspNetUsers_ParticipantsId",
                table: "ProjectUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_Project_ProjectsId",
                table: "ProjectUser");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "ProjectUser",
                newName: "ParticipantsProjectsId1");

            migrationBuilder.RenameColumn(
                name: "ParticipantsId",
                table: "ProjectUser",
                newName: "ParticipantsProjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectUser_ProjectsId",
                table: "ProjectUser",
                newName: "IX_ProjectUser_ParticipantsProjectsId1");

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
    }
}
