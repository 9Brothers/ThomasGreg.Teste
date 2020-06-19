IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'psLogradouroPorClienteGuid'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.psLogradouroPorClienteGuid
GO

CREATE PROCEDURE dbo.psLogradouroPorClienteGuid
    @ClienteGuid UNIQUEIDENTIFIER
AS

    SELECT * FROM Logradouros WHERE ClienteId = @ClienteGuid
GO