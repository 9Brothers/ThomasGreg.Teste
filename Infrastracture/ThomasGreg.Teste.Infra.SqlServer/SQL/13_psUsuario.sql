IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'psUsuario'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.psUsuario
GO

CREATE PROCEDURE dbo.psUsuario
    @Username VARCHAR(30),
    @Password VARCHAR(30)
AS

    SELECT * FROM Usuarios (NOLOCK) WHERE Username = @Username AND Password = @Password
GO