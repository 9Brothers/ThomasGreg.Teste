IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'puUsuario'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.puUsuario
GO

CREATE PROCEDURE dbo.puUsuario
    @Id UNIQUEIDENTIFIER,    
    @Password VARCHAR(30)
AS
    DECLARE @UpdatedAt DATETIME = GETDATE()

    UPDATE Usuarios SET        
        Password = @Password,
        UpdatedAt = @UpdatedAt
    WHERE Id = @Id

    SELECT * FROM Usuarios (NOLOCK) WHERE Id = @Id
GO