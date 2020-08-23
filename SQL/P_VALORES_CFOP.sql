USE [teste]
GO
CREATE PROCEDURE [dbo].[P_VALORES_CFOP]
AS
SELECT [Cfop], 
		SUM(BaseIcms) as 'Valor Total da Base de ICMS', 
		SUM(ValorIcms) as 'Valor Total do ICMS', 
		ISNULL(SUM(ValorIpi), 0)  as 'Valor Total do IPI'
FROM [dbo].[NotaFiscalItem]
GROUP BY [Cfop]

RETURN 
GO