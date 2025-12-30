using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebHafta15._01DbFirst.Migrations
{
    /// <inheritdoc />
    public partial class ustkategoriNullOlabilir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UstKategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.KategoriId);
                    table.ForeignKey(
                        name: "FK_Kategori_Kategori",
                        column: x => x.UstKategoriId,
                        principalTable: "Kategori",
                        principalColumn: "KategoriId");
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MailKodu = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    MailOnay = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "Ozellik",
                columns: table => new
                {
                    OzellikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OzellikAdi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ozellik", x => x.OzellikId);
                });

            migrationBuilder.CreateTable(
                name: "Sehir",
                columns: table => new
                {
                    SehirId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehir", x => x.SehirId);
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    UrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    KatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.UrunId);
                    table.ForeignKey(
                        name: "FK_Urun_Kategori",
                        column: x => x.KatId,
                        principalTable: "Kategori",
                        principalColumn: "KategoriId");
                });

            migrationBuilder.CreateTable(
                name: "KategoriOzellik",
                columns: table => new
                {
                    KategoriOzellikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OzellikId = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriOZellik", x => x.KategoriOzellikId);
                    table.ForeignKey(
                        name: "FK_KategoriOZellik_Kategori",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "KategoriId");
                    table.ForeignKey(
                        name: "FK_KategoriOZellik_Ozellik",
                        column: x => x.OzellikId,
                        principalTable: "Ozellik",
                        principalColumn: "OzellikId");
                });

            migrationBuilder.CreateTable(
                name: "Ilce",
                columns: table => new
                {
                    IlceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlceAdi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SehirId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilce", x => x.IlceId);
                    table.ForeignKey(
                        name: "FK_Ilce_Sehir",
                        column: x => x.SehirId,
                        principalTable: "Sehir",
                        principalColumn: "SehirId");
                });

            migrationBuilder.CreateTable(
                name: "UrunOzellik",
                columns: table => new
                {
                    UrunOzellikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OzellikId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    OzellikIcerik = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunOzellik", x => x.UrunOzellikId);
                    table.ForeignKey(
                        name: "FK_UrunOzellik_Ozellik",
                        column: x => x.OzellikId,
                        principalTable: "Ozellik",
                        principalColumn: "OzellikId");
                    table.ForeignKey(
                        name: "FK_UrunOzellik_Urun",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateTable(
                name: "Mahalle",
                columns: table => new
                {
                    MahalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MahalleAdi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MahallePostaKodu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IlceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahalle", x => x.MahalleId);
                    table.ForeignKey(
                        name: "FK_Mahalle_Ilce",
                        column: x => x.IlceId,
                        principalTable: "Ilce",
                        principalColumn: "IlceId");
                });

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    AdresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AdresSatir1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AdresSatir2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MahId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.AdresId);
                    table.ForeignKey(
                        name: "FK_Adres_Kullanici",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciId");
                    table.ForeignKey(
                        name: "FK_Adres_Mahalle",
                        column: x => x.MahId,
                        principalTable: "Mahalle",
                        principalColumn: "MahalleId");
                });

            migrationBuilder.CreateTable(
                name: "Satici",
                columns: table => new
                {
                    SaticiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaticiAdi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SaticiAdres = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SaticiMahID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satici", x => x.SaticiId);
                    table.ForeignKey(
                        name: "FK_Satici_Mahalle",
                        column: x => x.SaticiMahID,
                        principalTable: "Mahalle",
                        principalColumn: "MahalleId");
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    SiparisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresId = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    OdemeOnayi = table.Column<bool>(type: "bit", nullable: false),
                    SiparisTarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.SiparisId);
                    table.ForeignKey(
                        name: "FK_Siparis_Kullanici",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciId");
                    table.ForeignKey(
                        name: "FK_Siparis_Siparis",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "AdresId");
                });

            migrationBuilder.CreateTable(
                name: "SaticiUrun",
                columns: table => new
                {
                    SaticiUrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaticiId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    StokAdedi = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaticiUrun", x => x.SaticiUrunId);
                    table.ForeignKey(
                        name: "FK_SaticiUrun_Satici",
                        column: x => x.SaticiId,
                        principalTable: "Satici",
                        principalColumn: "SaticiId");
                    table.ForeignKey(
                        name: "FK_SaticiUrun_Urun",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateTable(
                name: "SepetUrun",
                columns: table => new
                {
                    SepetUrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SepetKullaniciId = table.Column<int>(type: "int", nullable: false),
                    SaticiUrunId = table.Column<int>(type: "int", nullable: false),
                    UrunAdedi = table.Column<int>(type: "int", nullable: false),
                    HediyeMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SepetUrun", x => x.SepetUrunId);
                    table.ForeignKey(
                        name: "FK_SepetUrun_Kullanici",
                        column: x => x.SepetKullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciId");
                    table.ForeignKey(
                        name: "FK_SepetUrun_SaticiUrun",
                        column: x => x.SaticiUrunId,
                        principalTable: "SaticiUrun",
                        principalColumn: "SaticiUrunId");
                });

            migrationBuilder.CreateTable(
                name: "SiparisUrun",
                columns: table => new
                {
                    SiparisUrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisId = table.Column<int>(type: "int", nullable: false),
                    SatUrunId = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    HediyeMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisUrun", x => x.SiparisUrunId);
                    table.ForeignKey(
                        name: "FK_SiparisUrun_SaticiUrun",
                        column: x => x.SatUrunId,
                        principalTable: "SaticiUrun",
                        principalColumn: "SaticiUrunId");
                    table.ForeignKey(
                        name: "FK_SiparisUrun_Siparis",
                        column: x => x.SiparisId,
                        principalTable: "Siparis",
                        principalColumn: "SiparisId");
                });

            migrationBuilder.CreateTable(
                name: "Yorum",
                columns: table => new
                {
                    YorumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaticiUrunId = table.Column<int>(type: "int", nullable: false),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    YorumMetin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorum", x => x.YorumId);
                    table.ForeignKey(
                        name: "FK_Yorum_Kullanici",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciId");
                    table.ForeignKey(
                        name: "FK_Yorum_Yorum",
                        column: x => x.SaticiUrunId,
                        principalTable: "SaticiUrun",
                        principalColumn: "SaticiUrunId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adres_KullaniciId",
                table: "Adres",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_MahId",
                table: "Adres",
                column: "MahId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilce_SehirId",
                table: "Ilce",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategori_UstKategoriId",
                table: "Kategori",
                column: "UstKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_KategoriOzellik_KategoriId",
                table: "KategoriOzellik",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_KategoriOzellik_OzellikId",
                table: "KategoriOzellik",
                column: "OzellikId");

            migrationBuilder.CreateIndex(
                name: "IX_Mahalle_IlceId",
                table: "Mahalle",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Satici_SaticiMahID",
                table: "Satici",
                column: "SaticiMahID");

            migrationBuilder.CreateIndex(
                name: "IX_SaticiUrun_SaticiId",
                table: "SaticiUrun",
                column: "SaticiId");

            migrationBuilder.CreateIndex(
                name: "IX_SaticiUrun_UrunId",
                table: "SaticiUrun",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_SepetUrun_SaticiUrunId",
                table: "SepetUrun",
                column: "SaticiUrunId");

            migrationBuilder.CreateIndex(
                name: "IX_SepetUrun_SepetKullaniciId",
                table: "SepetUrun",
                column: "SepetKullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_AdresId",
                table: "Siparis",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_KullaniciId",
                table: "Siparis",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisUrun_SatUrunId",
                table: "SiparisUrun",
                column: "SatUrunId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisUrun_SiparisId",
                table: "SiparisUrun",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_KatId",
                table: "Urun",
                column: "KatId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunOzellik_OzellikId",
                table: "UrunOzellik",
                column: "OzellikId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunOzellik_UrunId",
                table: "UrunOzellik",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_KullaniciID",
                table: "Yorum",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_SaticiUrunId",
                table: "Yorum",
                column: "SaticiUrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KategoriOzellik");

            migrationBuilder.DropTable(
                name: "SepetUrun");

            migrationBuilder.DropTable(
                name: "SiparisUrun");

            migrationBuilder.DropTable(
                name: "UrunOzellik");

            migrationBuilder.DropTable(
                name: "Yorum");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "Ozellik");

            migrationBuilder.DropTable(
                name: "SaticiUrun");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Satici");

            migrationBuilder.DropTable(
                name: "Urun");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "Mahalle");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Ilce");

            migrationBuilder.DropTable(
                name: "Sehir");
        }
    }
}
