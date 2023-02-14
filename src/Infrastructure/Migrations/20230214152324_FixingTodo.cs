using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineApplicationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingTodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_CountryModel_NationalityId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_DistrictModel_DistrictId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_FormerSchoolModel_FormerSchoolNewId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_HallModel_HallId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_ProgrammeModel_ProgrammeModelId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_RegionModel_RegionId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_ReligionModel_ReligionId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultUploadModel_GradeModel_GradeID",
                table: "ResultUploadModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultUploadModel_SubjectModel_SubjectID",
                table: "ResultUploadModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_TodoList_ListId",
                table: "TodoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingExperienceModel",
                table: "WorkingExperienceModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoList",
                table: "TodoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItem",
                table: "TodoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectModel",
                table: "SubjectModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SMSModel",
                table: "SMSModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolModel",
                table: "SchoolModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultUploadModel",
                table: "ResultUploadModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequirementModel",
                table: "RequirementModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReligionModel",
                table: "ReligionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionModel",
                table: "RegionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgrammeModel",
                table: "ProgrammeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageModel",
                table: "LanguageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HallModel",
                table: "HallModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GradeModel",
                table: "GradeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormNoModel",
                table: "FormNoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormerSchoolModel",
                table: "FormerSchoolModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacultyModel",
                table: "FacultyModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamModel",
                table: "ExamModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentUploadModel",
                table: "DocumentUploadModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DistrictModel",
                table: "DistrictModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentModel",
                table: "DepartmentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DenominationModel",
                table: "DenominationModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryModel",
                table: "CountryModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigurationModel",
                table: "ConfigurationModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankModel",
                table: "BankModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantIssueModel",
                table: "ApplicantIssueModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcademicExperienceModel",
                table: "AcademicExperienceModel");

            migrationBuilder.RenameTable(
                name: "WorkingExperienceModel",
                newName: "WorkingExperienceModels");

            migrationBuilder.RenameTable(
                name: "TodoList",
                newName: "TodoLists");

            migrationBuilder.RenameTable(
                name: "TodoItem",
                newName: "TodoItems");

            migrationBuilder.RenameTable(
                name: "SubjectModel",
                newName: "SubjectModels");

            migrationBuilder.RenameTable(
                name: "SMSModel",
                newName: "SMSModels");

            migrationBuilder.RenameTable(
                name: "SchoolModel",
                newName: "SchoolModels");

            migrationBuilder.RenameTable(
                name: "ResultUploadModel",
                newName: "ResultUploadModels");

            migrationBuilder.RenameTable(
                name: "RequirementModel",
                newName: "RequirementModels");

            migrationBuilder.RenameTable(
                name: "ReligionModel",
                newName: "ReligionModels");

            migrationBuilder.RenameTable(
                name: "RegionModel",
                newName: "RegionModels");

            migrationBuilder.RenameTable(
                name: "ProgrammeModel",
                newName: "ProgrammeModels");

            migrationBuilder.RenameTable(
                name: "LanguageModel",
                newName: "LanguageModels");

            migrationBuilder.RenameTable(
                name: "HallModel",
                newName: "HallModels");

            migrationBuilder.RenameTable(
                name: "GradeModel",
                newName: "GradeModels");

            migrationBuilder.RenameTable(
                name: "FormNoModel",
                newName: "FormNoModels");

            migrationBuilder.RenameTable(
                name: "FormerSchoolModel",
                newName: "FormerSchoolModels");

            migrationBuilder.RenameTable(
                name: "FacultyModel",
                newName: "FacultyModels");

            migrationBuilder.RenameTable(
                name: "ExamModel",
                newName: "ExamModels");

            migrationBuilder.RenameTable(
                name: "DocumentUploadModel",
                newName: "DocumentUploadModels");

            migrationBuilder.RenameTable(
                name: "DistrictModel",
                newName: "DistrictModels");

            migrationBuilder.RenameTable(
                name: "DepartmentModel",
                newName: "DepartmentModels");

            migrationBuilder.RenameTable(
                name: "DenominationModel",
                newName: "DenominationModels");

            migrationBuilder.RenameTable(
                name: "CountryModel",
                newName: "CountryModels");

            migrationBuilder.RenameTable(
                name: "ConfigurationModel",
                newName: "ConfigurationModels");

            migrationBuilder.RenameTable(
                name: "BankModel",
                newName: "BankModels");

            migrationBuilder.RenameTable(
                name: "ApplicantIssueModel",
                newName: "ApplicantIssueModels");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresss");

            migrationBuilder.RenameTable(
                name: "AcademicExperienceModel",
                newName: "AcademicExperienceModels");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItem_ListId",
                table: "TodoItems",
                newName: "IX_TodoItems_ListId");

            migrationBuilder.RenameIndex(
                name: "IX_ResultUploadModel_SubjectID",
                table: "ResultUploadModels",
                newName: "IX_ResultUploadModels_SubjectID");

            migrationBuilder.RenameIndex(
                name: "IX_ResultUploadModel_GradeID",
                table: "ResultUploadModels",
                newName: "IX_ResultUploadModels_GradeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingExperienceModels",
                table: "WorkingExperienceModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoLists",
                table: "TodoLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectModels",
                table: "SubjectModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SMSModels",
                table: "SMSModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolModels",
                table: "SchoolModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultUploadModels",
                table: "ResultUploadModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequirementModels",
                table: "RequirementModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReligionModels",
                table: "ReligionModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionModels",
                table: "RegionModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgrammeModels",
                table: "ProgrammeModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageModels",
                table: "LanguageModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HallModels",
                table: "HallModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradeModels",
                table: "GradeModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormNoModels",
                table: "FormNoModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormerSchoolModels",
                table: "FormerSchoolModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacultyModels",
                table: "FacultyModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamModels",
                table: "ExamModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentUploadModels",
                table: "DocumentUploadModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DistrictModels",
                table: "DistrictModels",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentModels",
                table: "DepartmentModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DenominationModels",
                table: "DenominationModels",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryModels",
                table: "CountryModels",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigurationModels",
                table: "ConfigurationModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankModels",
                table: "BankModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantIssueModels",
                table: "ApplicantIssueModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresss",
                table: "Addresss",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcademicExperienceModels",
                table: "AcademicExperienceModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_CountryModels_NationalityId",
                table: "ApplicantModel",
                column: "NationalityId",
                principalTable: "CountryModels",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_DistrictModels_DistrictId",
                table: "ApplicantModel",
                column: "DistrictId",
                principalTable: "DistrictModels",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_FormerSchoolModels_FormerSchoolNewId",
                table: "ApplicantModel",
                column: "FormerSchoolNewId",
                principalTable: "FormerSchoolModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_HallModels_HallId",
                table: "ApplicantModel",
                column: "HallId",
                principalTable: "HallModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_ProgrammeModels_ProgrammeModelId",
                table: "ApplicantModel",
                column: "ProgrammeModelId",
                principalTable: "ProgrammeModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_RegionModels_RegionId",
                table: "ApplicantModel",
                column: "RegionId",
                principalTable: "RegionModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_ReligionModels_ReligionId",
                table: "ApplicantModel",
                column: "ReligionId",
                principalTable: "ReligionModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultUploadModels_GradeModels_GradeID",
                table: "ResultUploadModels",
                column: "GradeID",
                principalTable: "GradeModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultUploadModels_SubjectModels_SubjectID",
                table: "ResultUploadModels",
                column: "SubjectID",
                principalTable: "SubjectModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoLists_ListId",
                table: "TodoItems",
                column: "ListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_CountryModels_NationalityId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_DistrictModels_DistrictId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_FormerSchoolModels_FormerSchoolNewId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_HallModels_HallId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_ProgrammeModels_ProgrammeModelId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_RegionModels_RegionId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_ReligionModels_ReligionId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultUploadModels_GradeModels_GradeID",
                table: "ResultUploadModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultUploadModels_SubjectModels_SubjectID",
                table: "ResultUploadModels");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoLists_ListId",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingExperienceModels",
                table: "WorkingExperienceModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoLists",
                table: "TodoLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectModels",
                table: "SubjectModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SMSModels",
                table: "SMSModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolModels",
                table: "SchoolModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultUploadModels",
                table: "ResultUploadModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequirementModels",
                table: "RequirementModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReligionModels",
                table: "ReligionModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionModels",
                table: "RegionModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgrammeModels",
                table: "ProgrammeModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageModels",
                table: "LanguageModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HallModels",
                table: "HallModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GradeModels",
                table: "GradeModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormNoModels",
                table: "FormNoModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormerSchoolModels",
                table: "FormerSchoolModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacultyModels",
                table: "FacultyModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamModels",
                table: "ExamModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentUploadModels",
                table: "DocumentUploadModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DistrictModels",
                table: "DistrictModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentModels",
                table: "DepartmentModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DenominationModels",
                table: "DenominationModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryModels",
                table: "CountryModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigurationModels",
                table: "ConfigurationModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankModels",
                table: "BankModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantIssueModels",
                table: "ApplicantIssueModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresss",
                table: "Addresss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcademicExperienceModels",
                table: "AcademicExperienceModels");

            migrationBuilder.RenameTable(
                name: "WorkingExperienceModels",
                newName: "WorkingExperienceModel");

            migrationBuilder.RenameTable(
                name: "TodoLists",
                newName: "TodoList");

            migrationBuilder.RenameTable(
                name: "TodoItems",
                newName: "TodoItem");

            migrationBuilder.RenameTable(
                name: "SubjectModels",
                newName: "SubjectModel");

            migrationBuilder.RenameTable(
                name: "SMSModels",
                newName: "SMSModel");

            migrationBuilder.RenameTable(
                name: "SchoolModels",
                newName: "SchoolModel");

            migrationBuilder.RenameTable(
                name: "ResultUploadModels",
                newName: "ResultUploadModel");

            migrationBuilder.RenameTable(
                name: "RequirementModels",
                newName: "RequirementModel");

            migrationBuilder.RenameTable(
                name: "ReligionModels",
                newName: "ReligionModel");

            migrationBuilder.RenameTable(
                name: "RegionModels",
                newName: "RegionModel");

            migrationBuilder.RenameTable(
                name: "ProgrammeModels",
                newName: "ProgrammeModel");

            migrationBuilder.RenameTable(
                name: "LanguageModels",
                newName: "LanguageModel");

            migrationBuilder.RenameTable(
                name: "HallModels",
                newName: "HallModel");

            migrationBuilder.RenameTable(
                name: "GradeModels",
                newName: "GradeModel");

            migrationBuilder.RenameTable(
                name: "FormNoModels",
                newName: "FormNoModel");

            migrationBuilder.RenameTable(
                name: "FormerSchoolModels",
                newName: "FormerSchoolModel");

            migrationBuilder.RenameTable(
                name: "FacultyModels",
                newName: "FacultyModel");

            migrationBuilder.RenameTable(
                name: "ExamModels",
                newName: "ExamModel");

            migrationBuilder.RenameTable(
                name: "DocumentUploadModels",
                newName: "DocumentUploadModel");

            migrationBuilder.RenameTable(
                name: "DistrictModels",
                newName: "DistrictModel");

            migrationBuilder.RenameTable(
                name: "DepartmentModels",
                newName: "DepartmentModel");

            migrationBuilder.RenameTable(
                name: "DenominationModels",
                newName: "DenominationModel");

            migrationBuilder.RenameTable(
                name: "CountryModels",
                newName: "CountryModel");

            migrationBuilder.RenameTable(
                name: "ConfigurationModels",
                newName: "ConfigurationModel");

            migrationBuilder.RenameTable(
                name: "BankModels",
                newName: "BankModel");

            migrationBuilder.RenameTable(
                name: "ApplicantIssueModels",
                newName: "ApplicantIssueModel");

            migrationBuilder.RenameTable(
                name: "Addresss",
                newName: "Address");

            migrationBuilder.RenameTable(
                name: "AcademicExperienceModels",
                newName: "AcademicExperienceModel");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_ListId",
                table: "TodoItem",
                newName: "IX_TodoItem_ListId");

            migrationBuilder.RenameIndex(
                name: "IX_ResultUploadModels_SubjectID",
                table: "ResultUploadModel",
                newName: "IX_ResultUploadModel_SubjectID");

            migrationBuilder.RenameIndex(
                name: "IX_ResultUploadModels_GradeID",
                table: "ResultUploadModel",
                newName: "IX_ResultUploadModel_GradeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingExperienceModel",
                table: "WorkingExperienceModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoList",
                table: "TodoList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItem",
                table: "TodoItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectModel",
                table: "SubjectModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SMSModel",
                table: "SMSModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolModel",
                table: "SchoolModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultUploadModel",
                table: "ResultUploadModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequirementModel",
                table: "RequirementModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReligionModel",
                table: "ReligionModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionModel",
                table: "RegionModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgrammeModel",
                table: "ProgrammeModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageModel",
                table: "LanguageModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HallModel",
                table: "HallModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradeModel",
                table: "GradeModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormNoModel",
                table: "FormNoModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormerSchoolModel",
                table: "FormerSchoolModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacultyModel",
                table: "FacultyModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamModel",
                table: "ExamModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentUploadModel",
                table: "DocumentUploadModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DistrictModel",
                table: "DistrictModel",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentModel",
                table: "DepartmentModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DenominationModel",
                table: "DenominationModel",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryModel",
                table: "CountryModel",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigurationModel",
                table: "ConfigurationModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankModel",
                table: "BankModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantIssueModel",
                table: "ApplicantIssueModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcademicExperienceModel",
                table: "AcademicExperienceModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_CountryModel_NationalityId",
                table: "ApplicantModel",
                column: "NationalityId",
                principalTable: "CountryModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_DistrictModel_DistrictId",
                table: "ApplicantModel",
                column: "DistrictId",
                principalTable: "DistrictModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_FormerSchoolModel_FormerSchoolNewId",
                table: "ApplicantModel",
                column: "FormerSchoolNewId",
                principalTable: "FormerSchoolModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_HallModel_HallId",
                table: "ApplicantModel",
                column: "HallId",
                principalTable: "HallModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_ProgrammeModel_ProgrammeModelId",
                table: "ApplicantModel",
                column: "ProgrammeModelId",
                principalTable: "ProgrammeModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_RegionModel_RegionId",
                table: "ApplicantModel",
                column: "RegionId",
                principalTable: "RegionModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_ReligionModel_ReligionId",
                table: "ApplicantModel",
                column: "ReligionId",
                principalTable: "ReligionModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultUploadModel_GradeModel_GradeID",
                table: "ResultUploadModel",
                column: "GradeID",
                principalTable: "GradeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultUploadModel_SubjectModel_SubjectID",
                table: "ResultUploadModel",
                column: "SubjectID",
                principalTable: "SubjectModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_TodoList_ListId",
                table: "TodoItem",
                column: "ListId",
                principalTable: "TodoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
