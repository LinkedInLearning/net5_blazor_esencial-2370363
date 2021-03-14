using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoriesLibrary.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<int>(type: "int", rowVersion: true, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Author", "Category", "PublishedDate", "Text", "Title" },
                values: new object[,]
                {
                    { 1, "Eva Artés", "terror", new DateTime(2021, 2, 28, 13, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Los ángulos tienen dientes" },
                    { 19, "Rosa Ramos", "ciencia ficción", new DateTime(2021, 2, 28, 6, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Los gatos también ladran" },
                    { 18, "Daniel Martín", "Thriller", new DateTime(2021, 2, 28, 5, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "El barco de papel" },
                    { 17, "Jesús Palomo", "literatura", new DateTime(2021, 2, 28, 5, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Las garras del hambre" },
                    { 16, "Elena Carrión", "ciencia ficción", new DateTime(2021, 2, 28, 4, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Saltando charcos" },
                    { 15, "Gloria Onrubia", "ciencia ficción", new DateTime(2021, 2, 28, 3, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Los amigos que fuimos" },
                    { 14, "Eduardo Préscoli", "romántica", new DateTime(2021, 2, 28, 2, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "El desorden de tu ausencia" },
                    { 13, "Cristóbal Lafuente", "Thriller", new DateTime(2021, 2, 28, 1, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "El master" },
                    { 12, "Ignacio Aguado", "ciencia ficción", new DateTime(2021, 2, 28, 0, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "La vacuna" },
                    { 20, "Roberto Masip", "novela", new DateTime(2021, 2, 28, 7, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Durmiendo" },
                    { 11, "Alejandro Carbonell", "ciencia ficción", new DateTime(2021, 2, 28, 23, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Planetas sin vida" },
                    { 9, "Blanca Romero", "novela", new DateTime(2021, 2, 28, 21, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Dirección prohibida" },
                    { 8, "Núria Azanza", "novela histórica", new DateTime(2021, 2, 28, 20, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Los árboles invisibles" },
                    { 7, "Ricardo Allen", "ciencia ficción", new DateTime(2021, 2, 28, 19, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Sacando las castañas del fuego" },
                    { 6, "Daniela Rubio", "novela", new DateTime(2021, 2, 28, 18, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Las cerillas mojadas no sirven para nada" },
                    { 5, "Diego de Salazar", "novela", new DateTime(2021, 2, 28, 17, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "El tocador de la abuela" },
                    { 4, "Lucía Castillo", "ciencia ficción", new DateTime(2021, 2, 28, 16, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "El vuelo al fin del mundo" },
                    { 3, "Andrés López", "terror", new DateTime(2021, 2, 28, 15, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "Dejad que los niños se acerquen a mí" },
                    { 2, "Raquel Sastre", "novela", new DateTime(2021, 2, 28, 14, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "La gasolinera" },
                    { 10, "Alfonso Tirado", "romántica", new DateTime(2021, 2, 28, 22, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "El olor de las margaritas" },
                    { 21, "Juan María Martín", "ciencia ficción", new DateTime(2021, 2, 28, 8, 22, 51, 0, DateTimeKind.Unspecified), "Línea 1\r\nLínea 2", "La mirada vacía" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
