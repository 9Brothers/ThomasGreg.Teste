IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'puLogradouro'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.puLogradouro
GO

CREATE PROCEDURE dbo.puLogradouro
    @Id UNIQUEIDENTIFIER,
    @Nome VARCHAR(300),
    @ClienteId VARCHAR(100)
AS
    DECLARE @UpdatedAt DATETIME = GETDATE()

    UPDATE Logradouros SET
        Nome = @Nome,
        ClienteId = @ClienteId,        
        UpdatedAt = @UpdatedAt
    WHERE Id = @Id

    SELECT * FROM Logradouros (NOLOCK) WHERE Id = @Id
GO