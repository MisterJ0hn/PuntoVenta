/*
   jueves, 13 de noviembre de 201422:42:46
   Usuario: sa
   Servidor: localhost
   Base de datos: InventarioWeb
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.DETALLEDOCUMENTO ADD
	EsPromocion int NULL
GO
ALTER TABLE dbo.DETALLEDOCUMENTO ADD CONSTRAINT
	DF_DETALLEDOCUMENTO_EsPromocion DEFAULT 0 FOR EsPromocion
GO
ALTER TABLE dbo.DETALLEDOCUMENTO SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
