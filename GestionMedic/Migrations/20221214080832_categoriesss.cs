using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionMedic.Migrations
{
    public partial class categoriesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicaments_categories_categoriesid",
                table: "medicaments");

            migrationBuilder.DropIndex(
                name: "IX_medicaments_categoriesid",
                table: "medicaments");

            migrationBuilder.DropColumn(
                name: "categoriesid",
                table: "medicaments");

            migrationBuilder.CreateIndex(
                name: "IX_medicaments_id_categorie",
                table: "medicaments",
                column: "id_categorie");

            migrationBuilder.AddForeignKey(
                name: "FK_medicaments_categories_id_categorie",
                table: "medicaments",
                column: "id_categorie",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicaments_categories_id_categorie",
                table: "medicaments");

            migrationBuilder.DropIndex(
                name: "IX_medicaments_id_categorie",
                table: "medicaments");

            migrationBuilder.AddColumn<int>(
                name: "categoriesid",
                table: "medicaments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicaments_categoriesid",
                table: "medicaments",
                column: "categoriesid");

            migrationBuilder.AddForeignKey(
                name: "FK_medicaments_categories_categoriesid",
                table: "medicaments",
                column: "categoriesid",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
