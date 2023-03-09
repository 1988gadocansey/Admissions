using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineApplicationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class unitableshstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SHSAttendedModels_ApplicantModel_student",
                table: "SHSAttendedModels");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityAttendedModels_ApplicantModel_student",
                table: "UniversityAttendedModels");

            migrationBuilder.DropIndex(
                name: "IX_UniversityAttendedModels_student",
                table: "UniversityAttendedModels");

            migrationBuilder.DropIndex(
                name: "IX_SHSAttendedModels_student",
                table: "SHSAttendedModels");

            migrationBuilder.DropColumn(
                name: "student",
                table: "UniversityAttendedModels");

            migrationBuilder.DropColumn(
                name: "student",
                table: "SHSAttendedModels");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityAttendedModels_Applicant",
                table: "UniversityAttendedModels",
                column: "Applicant");

            migrationBuilder.CreateIndex(
                name: "IX_SHSAttendedModels_Applicant",
                table: "SHSAttendedModels",
                column: "Applicant");

            migrationBuilder.AddForeignKey(
                name: "FK_SHSAttendedModels_ApplicantModel_Applicant",
                table: "SHSAttendedModels",
                column: "Applicant",
                principalTable: "ApplicantModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityAttendedModels_ApplicantModel_Applicant",
                table: "UniversityAttendedModels",
                column: "Applicant",
                principalTable: "ApplicantModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SHSAttendedModels_ApplicantModel_Applicant",
                table: "SHSAttendedModels");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityAttendedModels_ApplicantModel_Applicant",
                table: "UniversityAttendedModels");

            migrationBuilder.DropIndex(
                name: "IX_UniversityAttendedModels_Applicant",
                table: "UniversityAttendedModels");

            migrationBuilder.DropIndex(
                name: "IX_SHSAttendedModels_Applicant",
                table: "SHSAttendedModels");

            migrationBuilder.AddColumn<int>(
                name: "student",
                table: "UniversityAttendedModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "student",
                table: "SHSAttendedModels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UniversityAttendedModels_student",
                table: "UniversityAttendedModels",
                column: "student");

            migrationBuilder.CreateIndex(
                name: "IX_SHSAttendedModels_student",
                table: "SHSAttendedModels",
                column: "student");

            migrationBuilder.AddForeignKey(
                name: "FK_SHSAttendedModels_ApplicantModel_student",
                table: "SHSAttendedModels",
                column: "student",
                principalTable: "ApplicantModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityAttendedModels_ApplicantModel_student",
                table: "UniversityAttendedModels",
                column: "student",
                principalTable: "ApplicantModel",
                principalColumn: "Id");
        }
    }
}
