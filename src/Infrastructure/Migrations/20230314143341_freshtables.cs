using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineApplicationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class freshtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ApplicantModelID",
                table: "Addresss",
                newName: "ApplicantModel");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "ResultUploadModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "Addresss",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModels_ApplicantId",
                table: "ResultUploadModels",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_ApplicantId",
                table: "Addresss",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_ApplicantModel_ApplicantId",
                table: "Addresss",
                column: "ApplicantId",
                principalTable: "ApplicantModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultUploadModels_ApplicantModel_ApplicantId",
                table: "ResultUploadModels",
                column: "ApplicantId",
                principalTable: "ApplicantModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_ApplicantModel_ApplicantId",
                table: "Addresss");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultUploadModels_ApplicantModel_ApplicantId",
                table: "ResultUploadModels");

            migrationBuilder.DropIndex(
                name: "IX_ResultUploadModels_ApplicantId",
                table: "ResultUploadModels");

            migrationBuilder.DropIndex(
                name: "IX_Addresss_ApplicantId",
                table: "Addresss");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "ResultUploadModels");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "Addresss");

            migrationBuilder.RenameColumn(
                name: "ApplicantModel",
                table: "ResultUploadModels",
                newName: "ApplicantModelID");

            migrationBuilder.RenameColumn(
                name: "ApplicantModel",
                table: "Addresss",
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
    }
}
