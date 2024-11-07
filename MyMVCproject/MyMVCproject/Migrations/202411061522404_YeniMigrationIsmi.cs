namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YeniMigrationIsmi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(maxLength: 10, unicode: false),
                        Sifre = c.String(maxLength: 30, unicode: false),
                        Yetki = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Carilers",
                c => new
                    {
                        CariId = c.Int(nullable: false, identity: true),
                        CariAd = c.String(maxLength: 30, unicode: false),
                        CariSoyad = c.String(maxLength: 30, unicode: false),
                        CariSehir = c.String(maxLength: 13, unicode: false),
                        CariMail = c.String(nullable: false, maxLength: 50, unicode: false),
                        Sifre = c.String(nullable: false, maxLength: 15, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CariId);
            
            CreateTable(
                "dbo.SatisHarekets",
                c => new
                    {
                        SatisId = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunId = c.Int(nullable: false),
                        CariId = c.Int(nullable: false),
                        PersonelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SatisId)
                .ForeignKey("dbo.Carilers", t => t.CariId, cascadeDelete: true)
                .ForeignKey("dbo.Personels", t => t.PersonelId, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId)
                .Index(t => t.CariId)
                .Index(t => t.PersonelId);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(maxLength: 30, unicode: false),
                        PersonelSoyad = c.String(maxLength: 30, unicode: false),
                        PersonelMail = c.String(),
                        PersonelGorsel = c.String(maxLength: 250, unicode: false),
                        Departmanid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelId)
                .ForeignKey("dbo.Departmen", t => t.Departmanid, cascadeDelete: true)
                .Index(t => t.Departmanid);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        DepartmanId = c.Int(nullable: false, identity: true),
                        DepartmanAd = c.String(maxLength: 30, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmanId);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        Marka = c.String(maxLength: 30, unicode: false),
                        Stok = c.Short(nullable: false),
                        AlisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Durum = c.Boolean(nullable: false),
                        UrunGorsel = c.String(maxLength: 250, unicode: false),
                        KategoriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrunId)
                .ForeignKey("dbo.Kategoris", t => t.KategoriId, cascadeDelete: true)
                .Index(t => t.KategoriId);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.Detays",
                c => new
                    {
                        DetayId = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        UrunBilgi = c.String(maxLength: 2500, unicode: false),
                    })
                .PrimaryKey(t => t.DetayId);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        FaturaKalemId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Miktar = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FaturaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FaturaKalemId)
                .ForeignKey("dbo.Faturalars", t => t.FaturaId, cascadeDelete: true)
                .Index(t => t.FaturaId);
            
            CreateTable(
                "dbo.Faturalars",
                c => new
                    {
                        FaturaId = c.Int(nullable: false, identity: true),
                        FaturaSeriNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        FaturaSıraNo = c.String(maxLength: 30, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        VergiDairesi = c.String(maxLength: 60, unicode: false),
                        Saat = c.String(maxLength: 5, fixedLength: true, unicode: false),
                        TeslimEden = c.String(maxLength: 30, unicode: false),
                        TeslimAlan = c.String(maxLength: 30, unicode: false),
                        Toplam = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FaturaId);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        GiderId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(),
                        Tarih = c.DateTime(nullable: false),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GiderId);
            
            CreateTable(
                "dbo.Kargoes",
                c => new
                    {
                        KargoId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 300, unicode: false),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Personel = c.String(),
                        Alici = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoId);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        KargoTakipId = c.Int(nullable: false, identity: true),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Aciklama = c.String(maxLength: 300, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoTakipId);
            
            CreateTable(
                "dbo.Mesajs",
                c => new
                    {
                        MesajId = c.Int(nullable: false, identity: true),
                        Gönderen = c.String(maxLength: 50, unicode: false),
                        Alici = c.String(maxLength: 50, unicode: false),
                        Konu = c.String(maxLength: 50, unicode: false),
                        Icerik = c.String(maxLength: 2000, unicode: false),
                        Durum = c.Boolean(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MesajId);
            
            CreateTable(
                "dbo.Yapilacaks",
                c => new
                    {
                        YapilacakId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 150, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.YapilacakId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaturaKalems", "FaturaId", "dbo.Faturalars");
            DropForeignKey("dbo.SatisHarekets", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.Uruns", "KategoriId", "dbo.Kategoris");
            DropForeignKey("dbo.SatisHarekets", "PersonelId", "dbo.Personels");
            DropForeignKey("dbo.Personels", "Departmanid", "dbo.Departmen");
            DropForeignKey("dbo.SatisHarekets", "CariId", "dbo.Carilers");
            DropIndex("dbo.FaturaKalems", new[] { "FaturaId" });
            DropIndex("dbo.Uruns", new[] { "KategoriId" });
            DropIndex("dbo.Personels", new[] { "Departmanid" });
            DropIndex("dbo.SatisHarekets", new[] { "PersonelId" });
            DropIndex("dbo.SatisHarekets", new[] { "CariId" });
            DropIndex("dbo.SatisHarekets", new[] { "UrunId" });
            DropTable("dbo.Yapilacaks");
            DropTable("dbo.Mesajs");
            DropTable("dbo.KargoTakips");
            DropTable("dbo.Kargoes");
            DropTable("dbo.Giders");
            DropTable("dbo.Faturalars");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.Detays");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Uruns");
            DropTable("dbo.Departmen");
            DropTable("dbo.Personels");
            DropTable("dbo.SatisHarekets");
            DropTable("dbo.Carilers");
            DropTable("dbo.Admins");
        }
    }
}
