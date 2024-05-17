using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalApi.Migrations
{
    /// <inheritdoc />
    public partial class addjunctionDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorHospitals",
                table: "DoctorHospitals");

            migrationBuilder.DropIndex(
                name: "IX_DoctorHospitals_DoctorId",
                table: "DoctorHospitals");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DoctorHospitals",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorHospitals",
                table: "DoctorHospitals",
                columns: new[] { "DoctorId", "HospitalId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorHospitals",
                table: "DoctorHospitals");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DoctorHospitals",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorHospitals",
                table: "DoctorHospitals",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorHospitals_DoctorId",
                table: "DoctorHospitals",
                column: "DoctorId");
        }
    }
}
