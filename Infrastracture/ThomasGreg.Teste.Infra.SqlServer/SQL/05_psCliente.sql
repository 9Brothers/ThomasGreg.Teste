IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'psCliente'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.psCliente
GO

CREATE PROCEDURE dbo.psCliente
    @Id UNIQUEIDENTIFIER,
    @Email VARCHAR(300)
AS

    SELECT * FROM Clientes (NOLOCK) WHERE Id = @Id OR Email = @Email
GO