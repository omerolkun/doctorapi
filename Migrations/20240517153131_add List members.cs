using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalApi.Migrations
{
    /// <inheritdoc />
    public partial class addListmembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorHospital",
                columns: table => new
                {
                    DoctorsId = table.Column<int>(type: "integer", nullable: false),
                    HospitalsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorHospital", x => new { x.DoctorsId, x.HospitalsId });
                    table.ForeignKey(
                        name: "FK_DoctorHospital_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorHospital_Hospitals_HospitalsId",
                        column: x => x.HospitalsId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorHospital_HospitalsId",
                table: "DoctorHospital",
                column: "HospitalsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorHospital");
        }
    }
}
