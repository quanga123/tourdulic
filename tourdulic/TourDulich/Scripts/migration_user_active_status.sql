IF COL_LENGTH('NguoiDung', 'TrangThaiHoatDong') IS NULL
BEGIN
    ALTER TABLE [dbo].[NguoiDung]
    ADD [TrangThaiHoatDong] BIT NOT NULL
        CONSTRAINT [DF_NguoiDung_TrangThaiHoatDong] DEFAULT (1);
END

EXEC(N'UPDATE [dbo].[NguoiDung]
SET [TrangThaiHoatDong] = 1
WHERE [PhanQuyen] = 0');
