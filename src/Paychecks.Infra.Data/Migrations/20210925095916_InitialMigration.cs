using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Paychecks.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    Sector = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    GrossSalary = table.Column<decimal>(type: "money", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HealthInsuranceDiscount = table.Column<bool>(type: "bit", nullable: false),
                    DentalInsuranceDiscount = table.Column<bool>(type: "bit", nullable: false),
                    TransportationVoucherDiscount = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}