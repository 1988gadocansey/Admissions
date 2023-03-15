using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineApplicationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifiedtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantIssueModels_ApplicantModel_ApplicantModelId1",
                table: "ApplicantIssueModels");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantIssueModels_ApplicantModelId1",
                table: "ApplicantIssueModels");

            migrationBuilder.DropColumn(
                name: "ApplicantModelId1",
                table: "ApplicantIssueModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicantModelId1",
                table: "ApplicantIssueModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
    }
}
