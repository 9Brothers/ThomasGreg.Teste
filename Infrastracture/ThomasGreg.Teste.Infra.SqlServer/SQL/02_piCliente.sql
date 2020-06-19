IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'piCliente'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.piCliente
GO

CREATE PROCEDURE dbo.piCliente
    @Nome VARCHAR(300),
    @Email VARCHAR(100),
    @Logotipo VARCHAR(2500)
AS

    DECLARE @CreatedAt DATETIME = GETDATE()
    DECLARE @UpdatedAt DATETIME = @CreatedAt

    DECLARE @result TABLE(
        Id UNIQUEIDENTIFIER
    )
    DECLARE @Id UNIQUEIDENTIFIER

    INSERT INTO Clientes (Nome, Email, Logotipo, CreatedAt, UpdatedAt)
    OUTPUT inserted.Id 
    INTO @result VALUES(@Nome, @Email, @Logotipo, @CreatedAt, @UpdatedAt)

    SELECT @Id = Id FROM @result

    SELECT * FROM Clientes (NOLOCK) WHERE Id = @Id
GO