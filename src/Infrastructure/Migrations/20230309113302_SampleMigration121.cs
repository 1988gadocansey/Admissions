using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OnlineApplicationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SampleMigration121 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResearchModel",
                table: "ResearchModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageModels",
                table: "LanguageModels");

            migrationBuilder.RenameTable(
                name: "ResearchModel",
                newName: "ResearchModels");

            migrationBuilder.RenameTable(
                name: "LanguageModels",
                newName: "Languages");

            migrationBuilder.RenameColumn(
                name: "ApplicantModelID",
                table: "WorkingExperienceModels",
                newName: "ApplicantModelId");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantModelId",
                table: "WorkingExperienceModels",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ReligionModels",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "GradeModels",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Othernames",
                table: "ApplicantModel",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Dob",
                table: "ApplicantModel",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantModelId",
                table: "ApplicantIssueModels",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResearchModels",
                table: "ResearchModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DisabilitiesModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilitiesModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SHSAttendedModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttendedTTU = table.Column<bool>(type: "boolean", nullable: false),
                    Applicant = table.Column<int>(type: "integer", nullable: false),
                    student = table.Column<int>(type: "integer", nullable: true),
                    NameId = table.Column<int>(type: "integer", nullable: true),
                    LocationId = table.Column<int>(type: "integer", nullable: true),
                    StartYear = table.Column<string>(type: "text", nullable: true),
                    EndYear = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHSAttendedModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SHSAttendedModels_ApplicantModel_student",
                        column: x => x.student,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SHSAttendedModels_FormerSchoolModels_NameId",
                        column: x => x.NameId,
                        principalTable: "FormerSchoolModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SHSAttendedModels_RegionModels_LocationId",
                        column: x => x.LocationId,
                        principalTable: "RegionModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UniversityAttendedModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LocationID = table.Column<int>(type: "integer", nullable: true),
                    StartYear = table.Column<string>(type: "text", nullable: true),
                    EndYear = table.Column<string>(type: "text", nullable: true),
                    StudentNumber = table.Column<string>(type: "text", nullable: true),
                    DegreeObtained = table.Column<string>(type: "text", nullable: true),
                    DegreeClassification = table.Column<string>(type: "text", nullable: true),
                    CGPA = table.Column<decimal>(type: "numeric", nullable: true),
                    Applicant = table.Column<int>(type: "integer", nullable: false),
                    student = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityAttendedModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityAttendedModels_ApplicantModel_student",
                        column: x => x.student,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UniversityAttendedModels_CountryModels_LocationID",
                        column: x => x.LocationID,
                        principalTable: "CountryModels",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkingExperienceModels_ApplicantModelId",
                table: "WorkingExperienceModels",
                column: "ApplicantModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicExperienceModels_ApplicantModelID",
                table: "AcademicExperienceModels",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_SHSAttendedModels_LocationId",
                table: "SHSAttendedModels",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SHSAttendedModels_NameId",
                table: "SHSAttendedModels",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_SHSAttendedModels_student",
                table: "SHSAttendedModels",
                column: "student");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityAttendedModels_LocationID",
                table: "UniversityAttendedModels",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityAttendedModels_student",
                table: "UniversityAttendedModels",
                column: "student");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicExperienceModels_ApplicantModel_ApplicantModelID",
                table: "AcademicExperienceModels",
                column: "ApplicantModelID",
                principalTable: "ApplicantModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingExperienceModels_ApplicantModel_ApplicantModelId",
                table: "WorkingExperienceModels",
                column: "ApplicantModelId",
                principalTable: "ApplicantModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicExperienceModels_ApplicantModel_ApplicantModelID",
                table: "AcademicExperienceModels");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperienceModels_ApplicantModel_ApplicantModelId",
                table: "WorkingExperienceModels");

            migrationBuilder.DropTable(
                name: "DisabilitiesModels");

            migrationBuilder.DropTable(
                name: "SHSAttendedModels");

            migrationBuilder.DropTable(
                name: "UniversityAttendedModels");

            migrationBuilder.DropIndex(
                name: "IX_WorkingExperienceModels_ApplicantModelId",
                table: "WorkingExperienceModels");

            migrationBuilder.DropIndex(
                name: "IX_AcademicExperienceModels_ApplicantModelID",
                table: "AcademicExperienceModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResearchModels",
                table: "ResearchModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "ResearchModels",
                newName: "ResearchModel");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "LanguageModels");

            migrationBuilder.RenameColumn(
                name: "ApplicantModelId",
                table: "WorkingExperienceModels",
                newName: "ApplicantModelID");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantModelID",
                table: "WorkingExperienceModels",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ReligionModels",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "GradeModels",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Othernames",
                table: "ApplicantModel",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dob",
                table: "ApplicantModel",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantModelId",
                table: "ApplicantIssueModels",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LanguageModels",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResearchModel",
                table: "ResearchModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageModels",
                table: "LanguageModels",
                column: "Id");
        }
    }
}
