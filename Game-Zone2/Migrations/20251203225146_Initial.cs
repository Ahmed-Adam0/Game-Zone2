using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Game_Zone2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(230)", maxLength: 230, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(230)", maxLength: 230, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    Cover = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(230)", maxLength: 230, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.ID);
                    table.ForeignKey(
                        name: "FK_games_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gameDevices",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gameDevices", x => new { x.GameId, x.DeviceId });
                    table.ForeignKey(
                        name: "FK_gameDevices_devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "devices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gameDevices_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "RPG" },
                    { 4, "Strategy" },
                    { 5, "Simulation" }
                });

            migrationBuilder.InsertData(
                table: "devices",
                columns: new[] { "ID", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "pc-icon", "PC" },
                    { 2, "playstation-icon", "PlayStation" },
                    { 3, "xbox-icon", "Xbox" },
                    { 4, "nintendo-icon", "Nintendo Switch" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_gameDevices_DeviceId",
                table: "gameDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_games_CategoryId",
                table: "games",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gameDevices");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
