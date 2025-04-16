using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Motivo",
                table: "Atenciones",
                newName: "MotivoConsulta");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Atenciones",
                newName: "FechaAtencion");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Atenciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_AnimalId",
                table: "Atenciones",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atenciones_Animales_AnimalId",
                table: "Atenciones",
                column: "AnimalId",
                principalTable: "Animales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atenciones_Animales_AnimalId",
                table: "Atenciones");

            migrationBuilder.DropIndex(
                name: "IX_Atenciones_AnimalId",
                table: "Atenciones");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Atenciones");

            migrationBuilder.RenameColumn(
                name: "MotivoConsulta",
                table: "Atenciones",
                newName: "Motivo");

            migrationBuilder.RenameColumn(
                name: "FechaAtencion",
                table: "Atenciones",
                newName: "Fecha");
        }
    }
}
