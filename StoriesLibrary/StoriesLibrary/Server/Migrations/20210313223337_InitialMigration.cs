using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoriesLibrary.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    RowVersion = table.Column<int>(type: "INTEGER", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                });

            migrationBuilder.Sql(@"CREATE TRIGGER UpdateStoryVersion
AFTER UPDATE ON Stories
BEGIN
    UPDATE Stories
    SET RowVersion = RowVersion + 1
    WHERE Id = NEW.Id;
END;");

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 1, "Eva Artés", "terror", new DateTime(2021, 2, 28, 13, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Los ángulos tienen dientes" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 19, "Rosa Ramos", "ciencia ficción", new DateTime(2021, 2, 28, 6, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Los gatos también ladran" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 18, "Daniel Martín", "Thriller", new DateTime(2021, 2, 28, 5, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "El barco de papel" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 17, "Jesús Palomo", "literatura", new DateTime(2021, 2, 28, 5, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Las garras del hambre" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 16, "Elena Carrión", "ciencia ficción", new DateTime(2021, 2, 28, 4, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Saltando charcos" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 15, "Gloria Onrubia", "ciencia ficción", new DateTime(2021, 2, 28, 3, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Los amigos que fuimos" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 14, "Eduardo Préscoli", "romántica", new DateTime(2021, 2, 28, 2, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "El desorden de tu ausencia" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 13, "Cristóbal Lafuente", "Thriller", new DateTime(2021, 2, 28, 1, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "El master" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 12, "Ignacio Aguado", "ciencia ficción", new DateTime(2021, 2, 28, 0, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "La vacuna" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 20, "Roberto Masip", "novela", new DateTime(2021, 2, 28, 7, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Durmiendo" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 11, "Alejandro Carbonell", "ciencia ficción", new DateTime(2021, 2, 28, 23, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Planetas sin vida" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 9, "Blanca Romero", "novela", new DateTime(2021, 2, 28, 21, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Dirección prohibida" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 8, "Núria Azanza", "novela histórica", new DateTime(2021, 2, 28, 20, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Los árboles invisibles" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 7, "Ricardo Allen", "ciencia ficción", new DateTime(2021, 2, 28, 19, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Sacando las castañas del fuego" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 6, "Daniela Rubio", "novela", new DateTime(2021, 2, 28, 18, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Las cerillas mojadas no sirven para nada" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 5, "Diego de Salazar", "novela", new DateTime(2021, 2, 28, 17, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "El tocador de la abuela" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 4, "Lucía Castillo", "ciencia ficción", new DateTime(2021, 2, 28, 16, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "El vuelo al fin del mundo" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 3, "Andrés López", "terror", new DateTime(2021, 2, 28, 15, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Dejad que los niños se acerquen a mí" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 2, "Raquel Sastre", "novela", new DateTime(2021, 2, 28, 14, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "La gasolinera" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 10, "Alfonso Tirado", "romántica", new DateTime(2021, 2, 28, 22, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "El olor de las margaritas" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[] { 21, "Juan María Martín", "ciencia ficción", new DateTime(2021, 2, 28, 8, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "La mirada vacía" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stories");
        }
    }
}
