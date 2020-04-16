CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT id, ProductName, [Description], RetailPrice, QuantityInStock 
	FROM dbo.Product
	ORDER BY ProductName
END 
