IF COL_LENGTH('ChinhSachHuy', 'IsActive') IS NULL
BEGIN
    ALTER TABLE [dbo].[ChinhSachHuy]
    ADD [IsActive] BIT NOT NULL
        CONSTRAINT [DF_ChinhSachHuy_IsActive] DEFAULT (1);
END
