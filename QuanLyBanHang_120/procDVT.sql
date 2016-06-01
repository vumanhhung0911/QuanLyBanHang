--select all
CREATE PROC sp_DonViTinh_SelectAll
AS
BEGIN
	SELECT * FROM dbo.DVT
END
GO
-- select by primarikey
CREATE PROC sp_DonViTinh_SelectByID
@ID int
AS
BEGIN
	SELECT * FROM dbo.DVT WHERE MaDVT=@ID
END
-- insert
GO
CREATE PROC sp_DonViTinh_Insert
@TenDVT NVARCHAR(50)
AS
BEGIN
    INSERT INTO  DVT ( TenDVT ) VALUES  ( @TenDVT  )
END
-- update
GO
CREATE PROC sp_DonViTinh_Update
@ID INT,
@TenDVT NVARCHAR(50)
AS
BEGIN
    UPDATE dbo.DVT SET TenDVT=@TenDVT WHERE MaDVT=@ID
END
-- delete
GO
CREATE PROC sp_DonViTinh_Delete
@ID INT
AS
BEGIN
    DELETE FROM dbo.DVT WHERE MaDVT=@ID
END