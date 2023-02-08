using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineApplicationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "ApplicantModel",
                newName: "HallFeesPaidCurrency");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ApplicantModel",
                newName: "HallFeesPaid");

            migrationBuilder.AlterColumn<string>(
                name: "AltPhone",
                table: "ApplicantModel",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<decimal>(
                name: "FeesPaid",
                table: "ApplicantModel",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeesPaidCurrency",
                table: "ApplicantModel",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeesPaid",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "FeesPaidCurrency",
                table: "ApplicantModel");

            migrationBuilder.RenameColumn(
                name: "HallFeesPaidCurrency",
                table: "ApplicantModel",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "HallFeesPaid",
                table: "ApplicantModel",
                newName: "Amount");

            migrationBuilder.AlterColumn<string>(
                name: "AltPhone",
                table: "ApplicantModel",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
