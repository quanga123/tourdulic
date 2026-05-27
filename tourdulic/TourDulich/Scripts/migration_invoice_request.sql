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
END
