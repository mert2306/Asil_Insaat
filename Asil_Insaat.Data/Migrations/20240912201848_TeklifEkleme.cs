using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asil_Insaat.Data.Migrations
{
    public partial class TeklifEkleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Kategoris",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Oluşturan = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Düzenleyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DüzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Silen = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SilinmisMi = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Kategoris", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Müsteris",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostaKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeSarti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Olusturan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oluşturan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Düzenleyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DüzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Silen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilinmisMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Müsteris", x => x.Id);
                });



            migrationBuilder.CreateTable(
                name: "SatisBirimis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oluşturan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Düzenleyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DüzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Silen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilinmisMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisBirimis", x => x.Id);
                });



            migrationBuilder.CreateTable(
                name: "Ürüns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<double>(type: "float", nullable: true),
                    Kdv = table.Column<double>(type: "float", nullable: true),
                    SatisBirimiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Oluşturan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Düzenleyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DüzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Silen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilinmisMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ürüns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ürüns_SatisBirimis_SatisBirimiId",
                        column: x => x.SatisBirimiId,
                        principalTable: "SatisBirimis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ürüns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "Teklifs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeklifTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SonTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fiyat = table.Column<double>(type: "float", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MüsteriId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ÜrünId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Oluşturan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Düzenleyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DüzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Silen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilinmisMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teklifs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teklifs_Müsteris_MüsteriId",
                        column: x => x.MüsteriId,
                        principalTable: "Müsteris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teklifs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teklifs_Ürüns_ÜrünId",
                        column: x => x.ÜrünId,
                        principalTable: "Ürüns",
                        principalColumn: "Id"
                        );
                });



            migrationBuilder.InsertData(
                table: "Müsteris",
                columns: new[] { "Id", "Adres", "DüzenlemeTarihi", "Düzenleyen", "Email", "Isim", "OdemeSarti", "Olusturan", "OlusturulmaTarihi", "Oluşturan", "PostaKodu", "Sehir", "Silen", "SilinmisMi", "SilmeTarihi", "Telefon" },
                values: new object[] { new Guid("9aa59b94-9f41-4bce-8f72-5f0af8cc10ac"), "ev", null, null, "mertcanasil3@gmail.com", "mertcan", "yarı peşin", "mertcan", new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Local), "Tanımsız", "23100", "elazığ", null, false, null, "1111111" });



            migrationBuilder.InsertData(
                table: "SatisBirimis",
                columns: new[] { "Id", "Aciklama", "DüzenlemeTarihi", "Düzenleyen", "OlusturulmaTarihi", "Oluşturan", "Silen", "SilinmisMi", "SilmeTarihi" },
                values: new object[] { new Guid("ad515503-49ef-4cc5-8bd4-b1d53106f762"), "deneme", null, null, new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Local), "Tanımsız", null, false, null });






            migrationBuilder.CreateIndex(
                name: "IX_Teklifs_MüsteriId",
                table: "Teklifs",
                column: "MüsteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Teklifs_UserId",
                table: "Teklifs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teklifs_ÜrünId",
                table: "Teklifs",
                column: "ÜrünId");

            migrationBuilder.CreateIndex(
                name: "IX_Ürüns_SatisBirimiId",
                table: "Ürüns",
                column: "SatisBirimiId");

            migrationBuilder.CreateIndex(
                name: "IX_Ürüns_UserId",
                table: "Ürüns",
                column: "UserId");





        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropTable(
                name: "Teklifs");



            migrationBuilder.DropTable(
                name: "Müsteris");

            migrationBuilder.DropTable(
                name: "Ürüns");




            migrationBuilder.DropTable(
                name: "SatisBirimis");


        }
    }
}
