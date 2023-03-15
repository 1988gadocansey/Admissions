using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineApplicationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifiedresearchexperiencetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "ResearchModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchModels_ApplicantId",
                table: "ResearchModels",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchModels_ApplicantModel_ApplicantId",
                table: "ResearchModels",
                column: "ApplicantId",
                principalTable: "ApplicantModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResearchModels_ApplicantModel_ApplicantId",
                table: "ResearchModels");

            migrationBuilder.DropIndex(
                name: "IX_ResearchModels_ApplicantId",
                table: "ResearchModels");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "ResearchModels");
        }
    }
}
