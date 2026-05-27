using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TourDulich.Models
{
    public partial class ModelDB : DbContext
    {
        private static readonly object SchemaLock = new object();
        private static bool _schemaChecked;

        public ModelDB()
            : base("name=ModelDB")
        {
            EnsureRuntimeSchema();
        }

        public virtual DbSet<ChiTietDatTour> ChiTietDatTours { get; set; }
        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DatTour> DatTours { get; set; }
        public virtual DbSet<DiaDiem> DiaDiems { get; set; }
        public virtual DbSet<HinhAnhTour> HinhAnhTours { get; set; }
        public virtual DbSet<LichTrinhTour> LichTrinhTours { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<LichKhoiHanh> LichKhoiHanhs { get; set; }
        public virtual DbSet<MuaGia> MuaGias { get; set; }
        public virtual DbSet<ChinhSachHuy> ChinhSachHuys { get; set; }
        public virtual DbSet<YeuCauHuy> YeuCauHuys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        private void EnsureRuntimeSchema()
        {
            if (_schemaChecked) return;

            lock (SchemaLock)
            {
                if (_schemaChecked) return;

                Database.ExecuteSqlCommand(@"
IF COL_LENGTH('NguoiDung', 'TrangThaiHoatDong') IS NULL
BEGIN
    ALTER TABLE [dbo].[NguoiDung]
    ADD [TrangThaiHoatDong] BIT NOT NULL
        CONSTRAINT [DF_NguoiDung_TrangThaiHoatDong] DEFAULT (1);
END

EXEC(N'UPDATE [dbo].[NguoiDung]
SET [TrangThaiHoatDong] = 1
WHERE [PhanQuyen] = 0');");

                Database.ExecuteSqlCommand(@"
IF COL_LENGTH('ChinhSachHuy', 'IsActive') IS NULL
BEGIN
    ALTER TABLE [dbo].[ChinhSachHuy]
    ADD [IsActive] BIT NOT NULL
        CONSTRAINT [DF_ChinhSachHuy_IsActive] DEFAULT (1);
END");

                Database.ExecuteSqlCommand(@"
IF COL_LENGTH('DatTour', 'YeuCauXuatHoaDon') IS NULL
BEGIN
    ALTER TABLE [dbo].[DatTour]
    ADD [YeuCauXuatHoaDon] BIT NOT NULL
        CONSTRAINT [DF_DatTour_YeuCauXuatHoaDon] DEFAULT (0);
END

IF COL_LENGTH('DatTour', 'DaGuiHoaDon') IS NULL
BEGIN
    ALTER TABLE [dbo].[DatTour]
    ADD [DaGuiHoaDon] BIT NOT NULL
        CONSTRAINT [DF_DatTour_DaGuiHoaDon] DEFAULT (0);
END

IF COL_LENGTH('DatTour', 'MaSoThueHoaDon') IS NULL
BEGIN
    ALTER TABLE [dbo].[DatTour]
    ADD [MaSoThueHoaDon] NVARCHAR(30) NULL;
END");

                _schemaChecked = true;
            }
        }
    }
}
