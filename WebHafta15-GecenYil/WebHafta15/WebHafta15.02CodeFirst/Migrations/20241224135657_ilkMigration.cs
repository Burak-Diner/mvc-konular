using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebHafta15._02CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class ilkMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Departman",
                columns: table => new
                {
                    DepartmanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Departman", x => x.DepartmanId);
                });

            migrationBuilder.CreateTable(
                name: "tb_Kisi",
                columns: table => new
                {
                    KisiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DepartmanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Kisi", x => x.KisiId);
                    table.ForeignKey(
                        name: "FK_tb_Kisi_tb_Departman_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "tb_Departman",
                        principalColumn: "DepartmanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Kisi_DepartmanId",
                table: "tb_Kisi",
                column: "DepartmanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Kisi");

            migrationBuilder.DropTable(
                name: "tb_Departman");
        }
    }
}
