using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineApplicationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class results : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultUploadModels_ApplicantModel_ApplicantId",
                table: "ResultUploadModels");

            migrationBuilder.DropIndex(
                name: "IX_ResultUploadModels_ApplicantId",
                table: "ResultUploadModels");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "ResultUploadModels");

            migrationBuilder.RenameColumn(
                name: "ApplicantModel",
                table: "ResultUploadModels",
                newName: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModels_ApplicantModelID",
                table: "ResultUploadModels",
                column: "ApplicantModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultUploadModels_ApplicantModel_ApplicantModelID",
                table: "ResultUploadModels",
                column: "ApplicantModelID",
                principalTable: "ApplicantModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultUploadModels_ApplicantModel_ApplicantModelID",
                table: "ResultUploadModels");

            migrationBuilder.DropIndex(
                name: "IX_ResultUploadModels_ApplicantModelID",
                table: "ResultUploadModels");

            migrationBuilder.RenameColumn(
                name: "ApplicantModelID",
                table: "ResultUploadModels",
                newName: "ApplicantModel");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "ResultUploadModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModels_ApplicantId",
                table: "ResultUploadModels",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultUploadModels_ApplicantModel_ApplicantId",
                table: "ResultUploadModels",
                column: "ApplicantId",
                principalTable: "ApplicantModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
