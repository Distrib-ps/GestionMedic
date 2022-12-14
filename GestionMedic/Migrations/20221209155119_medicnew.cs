using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace GestionMedic.Migrations
{
    public partial class medicnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_Numero",
                table: "categories",
                column: "id");

            migrationBuilder.CreateTable(
                name: "medicaments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    image = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    prix = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    id_categorie = table.Column<int>(type: "int", nullable: false),
                    categoriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_Numero", x => x.id);
                    table.ForeignKey(
                        name: "FK_medicaments_categories_categoriesid",
                        column: x => x.categoriesid,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medicaments_categoriesid",
                table: "medicaments",
                column: "categoriesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicaments");

            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_Numero",
                table: "categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "id");
        }
    }
}
