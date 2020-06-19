IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'puCliente'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.puCliente
GO

CREATE PROCEDURE dbo.puCliente
    @Id UNIQUEIDENTIFIER,
    @Nome VARCHAR(300),
    @Email VARCHAR(100),
    @Logotipo VARCHAR(2500)
AS
    DECLARE @UpdatedAt DATETIME = GETDATE()

    UPDATE Clientes SET
        Nome = @Nome,
        Email = @Email,
        Logotipo = @Logotipo,
        UpdatedAt = @UpdatedAt
    WHERE Id = @Id

    SELECT * FROM Clientes (NOLOCK) WHERE Id = @Id
GO