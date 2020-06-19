IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'piLogradouro'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.piLogradouro
GO

CREATE PROCEDURE dbo.piLogradouro
    @Nome VARCHAR(300),
    @ClienteId UNIQUEIDENTIFIER    
AS

    DECLARE @CreatedAt DATETIME = GETDATE()
    DECLARE @UpdatedAt DATETIME = @CreatedAt

    DECLARE @result TABLE(
        Id UNIQUEIDENTIFIER
    )
    DECLARE @Id UNIQUEIDENTIFIER

    INSERT INTO Logradouros (Nome, ClienteId, CreatedAt, UpdatedAt)
    OUTPUT inserted.Id 
    INTO @result VALUES(@Nome, @ClienteId, @CreatedAt, @UpdatedAt)

    SELECT @Id = Id FROM @result

    SELECT * FROM Logradouros (NOLOCK) WHERE Id = @Id
GO