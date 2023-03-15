using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineApplicationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifiedtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Foriegn",
                table: "AspNetUsers",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicantModelId1",
                table: "ApplicantIssueModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Biodata",
                table: "ApplicantIssueModels",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantIssueModels_ApplicantModelId1",
                table: "ApplicantIssueModels",
                column: "ApplicantModelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantIssueModels_ApplicantModel_ApplicantModelId1",
                table: "ApplicantIssueModels",
                column: "ApplicantModelId1",
                principalTable: "ApplicantModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantIssueModels_ApplicantModel_ApplicantModelId1",
                table: "ApplicantIssueModels");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantIssueModels_ApplicantModelId1",
                table: "ApplicantIssueModels");

            migrationBuilder.DropColumn(
                name: "Foriegn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicantModelId1",
                table: "ApplicantIssueModels");

            migrationBuilder.DropColumn(
                name: "Biodata",
                table: "ApplicantIssueModels");
        }
    }
}
