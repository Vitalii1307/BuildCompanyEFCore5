USE [construction_company]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[OrderProcedure]
		@price = 10000

SELECT	@return_value as 'Return Value'

GO
