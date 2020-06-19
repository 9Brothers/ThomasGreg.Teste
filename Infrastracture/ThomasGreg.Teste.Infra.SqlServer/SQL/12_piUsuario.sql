IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'piUsuario'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.piUsuario
GO

CREATE PROCEDURE dbo.piUsuario
    @Username VARCHAR(30),
    @Password VARCHAR(30)
AS

    DECLARE @CreatedAt DATETIME = GETDATE()
    DECLARE @UpdatedAt DATETIME = @CreatedAt

    DECLARE @result TABLE(
        Id UNIQUEIDENTIFIER
    )
    DECLARE @Id UNIQUEIDENTIFIER

    INSERT INTO Usuarios (Username, Password, CreatedAt, UpdatedAt)
    OUTPUT inserted.Id 
    INTO @result VALUES(@Username, @Password, @CreatedAt, @UpdatedAt)

    SELECT @Id = Id FROM @result

    SELECT * FROM Usuarios (NOLOCK) WHERE Id = @Id
GO