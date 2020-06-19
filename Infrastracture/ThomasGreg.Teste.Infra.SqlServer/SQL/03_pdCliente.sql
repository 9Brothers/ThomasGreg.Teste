IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'pdCliente'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.pdCliente
GO

CREATE PROCEDURE dbo.pdCliente
    @Guid UNIQUEIDENTIFIER    
AS

    DELETE FROM Logradouros WHERE ClienteId = @Guid

    DELETE FROM Clientes WHERE Id = @Guid
GO